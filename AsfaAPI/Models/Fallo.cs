using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AsfaAPI.Models
{
    [Table("FALLO")]
    public class Fallo
    {
        [Key]
        [Column("ID_FALLO")]
        public int IdFallo { get; set; }

        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }

        [Column("ID_PREGUNTA")]
        public int IdPregunta { get; set; }
    }

}
