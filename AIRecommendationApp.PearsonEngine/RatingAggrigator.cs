using Books;
using BookUserRatingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationApp.PearsonEngine
{

    public class RatingAggrigator : IRatingsAggrigator
    {

        public Dictionary<string, List<int>> Aggrigate(BookDetails bookDetails, Preferance preference)
        {

            Console.WriteLine("Inside Aggrigate");

            Dictionary<string, List<int>> list = new Dictionary<string, List<int>>();

            foreach (var person in bookDetails.User)
            {
                if (person.State.ToLower().Trim().Equals(preference.state.ToLower().Trim()) && FindAgeGroup(person.Age) == FindAgeGroup(preference.Age) && person.Age != 0)
                {
                    foreach (var rating in bookDetails.BookUserRatings)
                    {
                        if (rating.User.UserID == person.UserID && rating.Rating != 0)
                        {
                            if (!list.ContainsKey(rating.Book.ISBN))
                            {
                                List<int> listRating = new List<int>();
                                listRating.Add(rating.Rating);
                                list.Add(rating.Book.ISBN.Trim(), listRating);
                            }
                            else
                            {
                                list[rating.Book.ISBN].Add(rating.Rating);
                            }
                        }
                    }
                    //list.Add(bookDetails.Ratings.Where(rating => rating.User.UserId == person.UserId).ToDictionary(rating => rating.Book.ISBN, rating => rating.Rating));
                };
            }

            // Order By values in dictionary
            //list.OrderBy(o => o.Value.OrderBy(x => x));
            return list;

            /*
            foreach(var book in bookDetails.Books) 
            { 
                if(Aggrigate.ContainsKey(book.ISBN) == false)
                {
                    Aggrigate.Add(book.ISBN, new List<int>());
                    Console.WriteLine("ISBN : " + book.ISBN);
                }

                foreach (var user in users)
                {

                   if (user.State.Equals(preferance.state) && targetAgeGroup == FindAgeGroup(preferance.Age))
                   {
                       //Console.WriteLine("--------------- Found --------------------- ");
                       List<int> ratings = Returnrating(book.ISBN, user.UserID, bookDetails.BookUserRatings);

                       foreach(var item in ratings)
                        {
                            try
                            {

                                Aggrigate[book.ISBN].Add(item);
                                //Console.WriteLine(Aggrigate[book.ISBN].Count);
                            }
                            catch (Exception)
                            {

                            }
                        }

                       index++;
                   }
               }

                var t = Aggrigate[book.ISBN];
                //Console.WriteLine($"{book.ISBN} Count : {t.Count}");
        }
            
            Console.WriteLine("Aggrigate Done !!");
            return Aggrigate;
            */
        }

        private List<int> Returnrating(string isbn, int UserID, List<BookUserRating> bookUserRatings)
        {
            List<int> ratings = new List<int>();

            foreach (var item in bookUserRatings)
            {
                if (isbn.Equals(item.Book.ISBN) && item.User.UserID == UserID && item.Rating != 0)
                    ratings.Add(item.Rating);
            }

            return ratings;
        }
        private int FindAgeGroup(int age)
        {
            if (age < 17)
                return 0;
            if (age < 31)
                return 1;
            if (age < 51)
                return 2;
            if (age < 61)
                return 3;

            return 4;

        }
    }
}
