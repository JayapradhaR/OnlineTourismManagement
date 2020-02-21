using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineTourismManagement.Entity
{
    public enum Role
    {
        User,
        Admin
    }
    public class UserDetails
    {
        [Required(ErrorMessage = "First name is required")]
        [DataType(DataType.Text, ErrorMessage = "Accept only text")]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter valid name")]
        [MaxLength(30)]
        public string FirstName { get; set; }


        [MaxLength(30)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[6789]\d{9}$", ErrorMessage = "Enter valid phone number")]
        public long MobileNumber { get; set; }

        [Required(ErrorMessage = "Gender required")]
        public string Gender { get; set; }

        [Required(ErrorMessage ="Date of birth required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Mail id required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Enter valid email id")]
        public string MailId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[0-9]+.*)(?=.*[a-zA-Z]+.*)[0-9a-zA-Z]{6,}$", ErrorMessage = "Password must contain at least one letter, at least one number, and be longer than six charaters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm password must be same")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "User role required")]
        public Role UserRole { get; set; }

        public UserDetails() { }

        public UserDetails(string firstName, string lastName, long mobileNumber, string gender,DateTime dateOfBirth, string mailId, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            MobileNumber = mobileNumber;
            Gender = gender;
            DateOfBirth= dateOfBirth;
            MailId = mailId;
            Password = password;
        }
    }
}
