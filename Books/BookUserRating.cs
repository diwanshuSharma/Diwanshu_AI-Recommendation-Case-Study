using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookUserRatingLib
{
    public class BookUserRating
    {
        /*public int UserID { get; set; }
        public string ISBN { get; set; }*/
        public int Rating { get; set; }
        User UserID { get; set; } 
        Book ISBN { get; set; }


    }
    
}
