namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationToNameColumnInCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Custmores", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Custmores", "Name", c => c.String());
        }
    }
}
