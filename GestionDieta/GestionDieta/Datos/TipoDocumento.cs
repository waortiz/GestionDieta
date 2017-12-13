using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDieta.Datos
{
    [Table("TiposDocumento")]
    public class TipoDocumento
    {
        public TipoDocumento()
        {
            this.Pacientes = new HashSet<Paciente>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTipoDocumento { get; set; }
        public string Nombre { get; set; }

        public ICollection<Paciente> Pacientes { get; set; }
    }
}