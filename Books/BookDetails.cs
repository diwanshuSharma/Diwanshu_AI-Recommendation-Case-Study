using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookUserRatingLib
{
    public class BookDetails 
    {
        public List<Book> Books { get; set; }
        public List<BookUserRating> BookUserRatings { get; set; }
        public List<User> User { get; set; }

    }
}
