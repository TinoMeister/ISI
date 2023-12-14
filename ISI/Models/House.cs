namespace ISI.Models
{
    /// <summary>
    /// This class represents a Home
    /// </summary>
    public class House
    {
        /// <summary>
        /// House's Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// House's Name
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// House's Id
        /// </summary>
        public int UserId { get; set; }
    }
}
