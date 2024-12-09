using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AsfaAPI.Models
{
    [Table("RESPUESTA")]
    public class Respuesta
    {
        [Key]
        [Column("ID_RESPUESTA")]
        public int IdRespuesta { get; set; }

        [Column("TEXTO")]
        public string Texto { get; set; }

        [Column("CORRECTA")]
        public bool Correcta { get; set; }

        [Column("ID_PREGUNTA")]
        public int IdPregunta { get; set; }
    }

}
