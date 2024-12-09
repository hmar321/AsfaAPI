using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AsfaAPI.Models
{
    [Table("CATEGORIA_PREGUNTA")]
    public class CategoriaPregunta
    {
        [Key]
        [Column("ID_CATEGORIA_PREGUNTA")]
        public int IdCategoriaPregunta { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [Column("DESCRIPCION")]
        public string? Descripcion { get; set; }
    }

}
