using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SSGeek.Web.Models;

namespace SSGeek.Web.DAL
{
    public class ForumPostSqlDAO : IForumPostDAO
    {

        private string connectionString;

        public ForumPostSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<ForumPost> GetAllPosts()
        {
            IList<ForumPost> forum = new List<ForumPost>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT username, subject, message, post_date FROM forum_post", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    forum.Add(MapRowToForumPost(reader));
                }

            }
            return forum;
        }

        public void SaveNewPost(ForumPost post)
        {

            try
            {
                // Create a new connection object
                using (var conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    var sql = $"INSERT into forum_post values(@username,@subject,@message,@post_date)";
                    var cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", post.Username);
                    cmd.Parameters.AddWithValue("@subject", post.Subject);
                    cmd.Parameters.AddWithValue("@message", post.Message);
                    cmd.Parameters.AddWithValue("@post_date", DateTime.Now);

                    // Execute the command
                    var reader = cmd.ExecuteNonQuery();

                }
            }
            catch (SqlException ex)
            {
                throw;
            }

        }

        private ForumPost MapRowToForumPost(SqlDataReader reader)
        {
            return new ForumPost()
            {
                Username = Convert.ToString(reader["username"]),
                Subject = Convert.ToString(reader["subject"]),
                Message = Convert.ToString(reader["message"]),
                PostDate = Convert.ToDateTime(reader["post_date"])
            };
        }

      


        
    }
}
