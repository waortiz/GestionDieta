using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionDieta.Datos
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public long IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
    }
}