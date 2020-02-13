namespace _036_MoviesMvcWissen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.People", newName: "PersonModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PersonModels", newName: "People");
        }
    }
}
