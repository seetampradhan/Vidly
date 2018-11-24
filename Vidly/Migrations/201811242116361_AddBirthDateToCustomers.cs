namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDateToCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Custmores", "Birthdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Custmores", "Birthdate");
        }
    }
}
