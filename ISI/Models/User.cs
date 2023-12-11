using ISI.Enums;

namespace ISI.Models;

/// <summary>
/// This Class is for User
/// </summary>
public class User
{
    /// <summary>
    /// User's Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// User's Email
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// User's Username
    /// </summary>
    public string Username { get; set; } = null!;

    /// <summary>
    /// User's Password
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// User's Role
    /// </summary>
    public Role Role { get; set; } = Role.User;
}