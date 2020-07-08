namespace HousesPeru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Publicacion", "Inmueble_InmuebleId", "dbo.Inmueble");
            DropForeignKey("dbo.Inmueble", "PublicacionId", "dbo.Publicacion");
            DropIndex("dbo.Inmueble", new[] { "PublicacionId" });
            DropIndex("dbo.Publicacion", new[] { "Inmueble_InmuebleId" });
            AddColumn("dbo.Usuario", "FechaInicioPlan", c => c.DateTime(nullable: false));
            AddColumn("dbo.Usuario", "FechaFinPlan", c => c.DateTime());
            DropColumn("dbo.Inmueble", "PublicacionId");
            DropTable("dbo.Publicacion");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Publicacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        Inmueble_InmuebleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Inmueble", "PublicacionId", c => c.Int(nullable: false));
            DropColumn("dbo.Usuario", "FechaFinPlan");
            DropColumn("dbo.Usuario", "FechaInicioPlan");
            CreateIndex("dbo.Publicacion", "Inmueble_InmuebleId");
            CreateIndex("dbo.Inmueble", "PublicacionId");
            AddForeignKey("dbo.Inmueble", "PublicacionId", "dbo.Publicacion", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Publicacion", "Inmueble_InmuebleId", "dbo.Inmueble", "InmuebleId");
        }
    }
}
