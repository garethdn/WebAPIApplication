using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPIApplication.Models;
using WebAPIApplication.ViewModels;
using WebAPIApplication.Data;

using WebAPIApplication.Repositories;
using System;

namespace WebAPIApplication.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private WebAPIApplicationDbContext _dbContext;
        public MoviesController(IMovieRepository movies,
            WebAPIApplicationDbContext dbContext)
        {
            Movies = movies;
            _dbContext = dbContext;
        }
        public IMovieRepository Movies { get; set; }

        // GET api/movies
        [HttpGet]
        public IEnumerable<Movie> GetAll()
        {
            return Movies.GetAll();
        }

        // GET api/movies/5
        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult GetById(int id)
        {
            var movie = Movies.Find(id);
            
            if (movie == null)
            {
                return NotFound();
            }
            return new ObjectResult(movie);
        }

        // POST api/movies
        [HttpPost]
        public IActionResult Create([FromBody]MovieViewModel movie)
        {
            if (movie == null)
            {
                return BadRequest();
            }
            // Movies.Add(movie);

            Movie m = new Movie();

            m.Name = movie.Name;
            m.ReleaseDate = new DateTime(movie.Year, 0, 0);
            m.Summary = movie.Summary;
            m.Rating = movie.Rating;

            Movies.Add(m);            

            return CreatedAtRoute("GetMovie", new { controller = "Movies", id = movie.Id }, movie);
        }

        // PUT api/movies/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Movie movie)
        {
            if (movie == null || movie.Id != id)
            {
                return BadRequest();
            }

            // if (movies.Find(user.Id) == null)
            // {
            //     return NotFound();
            // }

            Movies.Update(movie);

            return new NoContentResult();
        }

        // DELETE api/movies/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Movies.Remove(id);
        }

    }
}
