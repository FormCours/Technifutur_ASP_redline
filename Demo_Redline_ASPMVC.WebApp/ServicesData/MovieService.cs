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

        public Movie Get(long id)
        {
            return movieRepository.Get(id).ToClient();
        }

        public Movie GetLast()
        {
            return movieRepository.GetLastInsert().ToClient();
        }

        public IEnumerable<Movie> GetAll()
        {
            return movieRepository.GetAll().Select(m => m.ToClient());
        }

        public void Insert(Movie movie)
        {
            // Recup ou ajout de la compagnie de production
            DAL.Entities.ProductionCompany companyDB = companyRepository.GetAll().SingleOrDefault(cp => cp.Name == movie.ProductionCompany);

            if (companyDB == null)
            {
                DAL.Entities.ProductionCompany newCompany = new DAL.Entities.ProductionCompany(movie.ProductionCompany);
                companyDB = companyRepository.Insert(newCompany);
            }

            // Ajout du film
            DAL.Entities.Movie newMovie = new DAL.Entities.Movie(
                movie.Title,
                movie.Resume,
                movie.Duration,
                movie.ReleaseDate,
                companyDB.Id,
                movie.Picture
            );
            DAL.Entities.Movie movieDB = movieRepository.Insert(newMovie);

            // Ajout des genres du film
            foreach (Genre genre in movie.Genres)
            {
                // Dans notre cas, les genres sont deja connus en DB. Sinon, il aurait été necessaire de les ajouter en DB avant!
                movieGenreRepository.Insert(new DAL.Entities.MovieGenre(movieDB.Id, genre.Id));
            }
        }
    }
}