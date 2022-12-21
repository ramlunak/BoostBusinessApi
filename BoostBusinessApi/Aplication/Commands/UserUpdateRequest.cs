using BoostBusinessApi.Model;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BoostBusinessApi.Aplication.Commands
{
    public class UserUpdateRequest : IRequest<ApiModelResponse>
    {
        public int Id { get; set; }


        [MinLength(5, ErrorMessage = ErrorCode.min_value_invalid)]
        [Required]
        public string Name { get; set; }


        [EmailAddress(ErrorMessage = ErrorCode.email_invalid)]
        [Required]
        public string Email { get; set; }
    }
}
