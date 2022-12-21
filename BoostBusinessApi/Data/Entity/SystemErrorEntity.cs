using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoostBusinessApi.Data.Entity
{
    public class SystemErrorEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string? Message { get; set; }

        [Column(TypeName = "varchar(2000)")]
        public string? Payload { get; set; }

        public DateTime ErrorDate { get; set; } = DateTime.Now;


    }
}
