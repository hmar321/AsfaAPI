using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AsfaAPI.Models
{
    [Table("DIFICULTAD")]
    public class Dificultad
    {
        [Key]
        [Column("ID_DIFICULTAD")]
        public int IdDificultad { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }
    }

}
