using System.Collections.Generic;
using System.Linq;
using Test.Models;
using Test.Data;
using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{

    [Route("api/v1/[controller]")]
    public class DirectorsController : Controller
    {
        private readonly TestDbContext _context;

        public DirectorsController(TestDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Director>> GetAll() =>
            _context.Directors.ToList();

        //Search by ID
        [HttpGet("{id:int}")]
        public IActionResult GetDirectorById(int id)
        {

            var director = this._context.Directors.SingleOrDefault(ct => ct.Id == id);
            if (director != null)
            {
                return Ok(director);
            }
            else
            {
                return NotFound();
            }

        }

        //AddDirectors
        [HttpPost]
        public IActionResult AddDirectors([FromBody] Director director)
        {

            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            this._context.Directors.Add(director);
            this._context.SaveChanges();
            //return Created($"directors/{director.Id}", director);
            return CreatedAtAction(nameof(AddDirectors), new { id = director.Id }, director);
        }

        //UpdateDirectors
        [HttpPut("{id}")]
        public IActionResult PutDirectors(int id, [FromBody] Director director)
        {

            var target = _context.Directors.FirstOrDefault(ct => ct.Id == id);
            if (target == null)
            {
                return NotFound();
            }
            else
            {
                target.Name = director.Name;
                target.Nationality = director.Nationality;
                target.Age = director.Age;
                target.Active = director.Active;

                _context.Directors.Update(target);
                _context.SaveChanges();
                return NoContent();
            }

        }

        //Delete Directors
        [HttpDelete("{id}")]
        public IActionResult DeleteDirectors(int id)
        {
            var target = _context.Directors.FirstOrDefault(ct => ct.Id == id);
            if (target == null)
            {
                return NotFound();
            }
            else
            {
                if (!this.ModelState.IsValid)
                {
                    return BadRequest();
                }
                else
                {
                    _context.Directors.Remove(target);
                    _context.SaveChanges();
                    return NoContent();
                }
            }
            
        }
    }
}