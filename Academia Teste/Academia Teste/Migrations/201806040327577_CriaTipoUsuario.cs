namespace Academia_Teste.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriaTipoUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "Tipo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Tipo");
        }
    }
}
