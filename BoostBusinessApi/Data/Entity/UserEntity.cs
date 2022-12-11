using System.ComponentModel.DataAnnotations;

namespace BoostBusinessApi.Data.Entity
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
