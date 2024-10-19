using LT.Core.BaseEntities;
using LT.Core.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace LT.Core
{
    public class CPortalContext(DbContextOptions<CPortalContext> options) : DbContext(options)
    {
        public DbSet<MSSurveyCorporate> MS_Survey_Corporate { get; set; }
        public DbSet<TblCorpSettings> TblCorpSettings { get; set; }

        public DbSet<LTWebApiUsers> LT_WebApiUsers { get; set; }
        public DbSet<LTWebApiUsersHistory> LT_WebApiUsers_History { get; set; }
        public DbSet<LTTimezoneDiffInSecUS> LT_timezoneDiffInSecUS { get; set; }

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
