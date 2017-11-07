using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDieta.Models
{
    public class Paciente
    {
        public TipoDocumento TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public long IdPaciente { get; set; }
    }
}