using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookUserRatingLib;
using Books;
using DataLoadingOfBook;
using System.Collections;

namespace AIRecommendationApp.PearsonEngine
{

public class AIRecommendationEngine
    {
        
        public List<Book> Recommend(Preferance preferece,int limit)
        {

            Console.WriteLine("Inside Recommender !!");

            List<Book> books = new List<Book>();
            Dictionary<string, double> correlations = new Dictionary<string, double>();

            IDataLoader dataLoader = new CSVDataLoader();
            BookDetails bookDetails = dataLoader.Load();

            IRatingsAggrigator ratingsAggrigator = new RatingAggrigator();
            Dictionary<string, List<int>> keyValuePairs = ratingsAggrigator.Aggrigate(bookDetails, preferece);


            MathNetPearsonRecommendationEngine mathNetPearsonRecommendationEngine = null;

            foreach (var isbn in keyValuePairs.Keys)
            {
                mathNetPearsonRecommendationEngine = new MathNetPearsonRecommendationEngine();
                
                if (!isbn.Equals(preferece.ISBN))
                {
                    double correlation = 0;

                    if (keyValuePairs.ContainsKey(preferece.ISBN))
                        correlation = mathNetPearsonRecommendationEngine.GetCorrelation(keyValuePairs[preferece.ISBN], keyValuePairs[isbn]);

                    //Console.WriteLine(correlation);


                    if (!correlation.ToString().Equals("NaN"))
                    {
                        correlations.Add(isbn, correlation);
                    }
                }
            }

            correlations = correlations.OrderByDescending(o => o.Value).ToDictionary(o => o.Key, o => o.Value);


            //int count = 0;

            int i = 0;
            foreach (var isbn in correlations.Keys)
            {
                if (i++ > limit)
                {
                    break;
                }
                books.AddRange(bookDetails.Books.Where(book => book.ISBN.Trim().ToLower().Equals(isbn.Trim().ToLower())));
            }

            Console.WriteLine("Recommender Exited !!");

            return books;
        }
    }
}
