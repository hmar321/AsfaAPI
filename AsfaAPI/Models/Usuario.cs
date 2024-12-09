using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AsfaAPI.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Key]
        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [Column("DNI")]
        public string Dni { get; set; }

        [Column("PASSWORD")]
        public byte[] Password { get; set; }

        [Column("SALT")]
        public string Salt { get; set; }

        [Column("TOKEN")]
        public string? Token { get; set; } // Nullable

        [Column("F_REGISTRO")]
        public DateTime FechaRegistro { get; set; }

        [Column("ID_ROL")]
        public int IdRol { get; set; }
    }

}
