using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;

namespace AuthorStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new AuthorRepo();
            var authors = repo.GetAuthors();

            //-How many books are collaborations(have more than one author)?

            List<Book> allBooks = authors
                            .SelectMany(x => x.Books)
                            .ToList();

            List<IGrouping<int, Book>> colaborationBooks = allBooks
                            .GroupBy(x => x.ID)
                            .Where(group => group.Count() > 1)
                            .Select(el => el)
                            .ToList();

            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($"The number of books that have multiple authors is: '{colaborationBooks.Count}'.");
            Console.WriteLine("----------------------------------------------------------------------");



            //-Which book has the most authors(and how many) ?

            int bookWithMostAuthorsNumberOfAuthors = allBooks
                                        .GroupBy(x => x.ID)
                                        .OrderByDescending(g => g.Count())
                                        .FirstOrDefault()
                                        .Count();

            int bookWithMostAuthorsID = allBooks
                                        .GroupBy(x => x.ID)
                                        .OrderByDescending(g => g.Count())
                                        .FirstOrDefault()
                                        .Key;

            Book theBookWithMostAuthors = allBooks
                                        .FirstOrDefault(x => x.ID == bookWithMostAuthorsID);

            Console.WriteLine($"The Book with Most Authors is: '{theBookWithMostAuthors.Title}' and has '{bookWithMostAuthorsNumberOfAuthors}' Authors.");
            Console.WriteLine("----------------------------------------------------------------------");


            //-What author wrote most collaborations ? "

            Author authorWithMostBooks = authors
                            .OrderByDescending(aut => aut.Books
                            .Where(x => colaborationBooks
                            .Any(g => g.Key == x.ID))
                            .Count())
                            .FirstOrDefault();


            int numberOfColaborationBookByAuthor = authorWithMostBooks.Books
                                        .Where(x => colaborationBooks
                                        .Any(g => g.Key == x.ID))
                                        .Count();


            Console.WriteLine($"The Author With Most Colaboration Books is: '{authorWithMostBooks.Name}' with total of: '{numberOfColaborationBookByAuthor}' Books");
            Console.WriteLine("----------------------------------------------------------------------");




            //-In what year were published most books in a specific genre? Which genre ?



            //-Which author has most books nominated for an award?




            Author mostNominatedAuthor = authors
                            .FirstOrDefault(a => a.Books
                            .Select(x => x.Nominations)
                            .Sum() == authors
                            .Select(au => au.Books
                            .Select(a => a.Nominations).Sum())
                            .Max());

            int mostBookNominations = mostNominatedAuthor.Books
                                    .Where(b => b.Nominations > 0)
                                    .Count();


            Console.WriteLine($"The Author with Most Book Award Nomination is: '{mostNominatedAuthor.Name} with '{mostBookNominations}' Books ");
            Console.WriteLine("----------------------------------------------------------------------");

            //-Which author has most books that won an award ?

            Author mostAwardedAuthor = authors
                            .FirstOrDefault(a => a.Books
                            .Where(x => x.Wins > 0)
                            .Count() == authors
                            .Select(au => au.Books
                            .Where(a => a.Wins > 0).Count())
                            .Max());

            int mostBookWins = mostNominatedAuthor.Books
                                .Where(b => b.Wins > 0)
                                .Count();

            Console.WriteLine($"The Author with Most Awarded Books is: '{mostAwardedAuthor.Name} with '{ mostBookWins}' Wins ");
            Console.WriteLine("----------------------------------------------------------------------");

            //-Which author has most books nominated for an award, without winning a single award ?

            List<Author> authorsWithNoWins = authors
                                    .Where(x => x.Wins == 0)
                                    .ToList();

            Author authorWithMostNominations = authorsWithNoWins
                                            .OrderByDescending(x=>x.Nominations)
                                            .FirstOrDefault();

            Console.WriteLine($"The Author that has most books nominated for an award, without winning a single award Books is: '{authorWithMostNominations.Name}' with '{authorWithMostNominations.Nominations}' nominations and '{ authorWithMostNominations.Wins}' Wins.");
            Console.WriteLine("----------------------------------------------------------------------");

            //-Make a histogram of books published per decade per genre.
            //- Which author has a highest percentage of nominated books ?

        }
    }
}
