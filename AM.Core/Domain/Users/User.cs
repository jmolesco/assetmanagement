using AM.Core.Helper.Lengths;
using System.ComponentModel.DataAnnotations;

namespace AM.Core.Domain.Users
{
    public class User : BaseDomain
    {

        [MaxLength(MaxLengthHelper.UserFullNameMaxLength)]
        public string FullName { get; set; }

        [MaxLength(MaxLengthHelper.UserUserNameMaxLength)]
        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

    }
}
