using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesDB
{
    class Program
    {
        static void Main(string[] args)
        {
            //using(MoviesDBContext context = new MoviesDBContext())
            //{
            //    //Movie = new Movie();
            //    //.Title = "";
            //    //.Genre = "";
            //    //.Runtime = ;

            //    //create movies
            //    Movie one = new Movie();
            //    one.Title = "Halloween";
            //    one.Genre = "Horror";
            //    one.Runtime = 120;

            //    Movie two = new Movie();
            //    two.Title = "The Blob";
            //    two.Genre = "Horror";
            //    two.Runtime = 78;

            //    Movie three = new Movie();
            //    three.Title = "The Exorcist";
            //    three.Genre = "Horror";
            //    three.Runtime = 115;

            //    Movie four = new Movie();
            //    four.Title = "Dune";
            //    four.Genre = "Fantasy";
            //    four.Runtime = 150;

            //    Movie five = new Movie();
            //    five.Title = "Fellowship of the Ring";
            //    five.Genre = "Fantasy";
            //    five.Runtime = 240;

            //    Movie six = new Movie();
            //    six.Title = "Willow";
            //    six.Genre = "Fantasy";
            //    six.Runtime = 125;

            //    Movie seven = new Movie();
            //    seven.Title = "Up";
            //    seven.Genre = "Animated";
            //    seven.Runtime = 98;

            //    Movie eight = new Movie();
            //    eight.Title = "Soul";
            //    eight.Genre = "Animated";
            //    eight.Runtime = 125;

            //    Movie nine = new Movie();
            //    nine.Title = "The Good Dinosaur";
            //    nine.Genre = "Animated";
            //    nine.Runtime = 100;

            //    Movie ten = new Movie();
            //    ten.Title = "Grandmas Boy";
            //    ten.Genre = "Comedy";
            //    ten.Runtime = 98;

            //    //add movies to database
            //    context.Movies.Add(one);
            //    context.Movies.Add(two);
            //    context.Movies.Add(three);
            //    context.Movies.Add(four);
            //    context.Movies.Add(five);
            //    context.Movies.Add(six);
            //    context.Movies.Add(seven);
            //    context.Movies.Add(eight);
            //    context.Movies.Add(nine);
            //    context.Movies.Add(ten);
            //    context.SaveChanges();
            //}

            //display menu/movies and ask if user wishes to search by genre or title
            Console.WriteLine("Welcome to the Movie Information Kiosk");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Please select from the following options.");

            bool runProgram = true;
            while (runProgram)
            {
                Console.WriteLine("1. Search by Genre.");
                Console.WriteLine("2. Search by Title.");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    GenreSearch();
                }
                else if (choice == "2")
                {
                    DisplayMovies();
                    TitleSearch();
                }
                else
                {
                    Console.WriteLine("That was not a valid input. Please select 1 or 2.");
                }

                runProgram = Validator.Validator.getContinue();
            }
        }

        //method to display all movies
        static void DisplayMovies()
        {
            MoviesDBContext context = new MoviesDBContext();
            foreach (Movie i in context.Movies)
            {
                Console.WriteLine($"{i.Title}.");
            }
        }

        //method to search by genre
        static void GenreSearch()
        {
            while (true)
            {
                Console.WriteLine("Enter a genre from the following: Horror/Fantasy/Animated/Comedy ");
                string input = Console.ReadLine().ToLower().Trim();
                MoviesDBContext context = new MoviesDBContext();
                List<Movie> ByGenre = context.Movies.Where(Movie => Movie.Genre == input).ToList();
                if (input == "horror" || input == "fantasy" || input == "animated" || input == "comedy")
                {
                    foreach (Movie m in ByGenre)
                    {
                        Console.WriteLine($" Title: {m.Title}.\n Genre: {m.Genre}.\n Runtime: {m.Runtime}.\n");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("That was not a valid choice.");
                }
            }
        }

        //method to search by title
        static void TitleSearch()
        {
            while (true)
            {
                Console.WriteLine("Please enter a movie title.");
                string input = Console.ReadLine().ToLower().Trim();
                MoviesDBContext context = new MoviesDBContext();
                List<Movie> ByTitle = context.Movies.Where(Movie => Movie.Title == input).ToList();
                if (ByTitle.Count == 0)
                {
                    foreach (Movie m in ByTitle)
                    {
                        Console.WriteLine($" Title: {m.Title}.\n Genre: {m.Genre}.\n Runtime: {m.Runtime}.\n");                        
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("There was no movie title that matched the input.");
                }
            }
        }
    }
}
