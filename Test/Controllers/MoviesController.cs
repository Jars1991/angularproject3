using System.Collections.Generic;
using System.Linq;
using Test.Models;
using Test.Data;
using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{

    [Route("api/v1/[controller]")]
    public class MoviesController : Controller
    {
        private readonly TestDbContext _context;

        public MoviesController(TestDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Movie>> GetAll() =>
            _context.Movies.ToList();

        //Search by ID
        [HttpGet("{id:int}")]
        public IActionResult GetMovieById(int id)
        {

            var movie = this._context.Movies.SingleOrDefault(ct => ct.Id == id);
            if (movie != null)
            {
                return Ok(movie);
            }
            else
            {
                return NotFound();
            }

        }

        //AddMovies
        [HttpPost]
        public IActionResult AddMovies([FromBody] Movie movie)
        {

            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            this._context.Movies.Add(movie);
            this._context.SaveChanges();
            return CreatedAtAction(nameof(AddMovies), new { id = movie.Id }, movie);
        }

        //UpdateMovies
        [HttpPut("{id}")]
        public IActionResult PutMovies(int id, [FromBody] Movie movie)
        {

            var target = _context.Movies.FirstOrDefault(ct => ct.Id == id);
            if (target == null)
            {
                return NotFound();
            }
            else
            {
                target.Name = movie.Name;
                target.ReleaseYear = movie.ReleaseYear;
                target.Gender = movie.Gender;
                target.Duration = movie.Duration;
                // target.DirectorId = movie.DirectorId;

                _context.Movies.Update(target);
                _context.SaveChanges();
                return NoContent();
            }

        }

        //Delete Movies
        [HttpDelete("{id}")]
        public IActionResult DeleteMovies(int id)
        {
            var target = _context.Movies.FirstOrDefault(ct => ct.Id == id);
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
                    _context.Movies.Remove(target);
                    _context.SaveChanges();
                    return NoContent();
                }
            }

        }
    }
}