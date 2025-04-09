namespace SC_601_PA_G5_M.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjusteDecimal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransaccionContables",
                c => new
                    {
                        IdTransaccion = c.Int(nullable: false, identity: true),
                        FechaTransaccion = c.DateTime(nullable: false),
                        TipoTransaccion = c.Int(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descripcion = c.String(maxLength: 500),
                        CitaTallerId = c.Int(),
                        ProductoId = c.Int(),
                    })
                .PrimaryKey(t => t.IdTransaccion)
                .ForeignKey("dbo.CitaTallers", t => t.CitaTallerId)
                .ForeignKey("dbo.Productoes", t => t.ProductoId)
                .Index(t => t.CitaTallerId)
                .Index(t => t.ProductoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransaccionContables", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.TransaccionContables", "CitaTallerId", "dbo.CitaTallers");
            DropIndex("dbo.TransaccionContables", new[] { "ProductoId" });
            DropIndex("dbo.TransaccionContables", new[] { "CitaTallerId" });
            DropTable("dbo.TransaccionContables");
        }
    }
}
