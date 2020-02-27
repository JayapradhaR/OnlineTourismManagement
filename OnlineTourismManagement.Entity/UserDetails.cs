using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTourismManagement.Entity
{
    [Table("Customer")]
    public class UserDetails
    {
        [Key]
        [Column("User Id")]
        [Required]
        public int UserId { get; set; }

        [Column("First Name")]
        [Required]
        public string FirstName { get; set; }

        [Column("Last Name")]
        [Required]
        public string LastName { get; set; }

        [Column("Mobile Number")]
        [Required]
        public long MobileNumber { get; set; }

        [Column("Gender")]
        [Required]
        public string Gender { get; set; }

        [Column("Date of birth")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Column("Username")]
        [Required]
        public string MailId { get; set; }

        [Column("Password")]
        [Required]
        public string Password { get; set; }

        private string role = "User";
        [Column("Role")]
        public string UserRole
        {
            get
            {
                return role;
            }
            set
            {
                value = role;
            }
        }
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
