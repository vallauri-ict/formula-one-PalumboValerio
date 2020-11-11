using System;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using ConsoleUtilities;

namespace FormulaOneConsole
{
    class Program
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        public static string THISDATAPATH = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName}\\Data\\";
        public static string DB ="[" + WORKINGPATH + "FormulaOne.mdf]";

        static void Main(string[] args)
        {
            Utilities utilities = new Utilities(WORKINGPATH, CONNECTION_STRING, THISDATAPATH, DB);
            utilities.copySQLFiles(THISDATAPATH);
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
                        utilities.ExecuteSqlScript("Countries.sql");
                        break;
                    case '2':
                        utilities.ExecuteSqlScript("Teams.sql");
                        break;
                    case '3':
                        utilities.ExecuteSqlScript("Drivers.sql");
                        break;
                    case '4':
                        utilities.ExecuteSqlScript("FK.sql");
                        break;
                    case 'a':
                        utilities.Set();
                        break;
                    case 'd':
                        utilities.Drop();
                        break;
                    case 'r':
                        utilities.ResetDB();
                        break;
                    default:
                        if (scelta != 'X' && scelta != 'x') Console.WriteLine("\nUncorrect Choice - Try Again\n");
                        break;
                }
                Thread.Sleep(2000);
                Console.Clear();
            } while (scelta != 'X' && scelta != 'x');
        }

        

        
    }
}
