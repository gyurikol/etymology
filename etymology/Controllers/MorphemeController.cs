﻿// Core
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// Morpheme
using Microsoft.EntityFrameworkCore;
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
            // check if database has items not loaded
            if (context.Morphemes.Count() == 0)
            {
                context.Database.EnsureCreated();
            }

            _context = context;
        }

        // GET: api/morphemes
        [HttpGet]
        public ActionResult<String> GetAll()
        {
            return String.Join("\n", _context.Morphemes.ToList());
        }

        // GET api/morphemes/5
        [HttpGet("{id}", Name = "GetMorpheme")]
        public ActionResult<String> Get(int id)
        {
            var item = _context.Morphemes.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item.ToString();
        }

        // GET api/morphemes/find/{word}
        [Route("check/{word}")]
        public ActionResult<String> Get(String word)
        {
            String loword = word.ToLower();

            List<String> allMorphemes = new List<string>();
            foreach(Morpheme m in _context.Morphemes)
            {
                allMorphemes.AddRange(m.Root.Split(',').ToList());
            }

            return String.Join(',', allMorphemes);
        }

        // POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
