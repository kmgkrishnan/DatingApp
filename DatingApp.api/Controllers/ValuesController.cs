using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.api.Data;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public DataContext _context { get; }
        public ValuesController(DataContext context)
        {
            _context = context;

        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var values = _context.Values.ToList();
            return Ok(values);
            // throw new Exception("Error Occured");
            // return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _context.Values.FirstOrDefault( x => x.Id == id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
