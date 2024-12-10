using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AsfaAPI.Models
{
    [Table("PREGUNTA")]
    public class Pregunta
    {
        [Key]
        [Column("ID_PREGUNTA")]
        public int IdPregunta { get; set; }

        [Column("TEXTO")]
        public string Texto { get; set; }

        [Column("URL_IMG")]
        public string? UrlImg { get; set; }

        [Column("F_CREACION")]
        public DateTime FechaCreacion { get; set; }

        [Column("ID_PREGUNTA_CATEGORIA")]
        public int IdPreguntaCategoria { get; set; }

        [Column("ID_DIFICULTAD")]
        public int IdDificultad { get; set; }

        [Column("ID_APUNTE")]
        public int? IdApunte { get; set; }
    }

}
