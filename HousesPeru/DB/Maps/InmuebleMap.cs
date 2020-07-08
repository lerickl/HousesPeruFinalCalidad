using HousesPeru.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;

namespace HousesPeru.DB.Maps
{
    public class InmuebleMap : EntityTypeConfiguration<Inmueble>
    {
        public InmuebleMap()
        {
            ToTable("Inmueble");
            HasKey(x => x.InmuebleId);

            HasRequired(x => x.InmuebleTipo)
                .WithMany()
                .HasForeignKey(x => x.InmuebleTipoId);
           HasRequired(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId);
            HasMany(x => x.Imagenes)
                .WithRequired()
                .HasForeignKey(x => x.InmuebleId);
            
        }

    }
}
