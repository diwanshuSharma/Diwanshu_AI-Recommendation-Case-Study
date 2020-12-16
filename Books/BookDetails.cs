using System.Collections.Generic;

namespace BookUserRatingLib
{
    public class BookDetails
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<BookUserRating> BookUserRatings { get; set; } = new List<BookUserRating>();
        public List<User> User { get; set; } = new List<User>();
    }
}
