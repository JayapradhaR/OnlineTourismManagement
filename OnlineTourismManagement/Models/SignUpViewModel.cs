using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using OnlineTourismManagement.Common;

namespace OnlineTourismManagement.Models
{
    
    public class SignUpViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "*First name is required")]
        [DataType(DataType.Text, ErrorMessage = "Accepts only text")]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter valid name")]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "*Phone number required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[6789]\d{9}$", ErrorMessage = "Enter valid phone number")]
        public long MobileNumber { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "*Gender required")]
        public string Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "*Date of birth required")]
        [ValidateAge(10,75)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Mail Id")]
        [Required(ErrorMessage = "*Mail id required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Enter valid email id")]
        [Remote("IsAlreadyRegistered","Account", HttpMethod = "POST", ErrorMessage ="Email id already registered")]
        public string MailId { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "*Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{7,}$",ErrorMessage ="Enter valid password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "*Confirm password is required")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password and Confirm password must be same")]
        public string ConfirmPassword { get; set; }

        public SignUpViewModel() { }

        public SignUpViewModel(string firstName, string lastName, long mobileNumber, string gender, DateTime dateOfBirth, string mailId, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            MobileNumber = mobileNumber;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            MailId = mailId;
            Password = password;
        }
    }
}
