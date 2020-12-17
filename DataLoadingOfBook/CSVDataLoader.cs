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
        static double MAX = 99999;
        public BookDetails Load()
        {
            BookDetails bookDetails = new BookDetails();

            Task taskBook = new Task(() => {
                bookDetails.Books = LoadBooks();
            });

            Task taskRating = new Task(() => {
                bookDetails.BookUserRatings = LoadBookUserRating();
            });

            Task taskUser = new Task(() => {
                bookDetails.User = LoadUser();
            });

            taskBook.Start();
            taskRating.Start();
            taskUser.Start();

            taskBook.Wait();
            taskRating.Wait();
            taskUser.Wait();

            return bookDetails;
        }

        private List<User> LoadUser()
        {
            User user = null;

            char[] ss = new char[3];
            ss[0] = '\\';
            ss[1] = '"';
            ss[2] = ' ';

            List<User> users = new List<User>();

            using (var reader = new StreamReader(@"BX-Users.csv"))
            {
                reader.ReadLine();

                double count = 0;

                while (!reader.EndOfStream && count < MAX)
                {
                    try
                    {
                        user = new User();
                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        user.UserID = int.Parse(values[0].ToString().Trim(ss));
                        var address = values[1].Split(',');
                        user.City = address[0].ToString().Trim(ss);

                        if (address[1] != "" && address[1] != null)
                            user.State = address[1].ToString().Trim(ss);
                        else
                            continue;

                        if (address[2] != "" && address[2] != null)
                            user.Country = address[2].ToString().Trim(ss);
                        else
                            continue;

                        string agess = values[2].ToString().Trim(ss);

                        if (agess != null && agess[0] >= '1' && agess[0] <= '9')
                        {
                            user.Age = int.Parse(values[2].ToString().Trim(ss));

                            count++;
                            users.Add(user);
                        }
                    }
                    catch(Exception)
                    {

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

            using (var reader = new StreamReader(@"BX-Book-Ratings.csv"))
            {
              
                reader.ReadLine();

                double count = 0;

                while (!reader.EndOfStream && count < MAX)
                {
                    try
                    {
                        bookUserRating = new BookUserRating();
                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        bookUserRating.User.UserID = int.Parse(values[0].ToString().Trim(ss));
                        bookUserRating.Book.ISBN = values[1].ToString().Trim(ss);
                        bookUserRating.Rating = int.Parse(values[2].ToString().Trim(ss));

                        bookUserRatings.Add(bookUserRating);

                        count++;
                    }
                    catch (Exception)
                    {

                    }
                }
                
            }
            return bookUserRatings;
        }

        private List<Book> LoadBooks()
        {
            Book book = null;
            List<Book> books = new List<Book>(); 

            using (var reader = new StreamReader(@"BX-Books.csv"))
            {
                char[] ss = new char[2];
                ss[0] = '\\';
                ss[1] = '"';

                
                reader.ReadLine();

                double count = 0;

                while (!reader.EndOfStream && count < MAX)
                {
                    try
                    {
                        book = new Book();
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        book.ISBN = values[0].ToString().Trim(ss);
                        book.BookTitle = values[1].ToString().Trim(ss);
                        book.BookAuthor = values[2].ToString().Trim(ss);

                        string temp = values[3].ToString().Trim(ss);
                        //Console.WriteLine("Print " + temp);

                        if (temp != null && temp != "" && temp[0] >= '1' && temp[0] <= '9')
                        {
                            book.YearOfPublication = Int32.Parse(temp);
                            book.Publisher = values[4].ToString().Trim(ss);
                            book.ImageURLL = values[5].ToString().Trim(ss);
                            book.ImageURLM = values[6].ToString().Trim(ss);
                            book.ImageURLS = values[7].ToString().Trim(ss);

                            count++;
                            books.Add(book);
                        }
                    }
                    catch (Exception)
                    {

                    }
                }

                return books;
            }

        }
    }
}
