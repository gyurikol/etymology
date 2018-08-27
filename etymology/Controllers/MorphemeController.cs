// Core
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// Morpheme
using etymology.Models.dbContext;
using etymology.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace etymology.Controllers
{
    /// <summary>
    /// Morpheme controller.
    /// </summary>
    [Route("api/morphemes")]
    [ApiController]
    public class MorphemeController : ControllerBase
    {
        private readonly MorphemeContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:etymology.Controllers.MorphemeController"/> class.
        /// </summary>
        public MorphemeController(MorphemeContext context) {
            _context = context;

            // if empty for testing
            if (_context.Morphemes.Count() == 0)
            {
                _context.Morphemes.Add(new Morpheme("a", new List<string> { "toward" }, Morpheme.MorphemeOrigin.Latin));
                _context.Morphemes.Add(new Morpheme("-able", new List<string> { "Adjective: worth, ability" }, Morpheme.MorphemeOrigin.Greek));
                _context.Morphemes.Add(new Morpheme("-fy", new List<string> { "make, form into" }, Morpheme.MorphemeOrigin.Latin));
                _context.SaveChanges();
            }
        }

        // GET: api/values
        [HttpGet]
        public String GetAll()
        {
            return String.Join("\n", _context.Morphemes.ToList() );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
