using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PBIServices.Models;
using System;
using System.Configuration;

namespace InventoryService.Models
{
    public partial class VendedoresContext : DbContext
    {


        //var connections = _configuration.GetSection("ConnectionStrings").GetChildren().AsEnumerable();

        //(options => options.UseSqlServer(connection));


        //private var connection = Configuration.GetConnectionString("InventoryDatabase");
        //PBIServices.AddDbContextPool<InventoryContext>(options => options.UseSqlServer(connection));

        string connstr = ConfigurationManager.ConnectionStrings["VendedoresDatabase"].ConnectionString;


        // public VendedoresContext(IConfiguration configuration)
        //{
        //   Configuration = configuration;
        //}



        public VendedoresContext(DbContextOptions<VendedoresContext> options)
           : base(options)
        {
        }

        // public IConfiguration Configuration { get; }
        // }

        public virtual DbSet<Vendedores> Vendedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendedores>(entity =>
            {
                entity.HasKey(e => e.IdUserDomain)
                    .HasName("PK__IdUserDomain__1788CC4C1F5C1650");

                entity.Property(e => e.UserDomain)
                   .IsRequired()
                   .HasMaxLength(150)
                   .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdVendedor)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.VendFilter)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IdOrgVentas)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}