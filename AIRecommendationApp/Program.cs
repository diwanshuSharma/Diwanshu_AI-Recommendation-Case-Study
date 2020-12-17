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
using System.Runtime.Caching;

namespace AIRecommendationApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadLine();

            
            RatingAggrigator ratingAggrigator = new RatingAggrigator();
            Preferance preferance = new Preferance();
            //preferance.ISBN = "0452282152";
            //preferance.Age = 16;
            //preferance.state = "new york";
            preferance.state = "California";
            preferance.Age = 10;
            preferance.ISBN = "0452282152";

            List<Book> books = new List<Book>();

            AIRecommendationEngine aIRecommendationEngine = new AIRecommendationEngine();

            Thread task = new Thread(() => {
                books = aIRecommendationEngine.Recommend(preferance, 10);
            });
            
            task.Start();
            task.Join();

            Preferance preferance1 = new Preferance();
            preferance1.state = "California";
            preferance1.Age = 25;
            preferance1.ISBN = "0452282152";

            List<Book> books1 = new List<Book>();

            AIRecommendationEngine aIRecommendationEngine1 = new AIRecommendationEngine();

            Thread task1 = new Thread(() => {
                books1 = aIRecommendationEngine1.Recommend(preferance1, 10);
            });

            task1.Start();
            task1.Join();
            



            Console.WriteLine("Relative Books\n");
            foreach (var item in books)
            {
                Console.WriteLine(item.BookTitle);
            }

            //DBLoading dBLoading = new DBLoading();
            //BookDetails bookDetails1 = dBLoading.Load();

            Console.WriteLine("Relative Books\n");
            foreach (var item in books1)
            {
                Console.WriteLine(item.BookTitle);
            }

            Console.WriteLine("done !!");
            Console.ReadLine();
        }
    }
}
