using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassUtilities;
using System.Data;
using System.Data.SqlClient;

namespace FormulaOneWebServices
{
    //api/Country
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        public static string THISDATAPATH = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\Data\\";
        public static string DB = "[" + WORKINGPATH + "FormulaOne.mdf]";
        public Utilities utilities = new Utilities(WORKINGPATH, CONNECTION_STRING, THISDATAPATH, DB);

        // GET: api/Result
        [HttpGet]
        public List<ClassUtilities.Models.Result> Get()
        {
            List<ClassUtilities.Models.Result> resultList = utilities.getTableResult();
            return utilities.detailsResult(resultList);
        }

        // GET: api/Result/id
        [HttpGet("{id}")]
        public ClassUtilities.Models.Result Get(int id)
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            ClassUtilities.Models.Result result = utilities.getResultByCode(id);
            result.race = utilities.getNameFromCode(connection, $"SELECT * FROM Race WHERE raceCode={result.race};", 4);
            result.driver = utilities.getNameFromCode(connection, $"SELECT * FROM Driver WHERE driverCode={result.driver};", 4);
            result.team = utilities.getNameFromCode(connection, $"SELECT * FROM Team WHERE teamCode={result.team};", 1);
            return result;
        }

        // POST: api/Country
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Country/IT
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/IT
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}