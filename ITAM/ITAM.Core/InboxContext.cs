using ITAM.Core.DBEntities;
using LT.Core.BaseEntities;
using LT.Core.DBEntities;
using LT.Core.ModelEntities;
using Microsoft.EntityFrameworkCore;

namespace LT.Core
{
    public class InboxContext(DbContextOptions<InboxContext> options) : DbContext(options)
    {
        public DbSet<MSSurveyCorporate> MS_Survey_Corporate { get; set; }
        public DbSet<TblCorpSettings> TblCorpSettings { get; set; }

        public DbSet<LoginModel> Users { get; set; }
        public DbSet<LTWebApiUsers> LT_WebApiUsers { get; set; }
        public DbSet<LTWebApiUsersHistory> LT_WebApiUsers_History { get; set; }
        public DbSet<LTTimezoneDiffInSecUS> LT_timezoneDiffInSecUS { get; set; }
        public DbSet<LocationMaster> LocationMaster { get; set; }
        public DbSet<AssetType> AssetType { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<LocationType> LocationType { get; set; }
        public DbSet<NoteMaster> NoteMaster { get; set; }
        public DbSet<AssetMaster> AssetMaster { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<PurchaseEntry> PurchaseEntry { get; set; }
        public DbSet<AssetInventory> AssetInventory { get; set; }
        public DbSet<AssignAsset> AssignAsset { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<SystemCodes> SystemCodes { get; set; }
        public DbSet<AssetDetail> AssetDetail { get; set; }
        public DbSet<UserLogin> SujalUser1059 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppSettings.AppConfig.DBConnectionString);
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var foreignkey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignkey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }

}
