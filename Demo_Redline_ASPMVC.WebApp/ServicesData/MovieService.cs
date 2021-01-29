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
        MovieRepository movieRepository;
        ProductionCompanyRepository companyRepository;

        public MovieService()
        {
            movieRepository = new MovieRepository();
            companyRepository = new ProductionCompanyRepository();
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