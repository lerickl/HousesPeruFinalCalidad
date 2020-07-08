using HousesPeru.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;

namespace HousesPeru.DB.Maps
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");
            HasKey(x => x.UsuarioId);

            HasRequired(o => o.Plan)
             .WithMany(o => o.Usuarios)
             .HasForeignKey(o => o.PlanId);
            HasMany(d => d.Inmuebles)
                .WithOptional()
                .HasForeignKey(d=>d.UsuarioId);
 
            HasMany(d => d.DetalleCompras)
               .WithOptional()
               .HasForeignKey(d => d.UsuarioId);

        }
    }
}
