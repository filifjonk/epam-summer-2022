using Epam.Store.DAL.Interfaces;
using Epam.Store.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Store.DAL
{
    public class ReviewSqlDAO : IReviewDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        private static SqlConnection _connection = new SqlConnection(_connectionString);

        public IEnumerable<Review> GetReviews(bool orderById = true)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var stProc = "Reviews_GetReviews";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Review(
                        id: (int)reader["Id"],
                        shop_name: reader["Shop_name"] as string,
                        text: reader["Text"] as string,
                        creationDate: (DateTime)reader["CreationDate"]);

                }
            }

        }

        public IEnumerable<User> GetUsers(bool orderById = true)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var stProc = "User_GetUsers";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User(
                        id: (int)reader["Id_user"],
                        name: reader["Name"] as string,
                        birth: (DateTime)reader["Birth"],
                        text: reader["Mail"] as string);
                    
                }
            }

        }

        public bool AddReview(Review review)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var stProc = "Reviews_AddReview";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Shop_name", review.Shop_name);
                command.Parameters.AddWithValue("@Text", review.Text);
                command.Parameters.AddWithValue("@CreationDate", review.CreationDate);

                _connection.Open();

                var result = command.ExecuteNonQuery();//kolichestvo zatronutih kortezhey

                return result > 0;
            }
        }

        public Review GetReview(int id)
        {
            using(_connection = new SqlConnection(_connectionString))
            {
                var stProc = "Reviews_GetById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if(reader.Read())
                {
                    return new Review(
                        id: (int)reader["Id"],
                        shop_name: reader["Shop_name"] as string,
                        text: reader["Text"] as string,
                        creationDate: (DateTime)reader["CreationDate"]);
                }

                throw new InvalidOperationException("Cannot find review with ID = " + id);

            }

        }

        //public Review CreateNewReviewwithScopeID(string text, DateTime creationDate)
        //{
        //    using(_connection = new SqlConnection(_connectionString))
        //    {
        //        var query = "INSERT INTO dbo.Reviews(Text, CreationDate) " +
        //            "VALUES(@Text, @CreationDate); SELECT CAST(scope_identity() AS INT) AS NewID";
        //        var command = new SqlCommand(query, _connection);

        //        command.Parameters.AddWithValue("@Text", text);
        //        command.Parameters.AddWithValue("@CreationDate", creationDate);

        //        var result = command.ExecuteScalar();

        //        if (result != null)
        //            return new Review(
        //                id: (int)result,

        //                text: text,
        //                creationDate: creationDate);
        //        throw new InvalidOperationException(string.Format("Oops {0}, {1};",
        //            text, creationDate));

        //    }
        //}
        public bool RemoveReview(int id) //only for admin-role
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "dbo.Reviews_RemoveReview";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@id", id);

                _connection.Open();

                var result = command.ExecuteNonQuery();

                return result > 0;
            }
        }

        public bool EditReview(int id, string str)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "dbo.Reviews_EditReview";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Change", str);


                _connection.Open();
                var result = command.ExecuteNonQuery();

                return (result > 0);
            }
        }

        public bool EditUserName(string mail, string newName)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "dbo.User_EditUserName";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@mail", mail);
                command.Parameters.AddWithValue("@newName", newName);


                _connection.Open();
                var result = command.ExecuteNonQuery();

                return (result > 0);
            }
        }

        public bool EditUserMail(string mail, string newMail)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "dbo.User_EditUserMail";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@mail", mail);
                command.Parameters.AddWithValue("@newMail", newMail);


                _connection.Open();
                var result = command.ExecuteNonQuery();

                return (result > 0);
            }
        }

        public string CheckEnter(string log, string pas)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "dbo.Account_data_CheckEnter";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@log", log);
                command.Parameters.AddWithValue("@pas", pas);
                command.Parameters.AddWithValue("@role", "nofind");

                _connection.Open();
                var result = command.ExecuteScalar();
  
                return Convert.ToString(result);
            }
        }

        public IEnumerable<Review> FindByShopName(string name)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var strProc = "dbo.Reviews_FindByShopName";

                var command = new SqlCommand(strProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@name", name);
                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Review(
                        id: (int)reader["Id"],
                        shop_name: reader["Shop_name"] as string,
                        text: reader["Text"] as string,
                        creationDate: (DateTime)reader["CreationDate"]);

                }

            }
        }

    } 
}

