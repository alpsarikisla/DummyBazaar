using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DummyBazaarWebApp.Models
{
    public partial class DummyBazaarModel : DbContext
    {
        public DummyBazaarModel()
            : base("name=DummyBazaarModel")
        {

        }

        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<ManagerType> ManagerTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
