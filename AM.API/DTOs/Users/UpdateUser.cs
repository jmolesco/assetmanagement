using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.API.DTOs.Users
{
    public class UpdateUser
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthHelper.UserFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(MaxLengthHelper.UserUserNameMaxLength)]
        public string UserName { get; set; }

        public string Password { get; set; }

    }
}
