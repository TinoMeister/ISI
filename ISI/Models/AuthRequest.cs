namespace ISI.Models
{
    /// <summary>
    /// This Class is for Authentication Request
    /// </summary>
    public class AuthRequest
    {
        /// <summary>
        /// User's Email
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// User's Password
        /// </summary>
        public string Password { get; set; } = null!;
    }
}
