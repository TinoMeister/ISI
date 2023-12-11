namespace ISI.Models
{
    /// <summary>
    /// This Class is for Authentication Response
    /// </summary>
    public class AuthResponse
    {
        /// <summary>
        /// User's Token
        /// </summary>
        public string Token { get; set; } = null!;

        /// <summary>
        /// Token Expiration
        /// </summary>
        public DateTime Expiration { get; set; }
    }
}
