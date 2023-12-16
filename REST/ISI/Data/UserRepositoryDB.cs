using ISI.Enums;
using ISI.Models;
using System.Data.SqlClient;

namespace ISI.Data
{
    /// <summary>
    /// This Class is for Connection to DB for User
    /// </summary>
    public class UserRepositoryDB
    {
        private readonly string _connString;

        public UserRepositoryDB(string connectionString) => _connString = connectionString;

        /// <summary>
        /// This Method find User by Email
        /// </summary>
        /// <param name="email">User's Email</param>
        /// <returns>Object Type User</returns>
        public User? FindByEmail(string email)
        {
            User user = new User();

            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            string sql = "SELECT * FROM Users WHERE Email = @email";

            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@email", email);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;

                    user.Id = reader.GetInt32(0);
                    user.Name = reader.GetString(1);
                    user.Username = reader.GetString(2);
                    user.Email = reader.GetString(3);
                    user.Password = reader.GetString(4);
                    user.Role = (Role)Enum.Parse(typeof(Role), reader.GetString(5));
                }
            }

            conn.Close();

            return user;
        }

        /// <summary>
        /// This Method creates User
        /// </summary>
        /// <param name="request">User Email and Password</param>
        /// <returns>Boolean</returns>
        public bool CreateUser(RegistrationRequest request)
        {
            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            string sql = "INSERT INTO Users (Name, Email, Username, Password, Role) VALUES (@name, @email, @username, @password, @role)";

            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@name", request.Name);
                cmd.Parameters.AddWithValue("@email", request.Email);
                cmd.Parameters.AddWithValue("@username", request.Username);
                cmd.Parameters.AddWithValue("@password", request.Password);
                cmd.Parameters.AddWithValue("@role", request.Role.ToString());

                cmd.ExecuteNonQuery();
            }

            conn.Close();

            return true;
        }
    }
}
