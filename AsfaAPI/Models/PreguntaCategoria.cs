using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AsfaAPI.Models
{
    [Table("PREGUNTA_CATEGORIA")]
    public class PreguntaCategoria
    {
        [Key]
        [Column("ID_PREGUNTA_CATEGORIA")]
        public int IdPreguntaCategoria { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }
    }

}
