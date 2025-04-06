namespace SC_601_PA_G5_M.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PA05Migration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Productoes", "UsuarioId", "dbo.AspNetUsers");
            DropIndex("dbo.Productoes", new[] { "UsuarioId" });
            CreateTable(
                "dbo.DetallePedidoes",
                c => new
                    {
                        IdDetallePedidop = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioUnitario = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IdDetallePedidop)
                .ForeignKey("dbo.Pedidoes", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.PedidoId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        IdPedido = c.Int(nullable: false, identity: true),
                        FechaPedido = c.DateTime(nullable: false),
                        IdCliente = c.Int(nullable: false),
                        EstadoPedido = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdPedido);
            
            DropColumn("dbo.Productoes", "UsuarioId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productoes", "UsuarioId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.DetallePedidoes", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.DetallePedidoes", "PedidoId", "dbo.Pedidoes");
            DropIndex("dbo.DetallePedidoes", new[] { "ProductoId" });
            DropIndex("dbo.DetallePedidoes", new[] { "PedidoId" });
            DropTable("dbo.Pedidoes");
            DropTable("dbo.DetallePedidoes");
            CreateIndex("dbo.Productoes", "UsuarioId");
            AddForeignKey("dbo.Productoes", "UsuarioId", "dbo.AspNetUsers", "Id");
        }
    }
}
