using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AsfaAPI.Models
{
    [Table("RESOLUCION")]
    public class Resolucion
    {
        [Key]
        [Column("ID_RESOLUCION")]
        public int IdResolucion { get; set; }

        [Column("TEXTO")]
        public string Texto { get; set; }

        [Column("F_CREACION")]
        public DateTime FechaCreacion { get; set; }

        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }
    }

}
