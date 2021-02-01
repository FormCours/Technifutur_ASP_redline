using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Demo_Redline_ASPMVC.DAL.Repositories;
using Demo_Redline_ASPMVC.WebApp.Models;
using Demo_Redline_ASPMVC.WebApp.Mappers;

namespace Demo_Redline_ASPMVC.WebApp.ServicesData
{
    public class GenreService
    {
        #region Singleton
        private static readonly Lazy<GenreService> _Instance = new Lazy<GenreService>(() => new GenreService());

        public static GenreService Instance
        {
            get { return _Instance.Value; }
        }
        #endregion

        private GenreRepository genreRepository;
        private MovieGenreRepository movieGenreRepository;

        private GenreService()
        {
            genreRepository = new GenreRepository();
            movieGenreRepository = new MovieGenreRepository();
        }

        public IEnumerable<Genre> GetAll()
        {
            //foreach(DAL.Entities.Genre g in genreRepository.GetAll())
            //{
            //    yield return g.ToClient();
            //}

            return genreRepository.GetAll().Select(g => g.ToClient());
        }

        public Genre Get(long id)
        {
            return genreRepository.Get(id).ToClient();
        }

        public IEnumerable<Genre> GetFromMovie(long idMovie)
        {
            foreach (var movieGenre in movieGenreRepository.GetGenreOfMovie(idMovie))
            {
                yield return Get(movieGenre.IdGenre);
            } 
        }

        public Genre Insert(Genre g)
        {
            return genreRepository.Insert(g.ToGlobal()).ToClient();
        }
    }
}