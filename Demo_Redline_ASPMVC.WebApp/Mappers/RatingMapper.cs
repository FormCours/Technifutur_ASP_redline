using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using C = Demo_Redline_ASPMVC.WebApp.Models;
using G = Demo_Redline_ASPMVC.DAL.Entities;

namespace Demo_Redline_ASPMVC.WebApp.Mappers
{
    public static class RatingMapper
    {
        public static G.Rating ToGlobal(this C.Rating client)
        {
            if (client == null) return null;

            return new G.Rating(
                client.Score,
                client.Comment,
                client.RatingDate,
                client.IdMovie,
                client.IdMember
            );
        }

        public static C.Rating ToClient(this G.Rating global)
        {
            if (global == null) return null;

            return new C.Rating()
            {
                Id = global.Id,
                Score = global.Score,
                Comment = global.Comment,
                RatingDate = global.RatingDate,
                IdMovie = global.IdMovie,
                IdMember = global.IdMember
            };
        }

    }
}