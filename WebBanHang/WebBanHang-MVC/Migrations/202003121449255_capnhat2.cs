namespace WebBanHang_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class capnhat2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GioHang", "soluong", c => c.Int(nullable: false));
            AlterColumn("dbo.GioHang", "dongia", c => c.Int(nullable: false));
            AlterColumn("dbo.donhang", "thanhtien", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.donhang", "thanhtien", c => c.Int());
            AlterColumn("dbo.GioHang", "dongia", c => c.Int());
            AlterColumn("dbo.GioHang", "soluong", c => c.Int());
        }
    }
}
