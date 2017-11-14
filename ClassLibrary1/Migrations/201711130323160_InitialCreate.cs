namespace ClassLibrary1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aparelho",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        modelo = c.String(),
                        valor = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Avaliacao",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        aceite = c.Int(nullable: false),
                        p1 = c.Int(nullable: false),
                        p2 = c.Int(nullable: false),
                        p3 = c.Int(nullable: false),
                        p4 = c.Int(nullable: false),
                        p5 = c.Int(nullable: false),
                        valorAv = c.Single(nullable: false),
                        obs = c.String(),
                        usuarioId = c.Int(nullable: false),
                        imeiId = c.Int(nullable: false),
                        filialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Filial", t => t.filialId, cascadeDelete: true)
                .ForeignKey("dbo.Imei", t => t.imeiId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.usuarioId, cascadeDelete: true)
                .Index(t => t.usuarioId)
                .Index(t => t.imeiId)
                .Index(t => t.filialId);
            
            CreateTable(
                "dbo.Filial",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        cidadeId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cidade", t => t.cidadeId)
                .Index(t => t.cidadeId);
            
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        estadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Estado", t => t.estadoId, cascadeDelete: true)
                .Index(t => t.estadoId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Imei",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        num_imei = c.Long(nullable: false),
                        aparelhoId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Aparelho", t => t.aparelhoId)
                .Index(t => t.aparelhoId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        login = c.String(),
                        senha = c.String(),
                        grupo = c.Int(nullable: false),
                        filialId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Filial", t => t.filialId)
                .Index(t => t.filialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Avaliacao", "usuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "filialId", "dbo.Filial");
            DropForeignKey("dbo.Avaliacao", "imeiId", "dbo.Imei");
            DropForeignKey("dbo.Imei", "aparelhoId", "dbo.Aparelho");
            DropForeignKey("dbo.Avaliacao", "filialId", "dbo.Filial");
            DropForeignKey("dbo.Filial", "cidadeId", "dbo.Cidade");
            DropForeignKey("dbo.Cidade", "estadoId", "dbo.Estado");
            DropIndex("dbo.Usuario", new[] { "filialId" });
            DropIndex("dbo.Imei", new[] { "aparelhoId" });
            DropIndex("dbo.Cidade", new[] { "estadoId" });
            DropIndex("dbo.Filial", new[] { "cidadeId" });
            DropIndex("dbo.Avaliacao", new[] { "filialId" });
            DropIndex("dbo.Avaliacao", new[] { "imeiId" });
            DropIndex("dbo.Avaliacao", new[] { "usuarioId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Imei");
            DropTable("dbo.Estado");
            DropTable("dbo.Cidade");
            DropTable("dbo.Filial");
            DropTable("dbo.Avaliacao");
            DropTable("dbo.Aparelho");
        }
    }
}
