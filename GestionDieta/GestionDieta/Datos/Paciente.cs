using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionDieta.Datos
{
    public class Paciente
    {
        [Key]
        public long IdPaciente { get; set; }
        public string NumeroDocumento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public int IdTipoDocumento { get; internal set; }

        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}