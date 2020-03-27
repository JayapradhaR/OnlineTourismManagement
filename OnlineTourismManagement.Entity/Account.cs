using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineTourismManagement.Entity
{
    [Table("Customer")]
    public class Account
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        public long MobileNumber { get; set; }

        [Required]
        [MaxLength(6)]
        public string Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Column("Username")]
        [Required]
        [MaxLength(64)]
        [Index(IsUnique = true)]
        public string MailId { get; set; }

        [Column("Password")]
        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        [Column("Role")]
        [MaxLength(10)]
        [Required]
        public string UserRole{get;set;}

        public Account() { }

        public Account(string firstName, string lastName, long mobileNumber, string gender,DateTime dateOfBirth, string mailId, string password)
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
