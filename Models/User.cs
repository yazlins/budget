namespace budget.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    public User(){}

    public User(string name, string username, string password)
    {
        Name = name;
        Username = username;
        Password = password;
    }

    public int Id { get; set; }

    [Display(Name = "Name")]
    [Required(ErrorMessage = "The user name is required")]
    public string Name { get; set; }

    [Display(Name = "Email")]
    [Required(ErrorMessage = "The user email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

    [Display(Name = "Username")]
    [Required(ErrorMessage = "The username is required")]
    [StringLength(50, ErrorMessage = "The username must be between 3 and 50 characters", MinimumLength = 3)]
    public string Username { get; set; }   
    
    //public string PasswordHash { get; set; }

    //[NotMapped]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "The user password is required")]
    [MinLength(8, ErrorMessage = "The password must be at least 8 characters long")]
    public string Password { get; set; }

    [NotMapped]
    [Display(Name = "Confirm password")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Confirmation password is required")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
    public string ConfirmPassword { get; set; }

}

