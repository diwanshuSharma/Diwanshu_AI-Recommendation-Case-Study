using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookUserRatingLib
{
    public class User
    {
        public int UserID { get; set; }     
        public int Age { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string country { get; set; }

        List<BookUserRating> BookRatings { get; set; } = new List<BookUserRating>();
    }
}
