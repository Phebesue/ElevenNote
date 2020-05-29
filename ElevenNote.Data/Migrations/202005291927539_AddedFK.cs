namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Note", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Note", "CategoryId");
            AddForeignKey("dbo.Note", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
            DropColumn("dbo.Note", "CategoryTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Note", "CategoryTitle", c => c.Int(nullable: false));
            DropForeignKey("dbo.Note", "CategoryId", "dbo.Category");
            DropIndex("dbo.Note", new[] { "CategoryId" });
            DropColumn("dbo.Note", "CategoryId");
        }
    }
}
