using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.API.DTOs.Users
{
    public class AddUser
    {

        [Required]
        [MaxLength(MaxLengthHelper.UserFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(MaxLengthHelper.UserUserNameMaxLength)]
        public string UserName { get; set; }

        [Required]
        [MinLength(MinLengthHelper.UserPasswordMinLength)]
        public string Password { get; set; }
        
    }
}
