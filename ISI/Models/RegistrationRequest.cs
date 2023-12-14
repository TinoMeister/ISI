using System.ComponentModel.DataAnnotations;
using ISI.Enums;

namespace ISI.Models;

/// <summary>
/// This Class is for Resgistrarion Request
/// </summary>
public class RegistrationRequest
{
    /// <summary>
    /// User's Name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// User's Email
    /// </summary>
    [Required]
    public string Email { get; set; } = null!;
    
    /// <summary>
    /// User's Username
    /// </summary>
    [Required]
    public string Username { get; set; } = null!;
    
    /// <summary>
    /// User's Password
    /// </summary>
    [Required]
    public string Password { get; set; } = null!;

    /// <summary>
    /// User's Role
    /// </summary>
    public Role Role { get; set; } = Role.User;
}