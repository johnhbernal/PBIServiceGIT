using Microsoft.EntityFrameworkCore;
using PBIServices.Models;

namespace InventoryService.Models
{
    /// <summary>
    /// Legacy secondary context kept for compile compatibility.
    /// Teaching lab does not register or connect this DbContext.
    /// </summary>
    public partial class VendedoresContext : DbContext
    {
        public VendedoresContext(DbContextOptions<VendedoresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Vendedores> Vendedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendedores>(entity =>
            {
                entity.HasKey(e => e.IdUserDomain);

                entity.Property(e => e.UserDomain).IsRequired().HasMaxLength(150).IsUnicode(false);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150).IsUnicode(false);
                entity.Property(e => e.IdVendedor).IsRequired().HasMaxLength(3).IsUnicode(false);
                entity.Property(e => e.VendFilter).IsRequired().HasMaxLength(3).IsUnicode(false);
                entity.Property(e => e.IdOrgVentas).IsRequired().HasMaxLength(4).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
