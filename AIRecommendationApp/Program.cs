using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLoadingOfBook;
using BookUserRatingLib;
using AIRecommendationApp.PearsonEngine;
using Books;
using System.Threading;

namespace AIRecommendationApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadLine();

            
            RatingAggrigator ratingAggrigator = new RatingAggrigator();
            Preferance preferance = new Preferance();
            preferance.ISBN = "0452282152";
            preferance.Age = 16;
            preferance.state = "new york";

            List<Book> books = new List<Book>();

            AIRecommendationEngine aIRecommendationEngine = new AIRecommendationEngine();

            Thread task = new Thread(() => {
                books = aIRecommendationEngine.Recommend(preferance, 10);
            });
            
            task.Start();
            task.Join();

            
            Console.WriteLine("Relative Books\n");
            foreach (var item in books)
            {
                Console.WriteLine(item.BookTitle);
            }            

            DBLoading dBLoading = new DBLoading();
            BookDetails bookDetails1 = dBLoading.Load();

            //ans = ratingAggrigator.Aggrigate(bookDetails1, preferance);

            //for (int i = 0; i < ans["0195153448"].Count; i++)
            //{
            //    Console.WriteLine(ans["0195153448"][0]);
            //}

            Console.WriteLine("done !!");
            Console.ReadLine();
        }
    }
}
