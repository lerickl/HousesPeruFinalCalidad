namespace HousesPeru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Imagen", "Img", c => c.String());
            DropColumn("dbo.Imagen", "Img1");
            DropColumn("dbo.Imagen", "Img2");
            DropColumn("dbo.Imagen", "Img3");
            DropColumn("dbo.Imagen", "Img4");
            DropColumn("dbo.Imagen", "Img5");
            DropColumn("dbo.Imagen", "Img6");
            DropColumn("dbo.Imagen", "Img7");
            DropColumn("dbo.Imagen", "Img8");
            DropColumn("dbo.Imagen", "Img9");
            DropColumn("dbo.Imagen", "Img10");
            DropColumn("dbo.Imagen", "Img11");
            DropColumn("dbo.Imagen", "Img12");
            DropColumn("dbo.Imagen", "Img13");
            DropColumn("dbo.Imagen", "Img14");
            DropColumn("dbo.Imagen", "Img15");
            DropColumn("dbo.Imagen", "Img16");
            DropColumn("dbo.Imagen", "Img17");
            DropColumn("dbo.Imagen", "Img18");
            DropColumn("dbo.Imagen", "Img19");
            DropColumn("dbo.Imagen", "Img20");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Imagen", "Img20", c => c.String());
            AddColumn("dbo.Imagen", "Img19", c => c.String());
            AddColumn("dbo.Imagen", "Img18", c => c.String());
            AddColumn("dbo.Imagen", "Img17", c => c.String());
            AddColumn("dbo.Imagen", "Img16", c => c.String());
            AddColumn("dbo.Imagen", "Img15", c => c.String());
            AddColumn("dbo.Imagen", "Img14", c => c.String());
            AddColumn("dbo.Imagen", "Img13", c => c.String());
            AddColumn("dbo.Imagen", "Img12", c => c.String());
            AddColumn("dbo.Imagen", "Img11", c => c.String());
            AddColumn("dbo.Imagen", "Img10", c => c.String());
            AddColumn("dbo.Imagen", "Img9", c => c.String());
            AddColumn("dbo.Imagen", "Img8", c => c.String());
            AddColumn("dbo.Imagen", "Img7", c => c.String());
            AddColumn("dbo.Imagen", "Img6", c => c.String());
            AddColumn("dbo.Imagen", "Img5", c => c.String());
            AddColumn("dbo.Imagen", "Img4", c => c.String());
            AddColumn("dbo.Imagen", "Img3", c => c.String());
            AddColumn("dbo.Imagen", "Img2", c => c.String());
            AddColumn("dbo.Imagen", "Img1", c => c.String());
            DropColumn("dbo.Imagen", "Img");
        }
    }
}
