using System.Collections.Generic;
using WebAPIApplication.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using WebAPIApplication.Models;

namespace WebAPIApplication.Repositories
{
    public class MovieRepository : IMovieRepository
    {

        private WebAPIApplicationDbContext _dbContext;

        public MovieRepository(WebAPIApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _dbContext.Movies
                .Include(movie => movie.Genres)
                    .ThenInclude(mg => mg.Genre)
                .ToList();
        }

        public void Add(Movie item)
        {
            _dbContext.Movies.Add(item);
            _dbContext.SaveChanges();
        }

        public Movie Find(int id)
        {
            return _dbContext.Movies
                .Include(movie => movie.Genres)
                    .ThenInclude(mg => mg.Genre)
                .FirstOrDefault(m => m.Id == id);
        }

        public Movie Remove(int id)
        {
            Movie item;
            // _movies.TryGetValue(id, out item);
            // _movies.TryRemove(id, out item);
            // return item;
            item = this.Find(id);
            _dbContext.Remove(item);
            return item;
        }

        public void Update(Movie item)
        {
            // _movies[item.Id] = item;
        }

    }
}