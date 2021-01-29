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

            HomeViewModel modelHome = new HomeViewModel()
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
    }
}