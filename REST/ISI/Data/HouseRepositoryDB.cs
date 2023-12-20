using ISI.Enums;
using ISI.Models;
using System.Data.SqlClient;

namespace ISI.Data
{
    /// <summary>
    /// This Class is for Connection to DB for House
    /// </summary>
    public class HouseRepositoryDB
    {
        private readonly string _connString;

        /// <summary>
        /// Constructor for HouseRepositoryDB class.
        /// </summary>
        /// <param name="connectionString">The database connection string.</param>
        public HouseRepositoryDB(string connectionString) => _connString = connectionString;

        /// <summary>
        /// This Method gets all Houses
        /// </summary>
        /// <returns>List of Houses</returns>
        public IEnumerable<House> GetAllHouses()
        {
            List<House> houses = new List<House>();

            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            string sql = "SELECT * FROM Houses";

            using (var cmd = new SqlCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    houses.Add(new House
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        UserId = reader.GetInt32(2)
                    });
                }
            }

            conn.Close();

            return houses;
        }

        /// <summary>
        /// This Method gets all the Houses by User
        /// </summary>
        /// <param name="idUser">User's Id</param>
        /// <returns>List of Houses</returns>
        public IEnumerable<House> GetHousesByUser(int idUser)
        {
            List<House> houses = new List<House>();

            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            string sql = "SELECT * FROM Houses WHERE UserId = @idUser";

            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@idUser", idUser);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        houses.Add(new House
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            UserId = reader.GetInt32(2)
                        });
                    }
                }
            }

            conn.Close();

            return houses;
        }

        /// <summary>
        /// This Method creates a new House
        /// </summary>
        /// <param name="house">The House object to be created.</param>
        /// <returns>Boolean indicating success.</returns>
        public bool CreateHouse(House house)
        {
            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            string sql = "INSERT INTO Houses (name, UserId) VALUES (@name, @userId)";

            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@name", house.Name);
                cmd.Parameters.AddWithValue("@userId", house.UserId);

                cmd.ExecuteNonQuery();
            }

            conn.Close();

            return true;
        }

        /// <summary>
        /// This Method Updates a House
        /// </summary>
        /// <param name="house">The House object to be updated.</param>
        /// <returns>Boolean indicating success.</returns>
        public bool UpdateHouse(House house)
        {
            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            string sql = "UPDATE Houses " +
                "SET Name = @name, UserId = @userId " +
                "WHERE Id = @id";

            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", house.Id);
                cmd.Parameters.AddWithValue("@name", house.Name);
                cmd.Parameters.AddWithValue("@userId", house.UserId);

                cmd.ExecuteNonQuery();
            }

            conn.Close();

            return true;
        }

        /// <summary>
        /// This Method deletes a House
        /// </summary>
        /// <param name="id">House's Id</param>
        /// <returns>Boolean indicating success.</returns>
        public bool DeleteHouse(int id)
        {
            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            string sql = "DELETE FROM Houses " +
                "WHERE Id = @id";

            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }

            conn.Close();

            return true;
        }
    }
}
