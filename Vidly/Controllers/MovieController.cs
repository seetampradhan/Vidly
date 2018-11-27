using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
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
            var movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            return View(movie);
        }

        [Route("movie/ReleaseDate/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(String.Format("Year: {0} / Month : {1}", year, month));
        }

        
    }
}