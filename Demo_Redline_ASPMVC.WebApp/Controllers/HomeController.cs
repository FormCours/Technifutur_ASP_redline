using Demo_Redline_ASPMVC.WebApp.Models;
using Demo_Redline_ASPMVC.WebApp.ServicesData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_Redline_ASPMVC.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            GenreService genreService = new GenreService();
            MovieService movieService = new MovieService();

            HomeIndexViewModel modelHome = new HomeIndexViewModel()
            {
                Genres = genreService.GetAll(),
                LastMovie = movieService.GetLast()
            };

            return View(modelHome);
        }

        public ActionResult Movies()
        {
            MovieService movieService = new MovieService();

            return View(movieService.GetAll());
        }

        public ActionResult AddMovie()
        {
            GenreService genreService = new GenreService();

            HomeAddViewModel modelAdd = new HomeAddViewModel();
            modelAdd.NewMovie = new Movie();
            modelAdd.Genres = genreService.GetAll();

            return View(modelAdd);
        }

        [HttpPost]
        public ActionResult AddMovie(HomeAddViewModel movie)
        {
            if(!ModelState.IsValid)
            {
                GenreService genreService = new GenreService();
                movie.Genres = genreService.GetAll();

                return View(movie);
            }

            //TODO Save in DB !!!!

            return RedirectToAction(nameof(Movies));
        }
    }
}