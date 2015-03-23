using Identity.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace Identity.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public DateTime BirthDate { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Identity.Models.PurchaseRequest> PurchaseRequests { get; set; }

        public DbSet<Identity.Models.Meeting> Meetings { get; set; }

        public DbSet<Identity.Models.PurchaseOrder> PurchaseOrders { get; set; }

        public DbSet<Identity.Models.DemandItem> DemandItems { get; set; }

        public DbSet<Identity.Models.ActivityLog> ActivityLogs { get; set; }

        public DbSet<Identity.Models.Vendor> Vendors { get; set; }

    }
}