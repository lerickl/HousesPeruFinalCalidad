using HousesPeru.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HousesPeru.DB.Maps
{
    public class CiudadesMap : EntityTypeConfiguration<Ciudades>
    {
        public CiudadesMap() {
            ToTable("Ciudades");
            HasKey(x => x.CiudadesId);

            HasMany(x => x.Inmuebles)
                    .WithOptional()
                    .HasForeignKey(x => x.CiudadId);
        }
    
    }
}