
//using HousesPeru.DB.Maps;
using HousesPeru.DB.Maps;
using HousesPeru.Models;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
//using DbContext = System.Data.Entity.DbContext;
//using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace HousesPeru.DB
{
    public class HousesInPeruContext : DbContext
    {

        public virtual DbSet<Usuario> Usuarios { get; set; }
        //public virtual DbSet<Publicacion> Publicacions { get; set; } 
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<InmuebleTipo> InmuebleTipos { get; set; }
        public virtual DbSet<Inmueble> Inmuebles { get; set; }
        public virtual DbSet<Imagen> Imagens { get; set; }
        public virtual DbSet<Direcciones> Direcciones { get; set; }
        public virtual DbSet<Ciudades> Ciudades { get; set; }
        public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }
        public HousesInPeruContext() {
            Database.SetInitializer<HousesInPeruContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UsuarioMap());
            //modelBuilder.Configurations.Add(new PublicacionMap());          
            modelBuilder.Configurations.Add(new PlanMap());
            modelBuilder.Configurations.Add(new InmuebleTipoMap());
            modelBuilder.Configurations.Add(new InmuebleMap());
            modelBuilder.Configurations.Add(new ImagenMap());
            modelBuilder.Configurations.Add(new CiudadesMap());
            modelBuilder.Configurations.Add(new DetalleCompraMap());

        }
        

    }
}
