using Entity_Movie_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Movie_Database
{
    public class MovieCRUD
    {
        public MovieContext db { get; set; } = new MovieContext();

        //Method to populate movies in database
        //Already called in to populate database
        public void PopulateMovieList()
        {
            List<Movie> movieList = new List<Movie>();

            movieList.Add(new Movie() { Title = "The Godfather", Genre = "Drama", Runtime = 175 });
            movieList.Add(new Movie() { Title = "The Shawshank Redemption", Genre = "Drama", Runtime = 142 });
            movieList.Add(new Movie() { Title = "Schindler's List", Genre = "Drama", Runtime = 195 });
            movieList.Add(new Movie() { Title = "The Wizard of Oz", Genre = "Fantasy", Runtime = 102 });
            movieList.Add(new Movie() { Title = "Psycho", Genre = "Horror", Runtime = 109 });
            movieList.Add(new Movie() { Title = "Star Wars: Episode IV = A New Hope", Genre = "Sci-Fi", Runtime = 121 });
            movieList.Add(new Movie() { Title = "The Exorcist", Genre = "Horror", Runtime = 122 });
            movieList.Add(new Movie() { Title = "Some Like It Hot", Genre = "Comedy", Runtime = 195 });
            movieList.Add(new Movie() { Title = "The Lord of the Rings: The Fellowship of the Ring", Genre = "Fantasy", Runtime = 201 });
            movieList.Add(new Movie() { Title = "Gladiator", Genre = "Action", Runtime = 155 });
            movieList.Add(new Movie() { Title = "Titanic", Genre = "Romance", Runtime = 194 });
            movieList.Add(new Movie() { Title = "The Apartment", Genre = "Romance", Runtime = 130 });
            movieList.Add(new Movie() { Title = "The Apartment", Genre = "Romance", Runtime = 90 });
            movieList.Add(new Movie() { Title = "Jurassic Park", Genre = "Sci-Fi", Runtime = 127 });
            movieList.Add(new Movie() { Title = "The Great Dictator", Genre = "Comedy", Runtime = 125 });

            foreach (Movie movie in movieList)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
            }
        }

        //Method containing all of the code for the program's main functionality.
        //To be called by main after initializing an instance of MovieCRUD there.
        public void StartProgram()
        {
            bool runAgain = true;

            MovieContext db = new MovieContext();

            List<Movie> movies = db.Movies.ToList();


            Console.WriteLine("Howdy there! Welcome to Big Jim's discount Blockbuster!\n");

            Console.WriteLine("We have several used movies available for rent at the low low price of FREE.\n");

            while (runAgain)
            {
                Console.WriteLine("Well, would you like to search for a movie to watch by 'title', or by 'genre'?\n");

                string input = Console.ReadLine().ToLower();

                if (input == "genre")
                {
                    PrintGenreList();

                    string input2 = Console.ReadLine().ToLower();

                    List <Movie> genreList = SearchByGenre(input2, movies);

                    PrintMovies(genreList);
                } 
                else if (input == "title")
                {
                    Console.WriteLine("\nWell, what title would you like to search for?\n");

                    string input3 = Console.ReadLine().ToLower();

                    List<Movie> titleList = SearchByTitle(input3, movies);

                    PrintMovies(titleList);
                } 
                else
                {
                    Console.WriteLine("\nUmm...What'd you say? Let's try that again.\n");
                    continue;
                }

                runAgain = askAgain();
            } 
        }



        //Method to iterate through avaiable films by GENRE and return a list to be printed
        public List <Movie> SearchByGenre(string userInput, List <Movie> Allmovies)
        {

            List <Movie> genreList = Allmovies.Where(n => n.Genre.ToLower() == userInput).ToList();

            return genreList;
        }

        //Method to iterate through available films by TITLE and return a list to be printed.
        public List<Movie> SearchByTitle(string userInput, List<Movie> Allmovies)
        {

            List<Movie> titleList = Allmovies.Where(n => n.Title.ToLower() == userInput).ToList();

            return titleList;
        }

        //Method to show available genres for selection to user.
        //Might mitigate some confusion when typing in selection.
        public void PrintGenreList()
        {
            Console.WriteLine("\nHere are the genres we have to choose from: \n");
            Console.WriteLine("-Drama\n");
            Console.WriteLine("-Action\n");
            Console.WriteLine("-Romance\n");
            Console.WriteLine("-Sci-fi\n");
            Console.WriteLine("-Fantasy\n");
            Console.WriteLine("-Horror\n");
            Console.WriteLine("-Comedy\n");

            Console.WriteLine("Type the genre you'd like to view below:\n ");
        }

        //Method to iterate over a movie list, printing all movies contained within that list.
        public void PrintMovies(List<Movie> movieList)
        {
            Console.WriteLine("\nAvailable Movies in Database: \n");

            foreach (Movie movie in movieList)
            {
                Console.WriteLine($"{movie.Id,-8}Title: {movie.Title,-25} Genre: {movie.Genre,-15}Runtime: {movie.Runtime}");
            }

            Console.WriteLine();
        }

        //Method to ask if user would like to continue
        public bool askAgain()
        {
            Console.WriteLine("\nWould you like to search for movies again? Y/N\n");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                Console.WriteLine("\nOkay, great!\n");
                return true;
            }
            else if (input == "n")
            {
                Console.WriteLine("\nThaks for coming in to Big Jim's! See you next time!\n");
                return false;
            }
            else
            {
                Console.WriteLine("\nI didn't catch that. Please try again.\n");
                return askAgain();
            }
        }
    }
}
