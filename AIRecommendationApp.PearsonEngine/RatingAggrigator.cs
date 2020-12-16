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
        
        public Dictionary<string, List<int>> Aggrigate(BookDetails bookDetails, Preferance preferance)
        {

            Console.WriteLine("Inside Aggrigate");

            List<User> users = bookDetails.User;

            Dictionary<string, List<int>> Aggrigate = new Dictionary<string, List<int>>();

            int targetAgeGroup = FindAgeGroup(preferance.Age);

            Aggrigate.Add(preferance.ISBN, new List<int>());

            int index = 0;

            Parallel.ForEach(users, user =>
           {
               if (user.State.Equals(preferance.state) && targetAgeGroup == FindAgeGroup(user.Age))
               {
                   //Console.WriteLine("--------------- Found --------------------- ");
                   List<int> ratings = Returnrating(user.UserID, bookDetails.BookUserRatings);

                   Parallel.ForEach(ratings, item =>
                    {
                        Aggrigate[preferance.ISBN].Add(item);
                        //Console.WriteLine(Aggrigate[preferance.ISBN].Count);
                    });

                   index++;
               }
           });

            return Aggrigate;
        }

        private List<int> Returnrating(int UserID, List<BookUserRating> bookUserRatings)
        {
            List<int> ratings = new List<int>();

            foreach (var item in bookUserRatings)
            {
                if (item.User.UserID == UserID && item.Rating != 0)
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
