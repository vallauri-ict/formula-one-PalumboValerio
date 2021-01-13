using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using Extension;
using System.Data;
using System.Threading;

namespace ClassUtilities
{
    public class Utilities
    {
        public string WORKINGPATH;
        private string CONNECTION_STRING;
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
    }
}
