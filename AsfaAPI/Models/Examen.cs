using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AsfaAPI.Models
{
    [Table("EXAMEN")]
    public class Examen
    {
        [Key]
        [Column("ID_EXAMEN")]
        public int IdExamen { get; set; }

        [Column("FECHA")]
        public DateTime Fecha { get; set; }

        [Column("FALLOS")]
        public int Fallos { get; set; }

        [Column("DURACION")]
        public int Duracion { get; set; }

        [Column("APROBADO")]
        public bool Aprobado { get; set; }

        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }
    }

}
