using BookUserRatingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoadingOfBook
{
    public class DBLoading : IDataLoader
    {
        public BookDetails Load()
        {
           
        }

        public List<BXBook> GetAllBooks()
        {
            List<BXBook> bookList = new List<BXBook>();
            string query = "Select * from BXBooks";
            IDbConnection conn = ForConnection.GetConnection();
            using (conn)
            {
                conn.Open();

                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BXBook t = new BXBook();
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

        public List<BXBookRating> GetAllBooksRatedByUser(int id)
        {
            List<BXBookRating> bookRatingList = new List<BXBookRating>();
            string query = $"Select * from BXBookRatings where Userid = {id}";
            IDbConnection conn = ForConnection.GetConnection();
            using (conn)
            {
                conn.Open();

                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BXBookRating t = new BXBookRating();
                    t.Userid = (int)reader[0];
                    t.ISBN = reader[1].ToString();
                    t.BookRating = (int)reader[2];
                    bookRatingList.Add(t);
                }

            }
            return bookRatingList;
        }

        public List<BXUser> GetAllUsers()
        {
            List<BXUser> userList = new List<BXUser>();
            string query = "select * from BXUsers";
            IDbConnection conn = ForConnection.GetConnection();
            using (conn)
            {
                conn.Open();


                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BXUser t = new BXUser();
                    t.UserID = (int)reader[0];
                    t.Location = reader[1].ToString();
                    t.Age = reader[2].ToString().Equals("") ? 0 : (int)reader[2];
                    userList.Add(t);
                }
            }
            return userList;
        }

        public List<BXBookRating> GetTopRatedBooks()
        {
            List<BXBookRating> bookRatingList = new List<BXBookRating>();
            string query = " Select * from BXBookRatings where Bookrating>=9 order by BookRating desc";
            IDbConnection conn = ForConnection.GetConnection();
            using (conn)
            {
                conn.Open();
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    BXBookRating t = new BXBookRating();
                    t.Userid = (int)reader[0];
                    t.ISBN = reader[1].ToString();
                    t.BookRating = (int)reader[2];
                    bookRatingList.Add(t);

                }

            }
            return bookRatingList;

        }
    }
}
