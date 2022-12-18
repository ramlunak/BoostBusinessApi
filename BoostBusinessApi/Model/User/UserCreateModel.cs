using System.ComponentModel.DataAnnotations;

namespace BoostBusinessApi.Model.User
{
    public class UserCreateModel
    {
        [MinLength(5, ErrorMessage = ErrorCode.min_value_invalid)]
        [Required]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = ErrorCode.email_invalid)]
        [Required]
        public string Email { get; set; }
        public UserCreateModel(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
