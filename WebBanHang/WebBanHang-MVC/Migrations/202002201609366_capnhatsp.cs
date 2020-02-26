namespace WebBanHang_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class capnhatsp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.sanpham", "soluong", c => c.Int());
            DropColumn("dbo.sanpham", "trangthai");
        }
        
        public override void Down()
        {
            AddColumn("dbo.sanpham", "trangthai", c => c.Boolean());
            DropColumn("dbo.sanpham", "soluong");
        }
    }
}
