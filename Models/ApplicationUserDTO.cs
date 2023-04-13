using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Example.Models;

// DTO stands for Data Transfer Object, and is a simplified class used when transferring data.
// We don't need / want the full ApplicationUser to be transferred.
public class ApplicationUserDto
{
    [Required]
    public string UserName { get; set; } = string.Empty;
    
    [Required]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    public string NickName { get; set; } = string.Empty;
    
    [Range(0, 200)]
    public int Age { get; set; }
    
    [Required]
    public string Password { get; set; } = string.Empty;
}
