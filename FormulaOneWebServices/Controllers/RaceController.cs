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
    public class RaceController : ControllerBase
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        public static string THISDATAPATH = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\Data\\";
        public static string DB = "[" + WORKINGPATH + "FormulaOne.mdf]";
        public Utilities utilities = new Utilities(WORKINGPATH, CONNECTION_STRING, THISDATAPATH, DB);

        // GET: api/Race
        [HttpGet]
        public List<ClassUtilities.Models.Race> Get()
        {
            List<ClassUtilities.Models.Race> raceList = utilities.getTableRace();
            return utilities.detailsRace(raceList);
        }

        // GET: api/Race/N
        [HttpGet("{id}")]
        public ClassUtilities.Models.Race Get(int id)
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            ClassUtilities.Models.Race race = utilities.getRaceByCode(id);
            race.circuit = utilities.getNameFromCode(connection, $"SELECT * FROM Circuit WHERE circuitCode={race.circuit};", 2);
            return race;
        }

        // POST: api/Race
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Race/N
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
