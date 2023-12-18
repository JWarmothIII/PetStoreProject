using System.ComponentModel.DataAnnotations;

namespace PetStore.Shared.Entities
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[!@#$%^&*])(?=.{6,})", ErrorMessage = "Password must be at least 6 characters and contain at least one uppercase letter and one special character")]
        public string? Password { get; set; }


        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public required string? LastName { get; set; }

        [Required(ErrorMessage = "Street Address is required")]
        public required string? StreetAddress { get; set; }

        [Required(ErrorMessage = "City is required")]
        public required string? City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public required string? State { get; set; }

        [Required(ErrorMessage = "Zip Code is required")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Zip Code must be 5 digits")]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "Please enter a valid phone number")]
        public string? PhoneNumber { get; set; }

        public required string? Role { get; set; }
        public string? History { get; set; }
        public string? Cart { get; set; }
    }
}