using System;
using System.Collections.Generic;

namespace WebAPIApplication.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Summary { get;set; }
        public decimal Rating { get; set; }
        public List<MovieGenre> Genres { get; set; }
    }
}