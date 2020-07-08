using HousesPeru.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;

namespace HousesPeru.DB.Maps
{
    public class InmuebleTipoMap : EntityTypeConfiguration<InmuebleTipo>
    {
        public InmuebleTipoMap()
        {
            ToTable("InmuebleTipo");
            HasKey(x => x.InmuebleTipoId);

            HasMany(x => x.Inmuebles)
             .WithOptional()
             .HasForeignKey(x => x.InmuebleTipoId);
        }
    }
}
