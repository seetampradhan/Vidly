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
            return Content($"Year: {year} / Month : {month}");
        }

        public ActionResult MovieForm()
        {
            var genres = _context.Genres.ToList();

            var movieFormModel = new MovieFormViewModel()
            {
                Genres = genres
            };

            return View(movieFormModel);

        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.MovieAddedDate = DateTime.Now;
                _context.Movies.Add(movie);
                
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.MovieStock = movie.MovieStock;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var movieFormModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", movieFormModel);
        }
    }
}