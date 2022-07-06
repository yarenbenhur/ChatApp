using ChatApp_Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ChatApp_Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [CustomValidation(typeof(User), "ValidateUserProp")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        
        [CustomValidation(typeof(User), "ValidateUserProp")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return ($"{FirstName} {LastName}");
            }
        }

        [CustomValidation(typeof(User), "ValidateUserProp")]
        [DisplayName("Username")]
        public string UserName { get; set; }


        [CustomValidation(typeof(User), "ValidateUserProp")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        //public List<User> FriendList { get; set; }
        //public ICollection<Friendship> Friendship { get; set; }

        public static ValidationResult ValidateUserProp(string prop, ValidationContext context)
        {
            ValidationResult result = null;

            if (prop== null)
            {
                result = new ValidationResult($"{context.DisplayName} is required.");
            }
           

            return result;
        }

    }
}
