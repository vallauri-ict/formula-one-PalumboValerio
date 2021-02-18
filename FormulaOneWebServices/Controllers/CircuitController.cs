using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassUtilities;
using System.IO;

namespace FormulaOneWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircuitController : ControllerBase
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        public static string THISDATAPATH = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\Data\\";
        public static string DB = "[" + WORKINGPATH + "FormulaOne.mdf]";
        public Utilities utilities = new Utilities(WORKINGPATH, CONNECTION_STRING, THISDATAPATH, DB);

        // GET: api/Circuit
        [HttpGet]
        public List<ClassUtilities.Models.Circuit> Get()
        {
            return utilities.getTableCircuit();
        }

        // GET: api/Circuit/N
        [HttpGet("{id}")]
        public ClassUtilities.Models.Circuit Get(int id)
        {
            return utilities.getTableCircuitByCode(id);
        }

        // POST: api/Circuit
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Circuit/N
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
