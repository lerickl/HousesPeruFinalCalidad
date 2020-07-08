namespace HousesPeru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ciudades",
                c => new
                    {
                        CiudadesId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.CiudadesId);
            
            CreateTable(
                "dbo.Inmueble",
                c => new
                    {
                        InmuebleId = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        CiudadId = c.Int(nullable: false),
                        InmuebleTipoId = c.Int(nullable: false),
                        PublicacionId = c.Int(nullable: false),
                        NombreInm = c.String(),
                        Area = c.String(),
                        NumHabitaciones = c.String(),
                        Pisos = c.String(),
                        Piso = c.String(),
                        PrecioVentaInm = c.String(),
                        PrecioAlquilerInm = c.String(),
                        UbicacionInm = c.String(),
                        Baños = c.String(),
                        Garages = c.String(),
                        FechaPublic = c.DateTime(),
                        Descripcion = c.String(),
                        NumCelular = c.String(),
                        EstaActivo = c.Boolean(),
                        Moneda = c.String(),
                        Ciudad_CiudadesId = c.Int(),
                    })
                .PrimaryKey(t => t.InmuebleId)
                .ForeignKey("dbo.Ciudades", t => t.Ciudad_CiudadesId)
                .ForeignKey("dbo.InmuebleTipo", t => t.InmuebleTipoId, cascadeDelete: true)
                .ForeignKey("dbo.Publicacion", t => t.PublicacionId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .ForeignKey("dbo.Ciudades", t => t.CiudadId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.CiudadId)
                .Index(t => t.InmuebleTipoId)
                .Index(t => t.PublicacionId)
                .Index(t => t.Ciudad_CiudadesId);
            
            CreateTable(
                "dbo.Direcciones",
                c => new
                    {
                        DireccionesId = c.Int(nullable: false, identity: true),
                        Ubicacion = c.String(),
                        Latitud = c.String(),
                        Longitud = c.String(),
                        InmuebleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DireccionesId)
                .ForeignKey("dbo.Inmueble", t => t.InmuebleId, cascadeDelete: true)
                .Index(t => t.InmuebleId);
            
            CreateTable(
                "dbo.Imagen",
                c => new
                    {
                        ImagenId = c.Int(nullable: false, identity: true),
                        Img1 = c.String(),
                        Img2 = c.String(),
                        Img3 = c.String(),
                        Img4 = c.String(),
                        Img5 = c.String(),
                        Img6 = c.String(),
                        Img7 = c.String(),
                        Img8 = c.String(),
                        Img9 = c.String(),
                        Img10 = c.String(),
                        Img11 = c.String(),
                        Img12 = c.String(),
                        Img13 = c.String(),
                        Img14 = c.String(),
                        Img15 = c.String(),
                        Img16 = c.String(),
                        Img17 = c.String(),
                        Img18 = c.String(),
                        Img19 = c.String(),
                        Img20 = c.String(),
                        InmuebleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImagenId)
                .ForeignKey("dbo.Inmueble", t => t.InmuebleId, cascadeDelete: true)
                .Index(t => t.InmuebleId);
            
            CreateTable(
                "dbo.InmuebleTipo",
                c => new
                    {
                        InmuebleTipoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.InmuebleTipoId);
            
            CreateTable(
                "dbo.Publicacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        Inmueble_InmuebleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inmueble", t => t.Inmueble_InmuebleId)
                .Index(t => t.Inmueble_InmuebleId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        ApellidoP = c.String(),
                        ApellidoM = c.String(),
                        FechaNacimiento = c.DateTime(),
                        Email = c.String(),
                        Password = c.String(),
                        Sexo = c.String(),
                        TipoUsuario = c.String(),
                        FechaRegistro = c.DateTime(nullable: false),
                        PlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Plan", t => t.PlanId, cascadeDelete: true)
                .Index(t => t.PlanId);
            
            CreateTable(
                "dbo.DetalleCompraMap",
                c => new
                    {
                        DetalleCompraId = c.Int(nullable: false, identity: true),
                        Monto = c.String(),
                        Pago = c.Boolean(),
                        UsuarioId = c.Int(nullable: false),
                        usuarios_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.DetalleCompraId)
                .ForeignKey("dbo.Usuario", t => t.usuarios_UsuarioId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId)
                .Index(t => t.usuarios_UsuarioId);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Precio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inmueble", "CiudadId", "dbo.Ciudades");
            DropForeignKey("dbo.Usuario", "PlanId", "dbo.Plan");
            DropForeignKey("dbo.Inmueble", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.DetalleCompraMap", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.DetalleCompraMap", "usuarios_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Inmueble", "PublicacionId", "dbo.Publicacion");
            DropForeignKey("dbo.Publicacion", "Inmueble_InmuebleId", "dbo.Inmueble");
            DropForeignKey("dbo.Inmueble", "InmuebleTipoId", "dbo.InmuebleTipo");
            DropForeignKey("dbo.Imagen", "InmuebleId", "dbo.Inmueble");
            DropForeignKey("dbo.Direcciones", "InmuebleId", "dbo.Inmueble");
            DropForeignKey("dbo.Inmueble", "Ciudad_CiudadesId", "dbo.Ciudades");
            DropIndex("dbo.DetalleCompraMap", new[] { "usuarios_UsuarioId" });
            DropIndex("dbo.DetalleCompraMap", new[] { "UsuarioId" });
            DropIndex("dbo.Usuario", new[] { "PlanId" });
            DropIndex("dbo.Publicacion", new[] { "Inmueble_InmuebleId" });
            DropIndex("dbo.Imagen", new[] { "InmuebleId" });
            DropIndex("dbo.Direcciones", new[] { "InmuebleId" });
            DropIndex("dbo.Inmueble", new[] { "Ciudad_CiudadesId" });
            DropIndex("dbo.Inmueble", new[] { "PublicacionId" });
            DropIndex("dbo.Inmueble", new[] { "InmuebleTipoId" });
            DropIndex("dbo.Inmueble", new[] { "CiudadId" });
            DropIndex("dbo.Inmueble", new[] { "UsuarioId" });
            DropTable("dbo.Plan");
            DropTable("dbo.DetalleCompraMap");
            DropTable("dbo.Usuario");
            DropTable("dbo.Publicacion");
            DropTable("dbo.InmuebleTipo");
            DropTable("dbo.Imagen");
            DropTable("dbo.Direcciones");
            DropTable("dbo.Inmueble");
            DropTable("dbo.Ciudades");
        }
    }
}
