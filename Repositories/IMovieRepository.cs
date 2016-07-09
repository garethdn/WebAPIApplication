using System.Collections.Generic;
using WebAPIApplication.Models;

namespace WebAPIApplication.Repositories
{
    public interface IMovieRepository
    {
        void Add(Movie item);
        IEnumerable<Movie> GetAll();
        Movie Find(int id);
        Movie Remove(int id);
        void Update(Movie item);
    }
}