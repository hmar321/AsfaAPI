using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AsfaAPI.Models
{
    [Table("DUDA")]
    public class Duda
    {
        [Key]
        [Column("ID_DUDA")]
        public int IdDuda { get; set; }

        [Column("TEXTO")]
        public string Texto { get; set; }

        [Column("F_CREACION")]
        public DateTime FechaCreacion { get; set; }

        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }

        [Column("ID_PREGUNTA")]
        public int IdPregunta { get; set; }

        [Column("ID_RESOLUCION")]
        public int? IdResolucion { get; set; }
    }
}
