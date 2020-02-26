using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTourismManagement.Entity
{
    public enum Role
    {
        User=1,
        Admin
    }
    [Table("Customer")]
    public class UserDetails
    {
        [Key]
        public int UserId { get; set; }
      
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public long MobileNumber { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
        
        public string MailId { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public Role UserRole { get; set; }

        public UserDetails() { }

        public UserDetails(string firstName, string lastName, long mobileNumber, string gender,DateTime dateOfBirth, string mailId, string password,Role role)
        {
            FirstName = firstName;
            LastName = lastName;
            MobileNumber = mobileNumber;
            Gender = gender;
            DateOfBirth= dateOfBirth;
            MailId = mailId;
            Password = password;
            UserRole = role;
        }
    }
}
