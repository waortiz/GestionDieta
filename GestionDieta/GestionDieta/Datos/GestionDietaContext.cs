using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDieta.Datos
{
    public class GestionDietaContext : DbContext
    {
        public GestionDietaContext() : base("name=GestionDieta") 
        {
            Database.SetInitializer(new GestionDietaInitializer());
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<TipoDocumento> TiposDocumento { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoDocumento>()
                .HasMany(p => p.Pacientes)
                .WithRequired(p => p.TipoDocumento)
                .HasForeignKey(p => p.IdTipoDocumento)
                .WillCascadeOnDelete(false);
        }
    }
}
