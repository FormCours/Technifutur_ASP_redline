﻿using Demo_Redline_ASPMVC.DAL.Repositories;
using Demo_Redline_ASPMVC.WebApp.ServicesData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using C = Demo_Redline_ASPMVC.WebApp.Models;
using G = Demo_Redline_ASPMVC.DAL.Entities;

namespace Demo_Redline_ASPMVC.WebApp.Mappers
{
    public static class MovieMapper
    {
        public static C.Movie ToClient(this G.Movie global)
        {
            if (global == null) return null;

            String company = MovieService.Instance.GetCompanyFromMovie(global.IdProductionCompany);

            List<C.Genre> genres = GenreService.Instance.GetFromMovie(global.Id).ToList();

            return new C.Movie()
            {
                Id = global.Id,
                Title = global.Title,
                Resume = global.Resume,
                Duration = global.Duration,
                ReleaseDate = global.ReleaseDate,
                ProductionCompany = company,
                Genres= genres,
                Picture = global.Picture
            };
        }
    }
}