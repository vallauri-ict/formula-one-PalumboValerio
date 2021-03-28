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
    public class StatsController : ControllerBase
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        public static string THISDATAPATH = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\Data\\";
        public static string DB = "[" + WORKINGPATH + "FormulaOne.mdf]";
        public Utilities utilities = new Utilities(WORKINGPATH, CONNECTION_STRING, THISDATAPATH, DB);

        // GET: api/Stats
        [HttpGet]
        public List<ClassUtilities.Models.Stats> Get()
        {
            List<int> driverCodes = utilities.getDriverCodes();
            return utilities.detailsStats(utilities.getTableStats(driverCodes));
        }

        // GET: api/Stats/id
        [HttpGet("{id}")]
        public ClassUtilities.Models.Stats Get(int id)
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            List<int> driverCodes = utilities.getDriverCodes();
            List<ClassUtilities.Models.Stats> statsList = utilities.getTableStats(driverCodes);
            ClassUtilities.Models.Stats stat = null;
            foreach (var stats in statsList)
            {
                if(stats.driver == id.ToString())
                {
                    stat = stats;
                    stat.driver = utilities.getNameFromCode(connection, $"SELECT * FROM Driver WHERE driverCode={stat.driver};", 4);
                    break;
                }
            }
            return stat;
        }

        // POST: api/Stats
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Stats/N
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
