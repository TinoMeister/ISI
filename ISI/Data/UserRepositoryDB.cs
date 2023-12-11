using ISI.Enums;
using ISI.Models;
using System.Data.SqlClient;

namespace ISI.Data
{
    public class UserRepositoryDB
    {
        private readonly string _connString;

        public UserRepositoryDB(string connectionString) => _connString = connectionString;

        /*
        public IEnumerable<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            string sql = "SELECT * FROM users";

            using (var cmd = new SqlCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    users.Add(new User {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Email = reader.GetString(2),
                        Password = reader.GetString(3),
                        Role = (Role)Enum.Parse(typeof(Role), reader.GetString(4))
                    });
                }
            }

            conn.Close();

            return users;
        }
        */

        public User? FindByEmail(string email)
        {
            User user = new User();

            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            string sql = "SELECT * FROM users WHERE email == @email";

            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@email", email);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;

                    user.Id = reader.GetInt32(0);
                    user.Username = reader.GetString(1);
                    user.Email = reader.GetString(2);
                    user.Password = reader.GetString(3);
                    user.Role = (Role)Enum.Parse(typeof(Role), reader.GetString(4));
                }
            }

            conn.Close();

            return user;
        }

        public bool CreateUser(RegistrationRequest request)
        {
            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            string sql = "INSERT INTO XXX(Email, Username, Password, Role) VALUES(@email, @username, @password, @role)";

            using (var cmd = new SqlCommand(sql, conn))
            {
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
