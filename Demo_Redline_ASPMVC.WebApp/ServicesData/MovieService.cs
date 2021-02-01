using Demo_Redline_ASPMVC.DAL.Repositories;
using Demo_Redline_ASPMVC.WebApp.Mappers;
using Demo_Redline_ASPMVC.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Redline_ASPMVC.WebApp.ServicesData
{
    public class MovieService
    {
        #region Singleton
        private static readonly Lazy<MovieService> _Instance = new Lazy<MovieService>(() => new MovieService());

        public static MovieService Instance
        {
            get { return _Instance.Value; }
        }
        #endregion

        MovieRepository movieRepository;
        ProductionCompanyRepository companyRepository;
        MovieGenreRepository movieGenreRepository;

        private MovieService()
        {
            movieRepository = new MovieRepository();
            companyRepository = new ProductionCompanyRepository();
            movieGenreRepository = new MovieGenreRepository();
        }

        public string GetCompanyFromMovie(long IdProductionCompany)
        {
            return companyRepository.Get(IdProductionCompany).Name;
        }

        public Movie GetLast()
        {
            return movieRepository.GetLastInsert().ToClient();
        }

        public IEnumerable<Movie> GetAll()
        {
            return movieRepository.GetAll().Select(m => m.ToClient());
        }
    }
}