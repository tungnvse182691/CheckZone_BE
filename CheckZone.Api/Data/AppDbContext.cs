using Microsoft.EntityFrameworkCore;
using CheckZone.Api.Entities;

namespace CheckZone.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ScamReport> ScamReports { get; set; }
        public DbSet<LegitProfile> LegitProfiles { get; set; }
        public DbSet<SystemConfiguration> SystemConfigurations { get; set; }
        public DbSet<BlogArticle> BlogArticles { get; set; }
        public DbSet<PolicyArticle> PolicyArticles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ScamReport configurations
            modelBuilder.Entity<ScamReport>(entity =>
            {
                entity.ToTable("ScamReports");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasIndex(e => e.Name);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20);

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Desc)
                    .IsRequired();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Amount)
                    .HasPrecision(15, 2)
                    .HasDefaultValue(0m);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValue("Đang chờ duyệt");

                entity.Property(e => e.Victim)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValue("Ẩn danh");

                entity.Property(e => e.Facebook)
                    .HasMaxLength(512);

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.Category)
                    .HasDefaultValue(ScamCategory.FinancialScam);

                // Configure Tags and Images converters for List<string> to JSON conversion
                entity.Property(e => e.Tags)
                    .HasConversion(
                        v => System.Text.Json.JsonSerializer.Serialize(v, (System.Text.Json.JsonSerializerOptions)null!),
                        v => System.Text.Json.JsonSerializer.Deserialize<List<string>>(v, (System.Text.Json.JsonSerializerOptions)null!) ?? new List<string>())
                    .Metadata.SetValueComparer(new Microsoft.EntityFrameworkCore.ChangeTracking.ValueComparer<List<string>>(
                        (c1, c2) => c1 != null && c2 != null ? c1.SequenceEqual(c2) : c1 == c2,
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToList()));

                entity.Property(e => e.Images)
                    .HasConversion(
                        v => System.Text.Json.JsonSerializer.Serialize(v, (System.Text.Json.JsonSerializerOptions)null!),
                        v => System.Text.Json.JsonSerializer.Deserialize<List<string>>(v, (System.Text.Json.JsonSerializerOptions)null!) ?? new List<string>())
                    .Metadata.SetValueComparer(new Microsoft.EntityFrameworkCore.ChangeTracking.ValueComparer<List<string>>(
                        (c1, c2) => c1 != null && c2 != null ? c1.SequenceEqual(c2) : c1 == c2,
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToList()));
            });

            // LegitProfile configurations
            modelBuilder.Entity<LegitProfile>(entity =>
            {
                entity.ToTable("LegitProfiles");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Score)
                    .HasDefaultValue(100);

                entity.Property(e => e.Img)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasDefaultValue("https://images.domain.com/default-avatar.png");

                entity.Property(e => e.Desc)
                    .IsRequired();

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Telegram)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValue("@verified_merchant");

                entity.Property(e => e.Insurance)
                    .HasPrecision(15, 2)
                    .HasDefaultValue(0m);

                entity.Property(e => e.SuccessTrans)
                    .HasDefaultValue(0);

                entity.Property(e => e.JoinDate)
                    .IsRequired()
                    .HasMaxLength(7);

                entity.Property(e => e.BusinessType)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            // SystemConfiguration configurations
            modelBuilder.Entity<SystemConfiguration>(entity =>
            {
                entity.ToTable("SystemConfigurations");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedNever();

                entity.ToTable(t => t.HasCheckConstraint("CK_SystemConfiguration_Id", "id = 1"));

                entity.Property(e => e.RequireEvidence)
                    .HasDefaultValue(true);

                entity.Property(e => e.AutoApprove)
                    .HasDefaultValue(false);

                entity.Property(e => e.MinInsurance)
                    .HasPrecision(15, 2)
                    .HasDefaultValue(10000000.00m);

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValue("Ban điều hành Check Zone");

                entity.Property(e => e.AdminEmail)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValue("support@checkzone.vn");

                entity.Property(e => e.TelegramBotToken)
                    .HasMaxLength(255);
            });

            // BlogArticle configurations
            modelBuilder.Entity<BlogArticle>(entity =>
            {
                entity.ToTable("BlogArticles");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasMaxLength(20);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValue("Cảnh báo phổ thông");

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasIndex(e => e.Slug)
                    .IsUnique();

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValue("Đã đăng");
            });

            // PolicyArticle configurations
            modelBuilder.Entity<PolicyArticle>(entity =>
            {
                entity.ToTable("PolicyArticles");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastUpdated)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.Property(e => e.Active)
                    .HasDefaultValue(true);
            });
        }
    }
}
