namespace WebBanHang_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.admin",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 150),
                        username = c.String(nullable: false, maxLength: 50, unicode: false),
                        password = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Danhmuc",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        tenHDT = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.sanpham",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ID_danhmuc = c.Int(nullable: false),
                        tenSP = c.String(nullable: false, maxLength: 250),
                        gia = c.Double(nullable: false),
                        khuyenmai = c.Int(),
                        avatar = c.String(maxLength: 50),
                        ngaytao = c.DateTime(),
                        trangthai = c.Boolean(),
                        chitiet = c.String(),
                        Hang = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Danhmuc", t => t.ID_danhmuc)
                .Index(t => t.ID_danhmuc);
            
            CreateTable(
                "dbo.GioHang",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        id_donhang = c.Int(),
                        id_sanpham = c.Int(),
                        soluong = c.Int(),
                        status = c.Boolean(),
                        TenSanPham = c.String(maxLength: 250),
                        avatar = c.String(maxLength: 50),
                        dongia = c.Double(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.donhang", t => t.id_donhang)
                .ForeignKey("dbo.sanpham", t => t.id_sanpham)
                .Index(t => t.id_donhang)
                .Index(t => t.id_sanpham);
            
            CreateTable(
                "dbo.donhang",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        trangthai = c.Int(nullable: false),
                        user_id = c.Int(nullable: false),
                        Diachi = c.String(maxLength: 50),
                        user_soDT = c.String(maxLength: 15, unicode: false),
                        thanhtien = c.Double(),
                        ngaytao = c.DateTime(),
                        ngayxn = c.DateTime(),
                        ghichu = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.user", t => t.user_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Ten = c.String(nullable: false, maxLength: 50),
                        email = c.String(nullable: false, maxLength: 50),
                        soDT = c.String(nullable: false, maxLength: 15, unicode: false),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        ngaytao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.sanpham", "ID_danhmuc", "dbo.Danhmuc");
            DropForeignKey("dbo.GioHang", "id_sanpham", "dbo.sanpham");
            DropForeignKey("dbo.donhang", "user_id", "dbo.user");
            DropForeignKey("dbo.GioHang", "id_donhang", "dbo.donhang");
            DropIndex("dbo.donhang", new[] { "user_id" });
            DropIndex("dbo.GioHang", new[] { "id_sanpham" });
            DropIndex("dbo.GioHang", new[] { "id_donhang" });
            DropIndex("dbo.sanpham", new[] { "ID_danhmuc" });
            DropTable("dbo.user");
            DropTable("dbo.donhang");
            DropTable("dbo.GioHang");
            DropTable("dbo.sanpham");
            DropTable("dbo.Danhmuc");
            DropTable("dbo.admin");
        }
    }
}
