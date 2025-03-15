using Ekitap.Core.Entities;
using Ekitap.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;

namespace Ekitap.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Writer> Writers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder 
            optionsBuilder)
        {
            

            optionsBuilder.UseSqlServer(@"Server=SAMET\SQLEXPRESS;
            Database = EkitapDb; Trusted_Connection=True;
            TrustServerCertificate=True; ");//sql kullanacağımızı uygulamaya bildiriyoruz
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        

            base.OnConfiguring(optionsBuilder);//veritabanı bağlantı yapılan yer
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  modelBuilder.ApplyConfiguration(new AppUserConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly
                (Assembly.GetExecutingAssembly());// çalışan dll in classların otomatik yerini bulup ayarlarl configurasyonların  
            base.OnModelCreating(modelBuilder);//yapılandırma ayarı
        }
    }
    }

