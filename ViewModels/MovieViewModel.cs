using System.ComponentModel.DataAnnotations;

namespace WebAPIApplication.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        [RequiredAttribute]
        [MinLengthAttribute(3)]
        public string Name { get; set; }
        [RequiredAttribute]
        public int Year { get; set; }
        public string Summary { get;set; }
        [RequiredAttribute]
        public decimal Rating { get; set; }
    }
}