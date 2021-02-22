using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using Extension;
using System.Data;
using System.Threading;
using System.Text;
using ClassUtilities.Models;

namespace ClassUtilities
{
    public class Utilities
    {
        public string WORKINGPATH;
        public string CONNECTION_STRING;
        public string THISDATAPATH;
        public string DB;

        public List<string> tableNames;
        public List<string> fileNames;
        public Utilities(string wp, string cs, string tdp, string db)
        {
            WORKINGPATH = wp;
            CONNECTION_STRING = cs;
            THISDATAPATH = tdp;
            DB = db;
            tableNames = TablesNames();
            fileNames = new List<string>();
        }

        public void CopySQLFiles()
        {
            fileNames.Clear();
            string[] fileEntries = Directory.GetFiles(THISDATAPATH);
            string relations = string.Empty;

            foreach (string filePath in fileEntries)
            {
                string fileName = filePath.Split('\\').Last();
                string ext = fileName.Split('.').Last();
                if (ext == "sql")
                {
                    string newDbFilePath = WORKINGPATH + fileName;
                    string oldDbFilePath = filePath;
                    File.Copy(oldDbFilePath, newDbFilePath, true);
                    if (!fileName.Contains("Relations"))
                    {
                        fileNames.Add(fileName);
                    }
                }
            }
        }

        public void ExecuteSqlScript(string sqlScriptName, bool set = false, bool reset = false)
        {
            var fileContent = File.ReadAllText(WORKINGPATH + sqlScriptName);
            fileContent = fileContent.Replace("\r\n", "");
            fileContent = fileContent.Replace("\r", "");
            fileContent = fileContent.Replace("\n", "");
            fileContent = fileContent.Replace("\t", "");
            var sqlqueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var con = new SqlConnection(CONNECTION_STRING);
            var cmd = new SqlCommand("query", con);

            con.Open(); int i = 0; int nErr = 0;
            foreach (var query in sqlqueries)
            {
                cmd.CommandText = query; i++;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    ConsoleEx.WriteLineRed($"{sqlScriptName}: Errore in esecuzione della query numero: {i}\n" +
                                               $"\tErrore SQL: {err.Number} - {err.Message}", 
                                               ConsoleColor.Yellow);
                    nErr++;
                }
            }
            con.Close();

            if (nErr == 0 && !set)
            {
                ConsoleEx.WriteLineGreen($"Script {sqlScriptName} ended", ConsoleColor.Yellow);
            }
            else if (nErr != 0 && !set)
            {
                ConsoleEx.WriteLineRed($"Script {sqlScriptName} ended with {nErr} errors", ConsoleColor.Yellow);

            }
            else if (nErr != 0 && set)
            {
                ConsoleEx.WriteLineRed($"Error during set in {sqlScriptName}", ConsoleColor.Yellow);
                if (reset) throw new Exception("Error during Relations");
            }
        }

