using Epam.Store.DAL.Interfaces;
using Epam.Store.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
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
                var query = "SELECT Id, Text, CreationDate FROM Reviews"
                    + (orderById ? " ORDER BY Id" : "");

                var command = new SqlCommand(query, _connection);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Review(
                        id: (int)reader["Id"],
                        text: reader["Text"] as string,
                        creationDate: (DateTime)reader["CreationDate"]);

                }
            }

        }

        public bool AddReview(Review review)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.Reviews(Text, CreationDate) " +
                    "VALUES(@Text, @CreationDate)";
                var command = new SqlCommand(query, _connection);

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
                        text: reader["Text"] as string,
                        creationDate: (DateTime)reader["CreationDate"]);
                }

                throw new InvalidOperationException("Cannot find review with ID = " + id);

            }

        }

        public Review CreateNewReviewwithScopeID(string text, DateTime creationDate)
        {
            using(_connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.Reviews(Text, CreationDate) " +
                    "VALUES(@Text, @CreationDate); SELECT CAST(scope_identity() AS INT) AS NewID";
                var command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@Text", text);
                command.Parameters.AddWithValue("@CreationDate", creationDate);

                var result = command.ExecuteScalar();

                if (result != null)
                    return new Review(
                        id: (int)result,
                        text: text,
                        creationDate: creationDate);
                throw new InvalidOperationException(string.Format("Oops {0}, {1};",
                    text, creationDate));

            }
        }
        public void RemoveReview(int id)
        {
            //todo
        }

        public void EditReview(int id, string newText)
        {
            //todo
        }

    } 
}

