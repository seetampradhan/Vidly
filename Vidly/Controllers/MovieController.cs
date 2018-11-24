using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Sherk!" };
            var customer = new List<Custmore>
            {
                new Custmore { Id =1, Name="Seetam" },
                new Custmore { Id = 2, Name="Agni" }
            };

            var randomMovie = new RandomMovieViewModel()
            {
                Movie = movie,
                Custmores = customer
            };

            return View(randomMovie);

        }

        public ActionResult Index()
        {
            var movies = GetMovie();
            return View(movies);
        }

        [Route("movie/ReleaseDate/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(String.Format("Year: {0} / Month : {1}", year, month));
        }

        private IEnumerable<Movie> GetMovie()
        {
            var movies = new List<Movie>
            {
                new Movie(){Id=1, Name = "Sherk" },
                new Movie(){Id=2, Name = "Wall-e"}
            };

            return movies;
        }
    }
}