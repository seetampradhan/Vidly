namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SignupFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Custmores", "MembershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Custmores", "MembershipTypeId");
            AddForeignKey("dbo.Custmores", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Custmores", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Custmores", new[] { "MembershipTypeId" });
            DropColumn("dbo.Custmores", "MembershipTypeId");
            DropTable("dbo.MembershipTypes");
        }
    }
}
