using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassUtilities;
using System.Data;

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
            return utilities.getTableTeamsResult();
        }

        // GET: api/TeamsResult/id
        [HttpGet("{id}")]
        public ClassUtilities.Models.TeamsResult Get(int id)
        {
            return utilities.getTeamsResultByCode(id);
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