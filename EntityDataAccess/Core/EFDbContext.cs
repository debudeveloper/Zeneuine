using EntityObjects.Objects;
using System.Data.Entity;

namespace EntityDataAccess.Core
{
    public class EFDbContext : DbContext
    {
        static EFDbContext()
        {
            Database.SetInitializer<EFDbContext>(null);
        }
        public EFDbContext() : base("name=ZenuineEntites")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public  DbSet<UserMaster> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RoleMaster> RoleMasters { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region usemaster
            modelBuilder.Entity<UserMaster>().Property(t => t.City).IsRequired();
            modelBuilder.Entity<UserMaster>().Property(t => t.Name).IsRequired();
            modelBuilder.Entity<UserMaster>().Property(t => t.Password).IsRequired();
            modelBuilder.Entity<UserMaster>().Property(t => t.PhoneNumber).IsRequired();
            modelBuilder.Entity<UserMaster>().Property(t => t.VeryfiCode).IsOptional();

            //modelBuilder.Entity<UserMaster>().Property(t => t.).IsRequired();
            //modelBuilder.Entity<UserMaster>().Property(t => t.City).IsRequired();
            //modelBuilder.Entity<UserMaster>().Property(t => t.City).IsRequired();

            #endregion
            base.OnModelCreating(modelBuilder);
        }

      
    }
} 