        public void ExecuteQuery(string query, SqlConnection con)
        {
            var cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        public void ResetDB()
        {
            Backup();
            try
            {
                Drop();
                Set(true);
                ConsoleEx.WriteLineGreen("Reset ended without errors", ConsoleColor.Yellow);
            }
            catch (Exception)
            {
                Restore();
            }
        }

        public void Drop()
        {
            var con = new SqlConnection(CONNECTION_STRING);
            tableNames = TablesNames();

            con.Open();

            try
            {
                DropTables(con);
            }
            catch (Exception)
            {
                // Se va in errore per le relazioni, le cancella
                ExecuteSqlScript("DropRelations.sql");
                DropTables(con);
            }
            con.Close();
            ConsoleEx.WriteLineGreen("\nDrop tables ended", ConsoleColor.Yellow);
        }

        private void DropTables(SqlConnection con)
        {
            for (int i = 0; i < tableNames.Count; i++)
            {
                ExecuteQuery($"DROP TABLE IF EXISTS {tableNames[i]}", con);
            }
        }

        public void Set(bool reset = false)
        {
            for (int i = 0; i < fileNames.Count; i++)
            {
                ExecuteSqlScript(fileNames[i], true, reset);
            }
            ExecuteSqlScript("Relations.sql", true, reset);
            ConsoleEx.WriteLineGreen("\nCreate tables ended", ConsoleColor.Yellow);
        }

        public void Backup()
        {
            try
            {
                using (SqlConnection dbConn = new SqlConnection())
                {
                    dbConn.ConnectionString = CONNECTION_STRING;
                    dbConn.Open();

                    using (SqlCommand multiuser_rollback_dbcomm = new SqlCommand())
                    {
                        multiuser_rollback_dbcomm.Connection = dbConn;
                        multiuser_rollback_dbcomm.CommandText = $@"ALTER DATABASE {DB} SET MULTI_USER WITH ROLLBACK IMMEDIATE";

                        multiuser_rollback_dbcomm.ExecuteNonQuery();
                    }
                    dbConn.Close();
                }

                SqlConnection.ClearAllPools();

                using (SqlConnection backupConn = new SqlConnection())
                {
                    backupConn.ConnectionString = CONNECTION_STRING;
                    backupConn.Open();

                    using (SqlCommand backupcomm = new SqlCommand())
                    {
                        backupcomm.Connection = backupConn;
                        backupcomm.CommandText = $@"BACKUP DATABASE {DB} TO DISK='{WORKINGPATH}FormulaOneBackup.bak'";
                        backupcomm.ExecuteNonQuery();
                    }
                    backupConn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Restore()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    string sqlStmt2 = string.Format($@"ALTER DATABASE {DB} SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand bu2 = new SqlCommand(sqlStmt2, con);
                    bu2.ExecuteNonQuery();

                    string sqlStmt3 = $@"USE MASTER RESTORE DATABASE {DB} FROM DISK='{WORKINGPATH}FormulaOneBackup.bak' WITH REPLACE;";
                    SqlCommand bu3 = new SqlCommand(sqlStmt3, con);
                    bu3.ExecuteNonQuery();

                    string sqlStmt4 = string.Format($@"ALTER DATABASE {DB} SET MULTI_USER");
                    SqlCommand bu4 = new SqlCommand(sqlStmt4, con);
                    bu4.ExecuteNonQuery();

                    ConsoleEx.WriteLineRed("PROBLEMS WITH RESET. The most recent beckup was restored", ConsoleColor.Yellow);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public DataTable GetDataTable(string table)
        {
            DataTable retVal = new DataTable();
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            string sql = $"SELECT * FROM {table}";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(retVal);
            con.Close();
            da.Dispose();
            return retVal;
        }

        public List<string> TablesNames()
        {
            List<string> tables = new List<string>();

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                //Console.WriteLine("\nQuery data example:");
                //Console.WriteLine("=========================================\n");

                string sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Console.WriteLine("{0}", reader.GetString(0));
                            tables.Add($"{reader.GetString(0)}");
                        }
                    }
                }
            }
            return tables;
        }

        public void Dots()
        {
            while (true)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write('.');
                    Thread.Sleep(1000);
                    if (i == 2)
                    {
                        Console.Write("\b\b\b   \b\b\b");
                        i = -1;
                        Thread.Sleep(1000);
                    }
                }
            }
        }

        public void LoadingMessage(string message)
        {
            Console.Write(message);
            Thread thread1 = new Thread(Dots);
            thread1.Start();
            Console.ReadLine();
            thread1.Abort();
        }

        public List<Country> getTableCountry()
        {
            List<Country> retVal = new List<Country>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"SELECT * FROM Country;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string countryCode = reader.GetString(0);
                            string countryName = reader.GetString(1);
                            retVal.Add(new Country(countryCode, countryName));
                        }
                    }
                }
            }
            return retVal;
        }

        public List<Driver> getTableDriver()
        {
            List<Driver> retVal = new List<Driver>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"SELECT * FROM Driver;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string country = reader.GetString(2);
                            string team = reader.GetInt32(1).ToString();
                            int driverCode = reader.GetInt32(3);
                            string driverFirstname = reader.GetString(4);
                            string driverLastname = reader.GetString(5);
                            DateTime driverDateOfBirth = reader.GetDateTime(6);
                            string driverPlaceOfBirth = reader.GetString(7);

                            retVal.Add(new Driver(country, team, driverCode, driverFirstname,
                                                  driverLastname, driverDateOfBirth,
                                                  driverPlaceOfBirth));
                        }
                    }
                }
            }
            return retVal;
        }

        public List<Driver> detailsDriver(List<Driver> driverList)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                foreach(Driver driver in driverList)
                {
                    driver.country = addCountryName(connection, driver);
                    driver.team = addTeamName(connection, driver);
                }
            }
            return driverList;
        }

        public string addCountryName(SqlConnection connection, Driver driver)
        {
            string sql = $"SELECT * FROM Country WHERE countryCode='{driver.country}';";
            string country = "";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                // create data adapter
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        country = reader.GetString(1);
                    }
                }

                connection.Close();
            }

            return country;
        }

        public string addTeamName(SqlConnection connection, Driver driver)
        {
            string sql = $"SELECT * FROM Team WHERE teamCode={Convert.ToInt32(driver.team)};";
            string team = "";

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                // create data adapter
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        team = reader.GetString(1);
                    }
                }

                connection.Close();
            }
            return team;
        }

        public List<Driver> searchDriver(List<Driver> driverList, string field, string value)
        {
            List<Driver> newDriverList = new List<Driver>();
            foreach (Driver driver in driverList)
            {
                switch (field)
                {
                    case "teamName":
                        {
                            if (driver.team == value)
                            {
                                newDriverList.Add(driver);
                            }
                        }
                        break;
                    case "driverSurname":
                        {
                            if (driver.driverLastname == value)
                            {
                                newDriverList.Add(driver);
                            }
                        }
                        break;
                    case "countryName":
                        {
                            if (driver.country == value)
                            {
                                newDriverList.Add(driver);
                            }
                        }
                        break;
                }
            }
            return newDriverList;
        }

        public List<Circuit> getTableCircuit()
        {
            List<Circuit> retVal = new List<Circuit>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"SELECT * FROM Circuit;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string circuitRef = reader.GetString(1);
                            string circuitName = reader.GetString(2);
                            string circuitLocation = reader.GetString(3);
                            string circuitCountry = reader.GetString(4);

                            retVal.Add(new Circuit(circuitRef, circuitName,
                                                   circuitLocation, circuitCountry));
                        }
                    }
                }
            }
            return retVal;
        }

        public List<Race> getTableRace()
        {
            List<Race> retVal = new List<Race>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"SELECT * FROM Race;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int raceYear = reader.GetInt32(2);
                            int raceRound = reader.GetInt32(3);
                            string raceName = reader.GetString(4);
                            DateTime raceDate = reader.GetDateTime(5);
                            string raceTime = reader.GetString(6);

                            retVal.Add(new Race(raceYear, raceRound,
                                                raceName, raceDate, raceTime));
                        }
                    }
                }
            }
            return retVal;
        }

        public List<Team> getTableTeam()
        {
            List<Team> retVal = new List<Team>();
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string sql = $"SELECT * FROM Team;";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string teamFullName = reader.GetString(1);
                            string teamBase = reader.GetString(2);
                            string teamChief = reader.GetString(3);
                            string teamPowerUnit = reader.GetString(4);
                            int teamWorldChampionships = reader.GetInt32(5);
                            int teamPolePositions = reader.GetInt32(6);

                            retVal.Add(new Team(teamFullName, teamBase,
                                            teamChief, teamPowerUnit,
                                            teamWorldChampionships, teamPolePositions));
                        }
                    }
                }
            }
            return retVal;
        }

        public Country getCountryByCode(string code)
        {
            Country retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Country WHERE countryCode LIKE '{code}';";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string countryCode = reader.GetString(0);
                            string countryName = reader.GetString(1);
                            retVal = new Country(countryCode, countryName);
                        }
                    }
                }
            }
            return retVal;
        }

        public Driver getDriverByCode(int code)
        {
            Driver retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Driver WHERE driverCode = {code};";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string team = reader.GetInt32(1).ToString();
                            string country = reader.GetString(2);
                            int driverCode = reader.GetInt32(3);
                            string driverFirstname = reader.GetString(4);
                            string driverLastname = reader.GetString(5);
                            DateTime driverDateOfBirth = reader.GetDateTime(6);
                            string driverPlaceOfBirth = reader.GetString(7);

                            retVal = new Driver(country, team, driverCode, driverFirstname,
                                              driverLastname, driverDateOfBirth,
                                              driverPlaceOfBirth);
                        }
                    }
                }
            }
            return retVal;
        }

        public Circuit getTableCircuitByCode(int code)
        {
            Circuit retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Circuit WHERE circuitCode = {code};";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string circuitRef = reader.GetString(1);
                            string circuitName = reader.GetString(2);
                            string circuitLocation = reader.GetString(3);
                            string circuitCountry = reader.GetString(4);

                            retVal = new Circuit(circuitRef, circuitName,
                                               circuitLocation, circuitCountry);
                        }
                    }
                }
            }
            return retVal;
        }

        public Race getTableRaceByCode(int code)
        {
            Race retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Race WHERE raceCode = {code};";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int raceYear = reader.GetInt32(2);
                            int raceRound = reader.GetInt32(3);
                            string raceName = reader.GetString(4);
                            DateTime raceDate = reader.GetDateTime(5);
                            string raceTime = reader.GetString(6);

                            retVal = new Race(raceYear, raceRound,
                                            raceName, raceDate, raceTime);
                        }
                    }
                }
            }
            return retVal;
        }

        public Team getTableTeamByCode(int code)
        {
            Team retVal = null;
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                StringBuilder sb = new StringBuilder();
                string sql = $"SELECT * FROM Team WHERE teamCode LIKE {code};";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    // create data adapter
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string teamFullName = reader.GetString(1);
                            string teamBase = reader.GetString(2);
                            string teamChief = reader.GetString(3);
                            string teamPowerUnit = reader.GetString(4);
                            int teamWorldChampionships = reader.GetInt32(5);
                            int teamPolePositions = reader.GetInt32(6);

                            retVal = new Team(teamFullName, teamBase,
                                              teamChief, teamPowerUnit,
                                              teamWorldChampionships, teamPolePositions);
                        }
                    }
                }
            }
            return retVal;
        }
    }
}
