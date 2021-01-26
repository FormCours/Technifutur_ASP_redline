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
            Console.WriteLine("Liste des genres disponibles :");
            GenreRepository genreRepository = new GenreRepository();
            IEnumerable<Genre> genres = genreRepository.GetAll();
            foreach (Genre g in genres)
            {
                Console.WriteLine($" - {g.Name} (id: {g.Id}");
            }
            Console.WriteLine();

            Console.WriteLine("Ajouter une nouvelle compagnie de production");
            ProductionCompanyRepository compagnyRepository = new ProductionCompanyRepository();

            ProductionCompany company = new ProductionCompany("Disney");
            ProductionCompany compDB   = compagnyRepository.Insert(company);
            Console.WriteLine($" La compagnie \"{compDB.Name}\" a été ajouté avec l'id {compDB.Id}");
            Console.WriteLine();





            
            Console.ReadLine();
        }
    }
}
