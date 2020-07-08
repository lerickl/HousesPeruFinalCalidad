using HousesPeru.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;

namespace HousesPeru.DB.Maps
{
    public class ImagenMap : EntityTypeConfiguration<Imagen>
    {
        public ImagenMap()
        {

            ToTable("Imagen");
            HasKey(x => x.ImagenId);

            HasRequired<Inmueble>(x => x.Inmuebles)
                .WithMany(x => x.Imagenes)
                .HasForeignKey(x => x.InmuebleId);
        }
    }
}
