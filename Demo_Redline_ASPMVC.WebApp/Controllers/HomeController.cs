﻿using Demo_Redline_ASPMVC.WebApp.CustomAuthorize;
using Demo_Redline_ASPMVC.WebApp.Models;
using Demo_Redline_ASPMVC.WebApp.ServicesData;
using Demo_Redline_ASPMVC.WebApp.Session;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Demo_Redline_ASPMVC.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeIndexViewModel modelHome = new HomeIndexViewModel()
            {
                Genres = GenreService.Instance.GetAll(),
                LastMovie = MovieService.Instance.GetLast()
            };

            return View(modelHome);
        }

        public ActionResult Movies()
        {
            IEnumerable<Movie> movies = MovieService.Instance.GetAll();

            return View(movies);
        }

        [AuthorizeManager(MemberProfil.RoleEnum.Seeder, MemberProfil.RoleEnum.Modo)]
        public ActionResult AddMovie()
        {
            GenreService genreService = GenreService.Instance;

            HomeAddViewModel modelAdd = new HomeAddViewModel();
            modelAdd.NewMovie = new Movie();
            modelAdd.Genres = genreService.GetAll();

            return View(modelAdd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeManager(MemberProfil.RoleEnum.Seeder, MemberProfil.RoleEnum.Modo)]
        public ActionResult AddMovie(HomeAddViewModel movieVM)
        {
            movieVM.Genres = GenreService.Instance.GetAll();
            if(!ModelState.IsValid)
            {
                return View(movieVM);
            }

            // Add genre in Movie
            movieVM.NewMovie.Genres = new List<Genre>();
            if (movieVM.SelectedGenre != null)
            {
                foreach (int id in movieVM.SelectedGenre)
                {
                    Genre g = movieVM.Genres.Single(elem => elem.Id == id);
                    movieVM.NewMovie.Genres.Add(g);
                }
            }

            // Save image in Disk
            if (movieVM.MovieImage != null)
            {
                string fileExt = Path.GetExtension(movieVM.MovieImage.FileName);
                string internalName = "~/Images/" + Guid.NewGuid().ToString() + fileExt;

                string realSavePath = HostingEnvironment.MapPath(internalName);
                movieVM.MovieImage.SaveAs(realSavePath);

                movieVM.NewMovie.Picture = internalName;
            }

            // Save in DB !!!!
            MovieService.Instance.Insert(movieVM.NewMovie);

            return RedirectToAction(nameof(Movies));
        }

        public ActionResult Movie(long? id)
        {
            if(id == null)
            {
                throw new HttpException(400, "Missing movie id !");
                //return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "Missing movie id !");
            }

            Movie movie = MovieService.Instance.Get((long)id);

            if(movie == null)
            {
                throw new HttpException(404, "Not found");
                //return HttpNotFound();
            }

            IEnumerable<Rating> ratings = RatingService.Instance.GetByMovie((long)id);

            HomeMovieViewModel movieVM = new HomeMovieViewModel()
            {
                Movie = movie,
                NewRating = new Rating(),
                Ratings = ratings
            };

            return View(movieVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeManager]
        public ActionResult AddRatingMovie(long? id, HomeMovieViewModel movieVM)
        {
            if (id == null)
            {
                throw new HttpException(400, "Fail for the rating !");
                //return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "Fail for the rating !");
            }

            if(!ModelState.IsValid)
            {
                movieVM.Movie = MovieService.Instance.Get((long)id);
                movieVM.Ratings = RatingService.Instance.GetByMovie((long)id);

                return View(nameof(Movie), movieVM);
            }

            // Update data before save
            movieVM.NewRating.RatingDate = DateTime.Now;
            movieVM.NewRating.Movie = MovieService.Instance.Get((long)id);
            movieVM.NewRating.Member = SessionHelper.Member;

            // Save rating in DB
            RatingService.Instance.Insert(movieVM.NewRating);

            return RedirectToAction(nameof(Movie), new { id = id });
        }

    }
}