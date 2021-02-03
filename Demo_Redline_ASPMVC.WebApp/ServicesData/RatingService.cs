using Demo_Redline_ASPMVC.DAL.Repositories;
using Demo_Redline_ASPMVC.WebApp.Mappers;
using Demo_Redline_ASPMVC.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_Redline_ASPMVC.WebApp.ServicesData
{
    public class RatingService
    {
        #region Singleton
        private static readonly Lazy<RatingService> _Instance = new Lazy<RatingService>(() => new RatingService());

        public static RatingService Instance
        {
            get { return _Instance.Value; }
        }
        #endregion

        private RatingRepository ratingRepository;

        private RatingService()
        {
            ratingRepository = new RatingRepository();
        }

        public long Insert(Rating rating)
        {
            return ratingRepository.Insert(rating.ToGlobal()).Id;
        }
    }
}