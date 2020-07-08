using HousesPeru.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HousesPeru.DB.Maps
{
    public class DetalleCompraMap: EntityTypeConfiguration<DetalleCompra>
    {
        public DetalleCompraMap()
    {
        ToTable("DetalleCompraMap");
        HasKey(x => x.DetalleCompraId);
    }
}
}