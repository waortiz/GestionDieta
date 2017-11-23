using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDieta.Datos
{
    public class GestionDietaInitializer : DropCreateDatabaseIfModelChanges<GestionDietaContext>
    {
        protected override void Seed(GestionDietaContext context)
        {
            context.TiposDocumento.Add(new TipoDocumento() { Nombre = "Cédula de Ciudadanía", IdTipoDocumento = 1});
            context.TiposDocumento.Add(new TipoDocumento() { Nombre = "Cédula de Extranjería", IdTipoDocumento = 2 });
            context.TiposDocumento.Add(new TipoDocumento() { Nombre = "Tarjeta de Identidad", IdTipoDocumento = 3 });

            context.Usuarios.Add(new Usuario() { Nombre = "william", Clave = "123" });

            base.Seed(context);
        }
    }
}
