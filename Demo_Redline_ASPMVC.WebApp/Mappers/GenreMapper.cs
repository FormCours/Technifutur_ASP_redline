using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using G = Demo_Redline_ASPMVC.DAL.Entities;
using C = Demo_Redline_ASPMVC.WebApp.Models;

namespace Demo_Redline_ASPMVC.WebApp.Mappers
{
    public static class GenreMapper
    {
        public static C.Genre ToClient(this G.Genre global)
        {
            return new C.Genre()
            {
                Id = global.Id,
                Name = global.Name
            };
        }

        public static G.Genre ToGlobal(this C.Genre client)
        {
            return new G.Genre(client.Name)
            {
                Id = client.Id
            };
        }

    }
}