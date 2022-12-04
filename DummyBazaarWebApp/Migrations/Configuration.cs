namespace DummyBazaarWebApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DummyBazaarWebApp.Models.DummyBazaarModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DummyBazaarWebApp.Models.DummyBazaarModel context)
        {
            context.ManagerTypes.AddOrUpdate(m => m.ID, new Models.ManagerType() { ID = 1, Name = "Admin" });
            context.ManagerTypes.AddOrUpdate(m => m.ID, new Models.ManagerType() { ID = 2, Name = "Moderatör" });

            context.Managers.AddOrUpdate(m => m.ID, new Models.Manager() { ID = 1, Name = "Alp", Surname="Sarıkışla", Mail="a.sarikisla@veksis.com", ManagerType_ID = 1, Password="12345678", UserName="a.sarikisla", IsActive=true });
        }
    }
}
