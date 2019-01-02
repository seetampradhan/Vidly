using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public int GenreId { get; set; }

        [DataType(DataType.Date),Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime MovieAddedDate { get; set; }

        [Required,Display(Name = "Number in Stock")]
        public int MovieStock { get; set; }
    }
}