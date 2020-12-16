using BookUserRatingLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoadingOfBook
{
    public class DBLoading : IDataLoader
    {
        public BookDetails Load()
        {
            BookDetails bookDetails = new BookDetails();
            bookDetails.BookUserRatings = GetAllBooksRatedByUser();
            bookDetails.Books = GetAllBooks();
            bookDetails.User = GetAllUsers();

            return bookDetails;
        }

        public List<Book> GetAllBooks()
        {
            List<Book> bookList = new List<Book>();
            string query = "Select * from BXBooks";
            IDbConnection conn = GetConnection.MadeConnection();
            using (conn)
            {
                conn.Open();

                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Book t = new Book();
                    t.ISBN = reader[0].ToString();
                    t.BookTitle = reader[1].ToString();
                    t.BookAuthor = reader[2].ToString();
                    t.YearOfPublication = (int)reader[3];
                    t.Publisher = reader[4].ToString();
                    t.ImageURLS = reader[5].ToString();
                    t.ImageURLM = reader[6].ToString();
                    t.ImageURLL = reader[7].ToString();
                    bookList.Add(t);

                }

            }

            return bookList;
        }

        public List<BookUserRating> GetAllBooksRatedByUser()
        {
            List<BookUserRating> bookRatingList = new List<BookUserRating>();
            string query = $"Select * from BXBookRatings";
            IDbConnection conn = GetConnection.MadeConnection();
            using (conn)
            {
                conn.Open();

                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BookUserRating t = new BookUserRating();
                    t.User.UserID = (int)reader[0];
                    t.Book.ISBN = reader[1].ToString();
                    t.Rating = (int)reader[2];
                    bookRatingList.Add(t);
                }

            }
            return bookRatingList;
        }

        public List<User> GetAllUsers()
        {
            List<User> userList = new List<User>();
            string query = "select * from BXUsers";
            IDbConnection conn = GetConnection.MadeConnection();
            using (conn)
            {
                conn.Open();


                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User t = new User();
                    t.UserID = (int)reader[0];
                    var address = reader[1].ToString().Split(',');
                    t.City = address[0];
                    t.State = address[1];
                    t.Country = address[2];
                    t.Age = reader[2].ToString().Equals("") ? 0 : (int)reader[2];

                    if(t.Age != 0)
                        userList.Add(t);
                }
            }
            return userList;
        }

        public List<BookUserRating> GetTopRatedBooks()
        {
            List<BookUserRating> bookRatingList = new List<BookUserRating>();
            string query = " Select * from BXBookRatings where Bookrating>=9 order by BookRating desc";
            IDbConnection conn = GetConnection.MadeConnection();
            using (conn)
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BookUserRating t = new BookUserRating();
                    t.User.UserID = Int32.Parse(reader[0].ToString());
                    t.Book.ISBN = reader[1].ToString();
                    t.Rating = Int32.Parse(reader[2].ToString());
                    bookRatingList.Add(t);

                }

            }
            return bookRatingList;

        }
    }
}
