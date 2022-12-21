using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoostBusinessApi.Data.Entity
{
    public class SystemErrorEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime ErrorDate { get; set; } = DateTime.Now;

        [Column(TypeName = "varchar(20)")]
        public string? Method { get; internal set; }


        [Column(TypeName = "varchar(1000)")]
        public string? Path { get; internal set; }


        [Column(TypeName = "varchar(1000)")]
        public string? Message { get; set; }


        [Column(TypeName = "varchar(MAX)")]
        public string? Exception { get; set; }


        [Column(TypeName = "varchar(2000)")]
        public string? Payload { get; set; }

    }
}
