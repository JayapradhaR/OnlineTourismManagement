using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineTourismManagement.Models
{
    
    public class SignUpViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        [DataType(DataType.Text, ErrorMessage = "Accepts only text")]
        [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Enter valid name")]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Phone number required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[6789]\d{9}$", ErrorMessage = "Enter valid phone number")]
        public long MobileNumber { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender required")]
        public string Gender { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of birth required")]
        //[Range(typeof(DateTime),(DateTime.Now.Date.AddYears(-100).ToString(),DateTime.Now.Date.ToString())]
       // [RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Invalid date format.")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Mail Id")]
        [Required(ErrorMessage = "Mail id required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Enter valid email id")]
        public string MailId { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{7,}$",ErrorMessage ="Enter valid password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "*Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm password must be same")]
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
