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
    public class TeamsResultController : ControllerBase
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        public static string THISDATAPATH = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\Data\\";
        public static string DB = "[" + WORKINGPATH + "FormulaOne.mdf]";
        public Utilities utilities = new Utilities(WORKINGPATH, CONNECTION_STRING, THISDATAPATH, DB);

        // GET: api/TeamsResult
        [HttpGet]
        public List<ClassUtilities.Models.TeamsResult> Get()
        {
            List<ClassUtilities.Models.TeamsResult> teamsResultList = utilities.getTableTeamsResult();
            return utilities.detailsTeamsResult(teamsResultList);
        }

        // GET: api/TeamsResult/id
        [HttpGet("{id}")]
        public ClassUtilities.Models.TeamsResult Get(int id)
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            ClassUtilities.Models.TeamsResult teamsResult = utilities.getTeamsResultByCode(id);
            teamsResult.race = utilities.getNameFromCode(connection, $"SELECT * FROM Race WHERE raceCode={teamsResult.race};", 4);
            teamsResult.team = utilities.getNameFromCode(connection, $"SELECT * FROM Team WHERE teamCode={teamsResult.team};", 1);
            return teamsResult;
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