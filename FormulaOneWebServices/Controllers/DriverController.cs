using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassUtilities;
using System.IO;
using System.Data.SqlClient;

namespace FormulaOneWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        public static string THISDATAPATH = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\Data\\";
        public static string DB = "[" + WORKINGPATH + "FormulaOne.mdf]";
        public Utilities utilities = new Utilities(WORKINGPATH, CONNECTION_STRING, THISDATAPATH, DB);

        // GET: api/Driver
        [HttpGet]
        public List<ClassUtilities.Models.Driver> Get()
        {
            List<ClassUtilities.Models.Driver> driverList = utilities.getTableDriver();
            return utilities.detailsDriver(driverList);
        }

        // GET: api/Driver/N
        [HttpGet("{id}")]
        public ClassUtilities.Models.Driver Get(int id)
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            ClassUtilities.Models.Driver driver = utilities.getDriverByCode(id);
            driver.country = utilities.getNameFromCode(connection, $"SELECT * FROM Country WHERE countryCode='{driver.country}';", 1);
            driver.team = utilities.getNameFromCode(connection, $"SELECT * FROM Team WHERE teamCode={driver.team};", 1);
            return driver;
        }

        // GET: api/Driver/teamName/driverSurname/countryName
        [HttpGet("{teamName}/{driverSurname}/{countryName}")]
        public List<ClassUtilities.Models.Driver> Get(string teamName, string driverSurname, string countryName)
        {
            List<ClassUtilities.Models.Driver> driverList = utilities.getTableDriver();
            driverList = utilities.detailsDriver(driverList);
            if (teamName != "none")
                return utilities.searchDriver(driverList, "teamName", teamName);
            else if(driverSurname != "none")
                return utilities.searchDriver(driverList, "driverSurname", driverSurname);
            else
                return utilities.searchDriver(driverList, "countryName", countryName);
        }


        // POST: api/Driver
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Driver/N
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/N
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
