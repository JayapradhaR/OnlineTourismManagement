using System.ComponentModel.DataAnnotations;

namespace OnlineTourismManagement.Models
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "*Username required")]
        [Display(Name="Username")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Enter valid email id")]
        public string MailId { get; set; }

        [Required(ErrorMessage = "*Password required")]
        [Display(Name="Password")]
        public string Password { get; set; }

        public SignInViewModel()
        {

        }
        public SignInViewModel(string username, string password)
        {
            MailId = username;
            Password = password;
        }
    }
}