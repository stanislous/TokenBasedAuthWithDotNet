using System.ComponentModel.DataAnnotations;

namespace TokenBasedAuthWithDotNet.Models;

public class UserCredential
{
    [Required]
    [Display(Name = "Email")]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
}