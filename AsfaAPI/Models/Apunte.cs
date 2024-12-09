using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AsfaAPI.Models
{
    [Table("APUNTE")]
    public class Apunte
    {
        [Key]
        [Column("ID_APUNTE")]
        public int IdApunte { get; set; }

        [Column("TEXTO")]
        public string Texto { get; set; }
    }

}
