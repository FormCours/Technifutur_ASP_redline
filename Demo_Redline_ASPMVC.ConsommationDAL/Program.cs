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
            GenreRepository genreRepo = new GenreRepository();

            Console.WriteLine("GetAll GenreRepository");
            IEnumerable<Genre> genres = genreRepo.GetAll();
            foreach (Genre g in genres)
            {
                Console.WriteLine($"\t {g.Id} - {g.Name}");
            }
            Console.WriteLine();

            Console.WriteLine("Get(3) GenreRepository");
            Genre g3 = genreRepo.Get(3);
            Console.WriteLine($"\t {g3.Id} - {g3.Name}");


            Console.ReadLine();
        }
    }
}
