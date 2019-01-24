namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDataAnnotationToMovieTable1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Custmores", newName: "Customers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Customers", newName: "Custmores");
        }
    }
}
