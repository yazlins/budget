namespace budget.Models;

using System.ComponentModel.DataAnnotations;

public class Session
{
    public Session() { }

    public Session(string username, string password)
    {
        Username = username;
        Password = password;
    }

    [Display(Name = "Username")]
    [Required(ErrorMessage = "The username is required")]
    [StringLength(50, ErrorMessage = "The username must be between 3 and 50 characters", MinimumLength = 3)]
    public string Username { get; set; }

    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "The user password is required")]
    [MinLength(8, ErrorMessage = "The password must be at least 8 characters long")]
    public string Password { get; set; }
}

