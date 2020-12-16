using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookUserRatingLib
{
    public class Book
    {
        public string ISBN { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public int YearOfPublication { get; set; }
        public string Publisher { get; set; }
        public string ImageURLS { get; set; }
        public string ImageURLM { get; set; }
        public string ImageURLL { get; set; }

        List<BookUserRating> BookRatings { get; set; } = new List<BookUserRating>();
    }
}

/*"ISBN"; "Book-Title"; "Book-Author"; "Year-Of-Publication"; "Publisher"; "Image-URL-S"; "Image-URL-M"; "Image-URL-L"
"0195153448"; "Classical Mythology"; "Mark P. O. Morford"; "2002"; "Oxford University Press"; "http://images.amazon.com/images/P/0195153448.01.THUMBZZZ.jpg"; "http://images.amazon.com/images/P/0195153448.01.MZZZZZZZ.jpg"; "http://images.amazon.com/images/P/0195153448.01.LZZZZZZZ.jpg"*/