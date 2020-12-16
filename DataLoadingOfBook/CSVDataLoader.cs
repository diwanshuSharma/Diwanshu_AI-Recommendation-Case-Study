using BookUserRatingLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoadingOfBook
{
    public class CSVDataLoader : IDataLoader
    {
        public BookDetails Load()
        {
            BookDetails bookDetails = new BookDetails();

            bookDetails.Books = LoadBooks();
            bookDetails.BookUserRatings = LoadBookUserRating();
            bookDetails.User = LoadUser();

            return bookDetails;
        }

        private List<User> LoadUser()
        {
            User user = null;

            char[] ss = new char[2];
            ss[0] = '\\';
            ss[1] = '"';

            List<User> users = new List<User>();

            using (var reader = new StreamReader(@"BXUsers.csv"))
            {
                user = new User();
                reader.ReadLine();

                int count = 0;

                while (!reader.EndOfStream && count < 3000)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    user.UserID = int.Parse(values[0].ToString().Trim(ss));
                    var address = values[1].Split(',');
                    user.City = address[0].ToString().Trim(ss);
                    user.State = address[1].ToString().Trim(ss);
                    user.Country = address[2].ToString().Trim(ss);

                    string agess = values[2].ToString().Trim(ss);

                    if (agess != null && agess[0] >= '1' && agess[0] <= '9')
                    {
                        user.Age = int.Parse(values[2].ToString().Trim(ss));

                        count++;
                        users.Add(user);
                    }

                }
                
            }

            return users;
        }

        private List<BookUserRating> LoadBookUserRating()
        {
            char[] ss = new char[2];
            ss[0] = '\\';
            ss[1] = '"';

            BookUserRating bookUserRating = null;

            List<BookUserRating> bookUserRatings = new List<BookUserRating>();

            using (var reader = new StreamReader(@"BXBookRatings.csv"))
            {
                bookUserRating = new BookUserRating();
                reader.ReadLine();

                int count = 0;

                while (!reader.EndOfStream && count < 3000)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    bookUserRating.User.UserID= int.Parse(values[0].ToString().Trim(ss));
                    bookUserRating.Book.ISBN = values[1].ToString().Trim(ss);
                    bookUserRating.Rating = int.Parse(values[2].ToString().Trim(ss));

                    bookUserRatings.Add(bookUserRating);

                    count++;
                }
                
            }
            return bookUserRatings;
        }

        private List<Book> LoadBooks()
        {
            Book book = null;
            List<Book> books = new List<Book>(); 

            using (var reader = new StreamReader(@"BXBooks.csv"))
            {
                char[] ss = new char[2];
                ss[0] = '\\';
                ss[1] = '"';

                book = new Book();
                reader.ReadLine();

                int data = 0;

                while (!reader.EndOfStream && data < 3000)
                {

                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    book.ISBN = values[0].ToString().Trim(ss);
                    book.BookTitle = values[1].ToString().Trim(ss);
                    book.BookAuthor = values[2].ToString().Trim(ss);
                    
                    string temp = values[3].ToString().Trim(ss);
                    Console.WriteLine(temp);
                    
                    if (temp[0] >= '1' && temp[0] <= '9')
                    {
                        book.YearOfPublication = Int32.Parse(temp);
                        book.Publisher = values[4].ToString().Trim(ss);
                        book.ImageURLL = values[5].ToString().Trim(ss);
                        book.ImageURLM = values[6].ToString().Trim(ss);
                        book.ImageURLS = values[7].ToString().Trim(ss);

                        data++;
                        books.Add(book);
                    }
                }

                return books;
            }

        }
    }
}
