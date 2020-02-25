using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTourismManagement.Models
{
    public class UserSignIn
    {
        [Required(ErrorMessage = "Username required")]
        public string MailId { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

        public UserSignIn()
        {

        }
        public UserSignIn(string username, string password)
        {
            MailId = username;
            Password = password;
        }
    }
}