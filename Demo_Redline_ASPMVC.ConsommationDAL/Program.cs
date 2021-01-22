using Demo_Redline_ASPMVC.DAL.Entities;
using Demo_Redline_ASPMVC.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Redline_ASPMVC.ConsommationDAL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("GetAll GenreRepository");
            GenreRepository genreRepo = new GenreRepository();

            IEnumerable<Genre> genres = genreRepo.GetAll();
            foreach (Genre g in genres)
            {
                Console.WriteLine($"\t {g.Id} - {g.Name}");
            }


            Console.ReadLine();
        }
    }
}
