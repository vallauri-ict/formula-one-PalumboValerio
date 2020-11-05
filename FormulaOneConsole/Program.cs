using System;
using System.Data.SqlClient;
using System.IO;
using NormalExtension;

namespace FormulaOneConsole
{
    class Program
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        public static string THISDATAPATH = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName}\\Data\\";

        static void Main(string[] args)
        {
            copySQLFiles(THISDATAPATH);
            /*copyDB("Teams.sql");
            copyDB("Drivers.sql");
            copyDB("FK.sql");*/
            char scelta = ' ';
            do
            {
                Console.WriteLine("\n*** FORMULA ONE - BATCH SCRIPTS ***\n");
                Console.WriteLine("1 - Create Countries");
                Console.WriteLine("2 - Create Teams");
                Console.WriteLine("3 - Create Drivers");
                Console.WriteLine("4 - Create Relations");
                Console.WriteLine("------------------");
                Console.WriteLine("a - Create all tables");
                Console.WriteLine("d - Drop all tables");
                Console.WriteLine("r - Reset DB");
                Console.WriteLine("------------------");
                Console.WriteLine("X - EXIT\n");
                scelta = Console.ReadKey(true).KeyChar;
                switch (scelta)
                {
                    case '1':
                        ExecuteSqlScript("Countries.sql");
                        break;
                    case '2':
                        ExecuteSqlScript("Teams.sql");
                        break;
                    case '3':
                        ExecuteSqlScript("Drivers.sql");
                        break;
                    case '4':
                        ExecuteSqlScript("FK.sql");
                        break;
                    case 'a':
                        Set();
                        break;
                    case 'd':
                        Drop();
                        break;
                    case 'r':
                        ResetDB();
                        break;
                    default:
                        if (scelta != 'X' && scelta != 'x') Console.WriteLine("\nUncorrect Choice - Try Again\n");
                        break;
                }
            } while (scelta != 'X' && scelta != 'x');
        }

        private static void copySQLFiles(string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string filePath in fileEntries)
            {
                string fileName = filePath.Split('\\').Last();
                string newDbFilePath = WORKINGPATH + fileName;
                string oldDbFilePath = filePath;
                File.Copy(oldDbFilePath, newDbFilePath, true);
            }           
        }

        static bool ExecuteSqlScript(string sqlScriptName, bool reset = false)
        {
            bool error = true;
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
                    Console.WriteLine("Errore in esecuzione della query numero: " + i);
                    Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
                    nErr++;
                    error = true;
                }
            }
            con.Close();
            string finalMessage = nErr == 0 ? "Script " + sqlScriptName + " ended without errors" : "Script ended with " + nErr + " errors";
            if(!reset) Console.WriteLine(finalMessage);
            return error;
        }

        private static void ExecuteQuery(string query, SqlConnection con)
        {
            var cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        private static void ResetDB()
        {
            BackupAndRestore("backup database [" + WORKINGPATH + "FormulaOne.mdf] to disk='{0}'", WORKINGPATH + "FormulaOneBackup.mdf", "Backup Created Sucessfully", "Backup Not Created");
            try
            {                
                Drop();
                Set();
                Console.WriteLine("Reset concluso correttamente");
            }
            catch (Exception)
            {
                BackupAndRestore("restore database [" + WORKINGPATH + "FormulaOne.mdf] from disk='{0}'", WORKINGPATH + "FormulaOneBackup.mdf", "DB Restored Sucessfully", "DB Not Restored");
            }
        }

        private static void Drop()
        {
            var con = new SqlConnection(CONNECTION_STRING);

            con.Open();
            ExecuteQuery("DROP TABLE IF EXISTS Country", con);
            ExecuteQuery("DROP TABLE IF EXISTS Team", con);
            ExecuteQuery("DROP TABLE IF EXISTS Driver", con);
            con.Close();
        }

        private static void Set()
        {
            if (ExecuteSqlScript("Countries.sql", true)) throw new Exception("Error during set");
            if (ExecuteSqlScript("Teams.sql", true)) throw new Exception("Error during set");
            if (ExecuteSqlScript("Drivers.sql", true)) throw new Exception("Error during set");
        }

        private static void BackupAndRestore(string cmd, string db, string mex, string errMex)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
                {
                    string sqlStmt = string.Format(cmd, db);
                    using (SqlCommand command = new SqlCommand(sqlStmt, conn))
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                        conn.Close();

                        Console.WriteLine(mex);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine(errMex);
            }
        }
    }
}
