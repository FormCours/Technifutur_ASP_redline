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
            GenreRepository genreRepository = new GenreRepository();
            ProductionCompanyRepository companyRepository = new ProductionCompanyRepository();
            MovieGenreRepository movieGenreRepository = new MovieGenreRepository();
            MovieRepository movieRepository = new MovieRepository();
            
            
            Console.WriteLine("Liste des genres disponibles :");
            IEnumerable<Genre> genres = genreRepository.GetAll();
            foreach (Genre g in genres)
            {
                Console.WriteLine($" - {g.Name} (id: {g.Id})");
            }
            Console.WriteLine();

            /*
            //Console.WriteLine("Ajouter une nouvelle compagnie de production");
            ProductionCompany company = new ProductionCompany("Lucasfilm");
            ProductionCompany compDB = companyRepository.Insert(company);
            Console.WriteLine($" La compagnie \"{compDB.Name}\" a été ajouté avec l'id {compDB.Id}");
            Console.WriteLine();

            Console.WriteLine("Liste des compagnies de production :");
            foreach (ProductionCompany c in companyRepository.GetAll())
            {
                Console.WriteLine($" - {c.Name} (id: {c.Id})");
            }
            */

            /*
            Console.WriteLine("Ajouter une nouvelle compagnie de production");
            Console.WriteLine(" - Movie");
            long idProdSW4 = companyRepository.GetAll().Single(cp => cp.Name == "Lucasfilm").Id;
            Movie movie = new Movie(
                "Star Wars IV",
                "C'est le premier opus de la saga Star Wars par sa date de sortie, mais le quatrième selon l'ordre chronologique de l'histoire. Il est le premier volet de la trilogie originale qui est constituée également des films L'Empire contre-attaque et Le Retour du Jedi. Ce film est aussi le troisième long métrage réalisé par Lucas.",
                125,
                new DateTime(1977, 10, 19),
                idProdSW4
            );

            Console.WriteLine(" - Ajout du Genre => Science-fiction");
            long genreSW4 = genreRepository.Insert(new Genre("Science-fiction")).Id;

            Console.WriteLine(" - Ajout du film et de son genre");
            long idSW4 = movieRepository.Insert(movie).Id;

            movieGenreRepository.Insert(new MovieGenre(idSW4, genreSW4));
            */

            /*
            long idProdMarmotte = companyRepository.Insert(new ProductionCompany("Columbia Pictures")).Id;
            long idG1Marmotte = genreRepository.GetAll().Single(g => g.Name == "Comedy").Id;
            long idG2Marmotte = genreRepository.GetAll().Single(g => g.Name == "Romance").Id;
            long idG3Marmotte = genreRepository.Insert(new Genre("Fantastic")).Id;

            Movie marmotte = new Movie(
                "Le Jour de la marmotte (VQ)",
                null,
                101,
                null,
                idProdMarmotte
            );

            long idMarmotte = movieRepository.Insert(marmotte).Id;
            movieGenreRepository.Insert(new MovieGenre(idMarmotte, idG1Marmotte));
            movieGenreRepository.Insert(new MovieGenre(idMarmotte, idG2Marmotte));
            movieGenreRepository.Insert(new MovieGenre(idMarmotte, idG3Marmotte));
            */

            Console.WriteLine("Les films disponibles :");
            IEnumerable<Movie> movies = movieRepository.GetAll();

            foreach (Movie m in movies)
            {
                ProductionCompany pc = companyRepository.Get(m.IdProductionCompany);

                string movieDuration = (m.Duration != null) ? $"{m.Duration} min" : "Unknown";
                string movieRelease = m.ReleaseDate?.ToString("dd MMM yyyy") ?? "Unknown";

                Console.WriteLine($" - Film : {m.Title}");
                Console.WriteLine($"   Durée : {movieDuration}");
                Console.WriteLine($"   Production : {pc.Name}");
                Console.WriteLine($"   Date de sortie : {movieRelease}");

                Console.WriteLine("   Genres : ");
                IEnumerable<MovieGenre> mgs = movieGenreRepository.GetAll().Where(elem => elem.IdMovie == m.Id);
                foreach (MovieGenre mg in mgs)
                {
                    Genre movieGenre = genreRepository.Get(mg.IdGenre);
                    Console.WriteLine($"    > {movieGenre.Name}");
                }
                Console.WriteLine();
            }


            Console.ReadLine();
        }
    }
}
