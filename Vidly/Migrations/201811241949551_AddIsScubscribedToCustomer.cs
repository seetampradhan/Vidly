namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsScubscribedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Custmores", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Custmores", "IsSubscribedToNewsLetter");
        }
    }
}
