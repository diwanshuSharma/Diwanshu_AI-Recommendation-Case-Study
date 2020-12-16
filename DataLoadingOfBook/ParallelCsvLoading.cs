using BookUserRatingLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoadingOfBook
{
    public class ParallelCsvLoading : IDataLoader
    {
        BookDetails bookDetails = null;
        public BookDetails Load()
        {

            bookDetails = new BookDetails();
            Task booksTask = new Task(LoadBooks);
            Task booksDetailsTask = new Task(LoadBookUserRating);
            Task UserDetailsTask = new Task(LoadUser);
            booksTask.Start();
            booksDetailsTask.Start();
            UserDetailsTask.Start();
            booksTask.Wait();
            booksDetailsTask.Wait();
            UserDetailsTask.Wait();
            return bookDetails;
        }

        private void LoadUser()
        {
            User user = null;

            using (var reader = new StreamReader(@"C:\Users\kitra\source\repos\Kartik-Kumar\AI-Recommendation-Case-Study\Data\BX-Users.csv"))
            {
                user = new User();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    user.UserID = int.Parse(values[0]);
                    var address = values[1].Split(',');
                    user.City = address[0];
                    user.State = address[1];
                    user.Country = address[2];
                    user.Age = int.Parse(values[2]);
                }
                bookDetails.User.Add(user);
            }

        }

        private void LoadBookUserRating()
        {
            BookUserRating bookUserRating = null;
            using (var reader = new StreamReader(@"C:\Users\kitra\source\repos\Kartik-Kumar\AI-Recommendation-Case-Study\Data\BX-Book-Ratings.csv"))
            {
                bookUserRating = new BookUserRating();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    bookUserRating.User.UserID = int.Parse(values[0]);
                    bookUserRating.Book.ISBN = values[1];
                    bookUserRating.Rating = int.Parse(values[2]);
                }
                bookDetails.BookUserRatings.Add(bookUserRating);
            }
        }

        private void LoadBooks()
        {
            Book book = null;
            using (var reader = new StreamReader(@"C:\Users\kitra\source\repos\Kartik-Kumar\AI-Recommendation-Case-Study\Data\BX-Books.csv"))
            {
                book = new Book();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    book.ISBN = values[0];
                    book.BookTitle = values[1];
                    book.BookAuthor = values[2];
                    book.YearOfPublication = int.Parse(values[3]);
                    book.Publisher = values[4];
                    book.ImageURLL = values[5];
                    book.ImageURLM = values[6];
                    book.ImageURLS = values[7];
                }
                bookDetails.Books.Add(book);
            }

        }
    }
}
