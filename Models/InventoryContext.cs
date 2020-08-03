using Microsoft.EntityFrameworkCore;

namespace InventoryService.Models
{
    public partial class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<Sociedades> Sociedades { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Lineas> Lineas { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Presupuesto> Presupuestos { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }
        public virtual DbSet<VenClientes> VenClientes { get; set; }
        public virtual DbSet<VentClienProductos> VentClienProductos { get; set; }
        public virtual DbSet<RepoPresuVentas> RepoPresuVentas { get; set; }
        public virtual DbSet<UserInfo> Security { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__B40CC6CDFEF2D15E");

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4C1F5C1650");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sociedades>(entity =>
            {

                entity.HasKey(e => new { e.IdSociedad });

                entity.Property(e => e.Sociedad)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Cliente>(entity =>
            {

                entity.HasKey(e => new { e.IdCliente });

                entity.Property(e => e.NombreComercial)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Lineas>(entity =>
            {

                entity.HasKey(e => new { e.Linea });

                entity.Property(e => e.UndNegocio)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.UndNegocioNombre)
                   .IsRequired()
                   .HasMaxLength(255)
                   .IsUnicode(false);

            });

            modelBuilder.Entity<Productos>(entity =>
            {

                entity.HasKey(e => new { e.idMaterial });

                entity.Property(e => e.Producto)
                    //.IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdGrArticulos)
                   //.IsRequired()
                   .HasMaxLength(255)
                   .IsUnicode(false);

                entity.Property(e => e.NombreGrArticulos)
                 //.IsRequired()
                 .HasMaxLength(255)
                 .IsUnicode(false);

                entity.Property(e => e.AgrupacionMarca)
                 //.IsRequired()
                 .HasMaxLength(255)
                 .IsUnicode(false);

                entity.Property(e => e.GrupoProductos)
                 //.IsRequired()
                 .HasMaxLength(255)
                 .IsUnicode(false);

            });

            modelBuilder.Entity<Estados>(entity =>
            {

                entity.HasNoKey();

                entity.Property(e => e.Rubro)
              //.IsRequired()
              .HasMaxLength(255)
              .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Ejercicio)
                   //.IsRequired()
                   .HasMaxLength(255)
                   .IsUnicode(false);

                entity.Property(e => e.Moneda)
                 //.IsRequired()
                 .HasMaxLength(255)
                 .IsUnicode(false);

                entity.Property(e => e.Anyo)
                 //.IsRequired()
                 .HasMaxLength(255)
                 .IsUnicode(false);

                entity.Property(e => e.Fecha)
                 //.IsRequired()
                 .HasMaxLength(255)
                 .IsUnicode(false);

                entity.Property(e => e.UndNegocio)
              //.IsRequired()
              .HasMaxLength(255)
              .IsUnicode(false);

                entity.Property(e => e.IdSociedad)
              //.IsRequired()
              .HasMaxLength(255)
              .IsUnicode(false);


                entity.Property(e => e.MatCebe)
          //.IsRequired()
          .HasMaxLength(255)
          .IsUnicode(false);

                entity.Property(e => e.Tipo)
          //.IsRequired()
          .HasMaxLength(255)
          .IsUnicode(false);


                entity.Property(e => e.VentaPpto)
            //.IsRequired()
            .HasMaxLength(255)
            .IsUnicode(false);
            });

            modelBuilder.Entity<Presupuesto>(entity =>
            {

                //entity.HasNoKey();


                entity.HasKey(e => new { e.IdDimproductos });


                entity.Property(e => e.Periodo)
              //.IsRequired()
              .HasMaxLength(7)
              .IsUnicode(false);

                entity.Property(e => e.IdDimproductos)
                    //.IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdOrgVentas)
                   //.IsRequired()
                   .HasMaxLength(255)
                   .IsUnicode(false);

                entity.Property(e => e.IdVendedor)
                 //.IsRequired()
                 .HasMaxLength(255)
                 .IsUnicode(false);

                entity.Property(e => e.IdMaterial)
                 //.IsRequired()
                 .HasMaxLength(255)
                 .IsUnicode(false);

                entity.Property(e => e.IdCeBe)
                 //.IsRequired()
                 .HasMaxLength(255)
                 .IsUnicode(false);

                entity.Property(e => e.NombreG1)
              //.IsRequired()
              .HasMaxLength(255)
              .IsUnicode(false);

                entity.Property(e => e.NombreG2)
              //.IsRequired()
              .HasMaxLength(255)
              .IsUnicode(false);

                entity.Property(e => e.NombreG3)
                  //.IsRequired()
                  .HasMaxLength(255)
                  .IsUnicode(false);

                entity.Property(e => e.Linea)
                  //.IsRequired()
                  .HasMaxLength(255)
                  .IsUnicode(false);

                entity.Property(e => e.IdGrArticulos)
                //.IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

                entity.Property(e => e.NombreGrArticulos)
                //.IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

                entity.Property(e => e.Intercompany).HasColumnType("int(1, 0)");

                entity.Property(e => e.CantidadTotal).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.CantidadBonificada).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.CantidadMuestra).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.CantidadFacturada).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.CostoML).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.VentaML).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.CostoMG).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.VentaMG).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.CostoMF).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.VentaMF).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.CostoPromedioMaterial).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.PptoMlocal).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.PptoUSD).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.PptoMG).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.Unidades).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.AjusteFormato).HasColumnType("int(1, 0)");


                entity.Property(e => e.RepresentanteVentas)
                 //.IsRequired()
                 .HasMaxLength(255)
                 .IsUnicode(false);

                entity.Property(e => e.CodTipo)
              //.IsRequired()
              .HasMaxLength(2)
              .IsUnicode(false);

            });

            modelBuilder.Entity<Ventas>(entity =>
                {

                    //entity.HasNoKey();


                    entity.HasKey(e => new { e.Fecha });


                    entity.Property(e => e.Fecha)
                  //.IsRequired()
                  .HasMaxLength(255)
                  .IsUnicode(false);

                    entity.Property(e => e.UndNegocio)
                        //.IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    entity.Property(e => e.Linea)
                       //.IsRequired()
                       .HasMaxLength(255)
                       .IsUnicode(false);

                    entity.Property(e => e.IdOrgVentas)
                     //.IsRequired()
                     .HasMaxLength(255)
                     .IsUnicode(false);

                    entity.Property(e => e.IdVendedor)
                     //.IsRequired()
                     .HasMaxLength(255)
                     .IsUnicode(false);

                    entity.Property(e => e.RepresentanteVentas)
                     //.IsRequired()
                     .HasMaxLength(255)
                     .IsUnicode(false);

                    entity.Property(e => e.IdCliente)
                  //.IsRequired()
                  .HasMaxLength(255)
                  .IsUnicode(false);

                    entity.Property(e => e.IdPais)
                  //.IsRequired()
                  .HasMaxLength(255)
                  .IsUnicode(false);

                    entity.Property(e => e.Departamento)
                      //.IsRequired()
                      .HasMaxLength(255)
                      .IsUnicode(false);

                    entity.Property(e => e.Ciudad)
                      //.IsRequired()
                      .HasMaxLength(255)
                      .IsUnicode(false);

                    entity.Property(e => e.IdDimUndNegocios)
                    //.IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                    entity.Property(e => e.IdCeBe)
                    //.IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                    entity.Property(e => e.UndNegocioProducto)
                    //.IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                    entity.Property(e => e.NombreG1)
                    //.IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                    entity.Property(e => e.NombreG2)
                    //.IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                    entity.Property(e => e.NombreG3)
                    //.IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                    entity.Property(e => e.Idmaterial)
                    //.IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                    entity.Property(e => e.Intercompany).HasColumnType("int(1, 0)");

                    entity.Property(e => e.CantidadTotal).HasColumnType("decimal(16, 0)");

                    entity.Property(e => e.CantidadBonificada).HasColumnType("decimal(16, 0)");

                    entity.Property(e => e.CantidadMuestra).HasColumnType("decimal(16, 0)");

                    entity.Property(e => e.CantidadFacturada).HasColumnType("decimal(16, 0)");

                    entity.Property(e => e.VentaML).HasColumnType("decimal(16, 0)");

                    entity.Property(e => e.CostoML).HasColumnType("decimal(16, 0)");

                    entity.Property(e => e.CostoBonificadoML).HasColumnType("decimal(16, 0)");

                    entity.Property(e => e.VentaMG).HasColumnType("decimal(16, 0)");

                    entity.Property(e => e.VentaMF).HasColumnType("decimal(16, 0)");

                    entity.Property(e => e.CostoMG).HasColumnType("decimal(16, 0)");

                    entity.Property(e => e.CostoMF).HasColumnType("decimal(16, 0)");

                    entity.Property(e => e.CantidadKGL)
                    .HasColumnName("CantidadKGL")
                     .HasColumnType("varchar")
                     .HasMaxLength(255);

                    entity.Property(e => e.IdDimVendedores)
                    .HasColumnName("CantidadKGL")
                     .HasColumnType("varchar")
                     .HasMaxLength(255);

                    entity.Property(e => e.ValorSinFlete).HasColumnType("decimal(16, 0)");

                    entity.Property(e => e.CostoPromedioMaterial).HasColumnType("decimal(16, 0)");

                    entity.Property(e => e.AjusteFormato).HasColumnType("int(1, 0)");


                    entity.Property(e => e.IdSociedad)
                   //.IsRequired()
                   .HasMaxLength(255)
                   .IsUnicode(false);

                });

            modelBuilder.Entity<VenClientes>(entity =>
              {

                  entity.HasNoKey();


                  //entity.HasKey(e => new { e.Fecha });
                  //entity.HasKey(e => e.Fecha)
                  //.HasName("PK__VenClientes");

                  entity.Property(e => e.Fecha)
               .HasColumnType("datetime")
               .HasDefaultValueSql("(getdate())");

                  entity.Property(e => e.Anyo)
                //.IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false);

                  entity.Property(e => e.Linea)
                      //.IsRequired()
                      .HasMaxLength(255)
                      .IsUnicode(false);

                  entity.Property(e => e.UndNegocio)
                     //.IsRequired()
                     .HasMaxLength(255)
                     .IsUnicode(false);

                  entity.Property(e => e.IdOrgVentas)
                   //.IsRequired()
                   .HasMaxLength(255)
                   .IsUnicode(false);

                  entity.Property(e => e.IdCliente)
                   //.IsRequired()
                   .HasMaxLength(255)
                   .IsUnicode(false);

                  entity.Property(e => e.NombreComercial)
                   .IsRequired()
                   .HasMaxLength(255)
                   .IsUnicode(false);

                  entity.Property(e => e.IdMaterial)
                //.IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

                  entity.Property(e => e.Producto)
                //.IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

                  entity.Property(e => e.VentaML).HasColumnType("decimal(16, 0)");

                  entity.Property(e => e.VentaMG).HasColumnType("decimal(16, 0)");

                  entity.Property(e => e.RepresentanteVentas)
                  //.IsRequired()
                  .HasMaxLength(255)
                  .IsUnicode(false);

                  entity.Property(e => e.AjusteFormato)
                  //.IsRequired()
                  .HasMaxLength(1)
                  .IsUnicode(false);

              });

            modelBuilder.Entity<VentClienProductos>(entity =>
            {

                //entity.HasNoKey();


                entity.HasKey(e => new { e.Linea });
                //entity.HasKey(e => e.Fecha)
                //.HasName("PK__VenClientProductos");


                entity.Property(e => e.Linea)
                    //.IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UndNegocio)
                   //.IsRequired()
                   .HasMaxLength(255)
                   .IsUnicode(false);

                entity.Property(e => e.IdOrgVentas)
                 //.IsRequired()
                 .HasMaxLength(255)
                 .IsUnicode(false);

                entity.Property(e => e.IdMaterial)
              //.IsRequired()
              .HasMaxLength(255)
              .IsUnicode(false);

                entity.Property(e => e.Producto)
              //.IsRequired()
              .HasMaxLength(255)
              .IsUnicode(false);

                entity.Property(e => e.VentaML).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.AjusteFormato)
                //.IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false);

            });

            modelBuilder.Entity<RepoPresuVentas>(entity =>
            {

                //entity.HasNoKey();

                entity.HasKey(e => new { e.IdDimproductos });

                //entity.HasKey(e => e.Fecha)
                //.HasName("PK__VenClientProductos");

                entity.Property(e => e.Periodo)
                   //.IsRequired()
                   .HasMaxLength(7)
                   .IsUnicode(false);


                entity.Property(e => e.IdDimproductos)
                   //.IsRequired()
                   .HasMaxLength(255)
                   .IsUnicode(false);

                entity.Property(e => e.IdOrgVentas)
                 //.IsRequired()
                 .HasMaxLength(255)
                 .IsUnicode(false);

                entity.Property(e => e.IdVendedor)
                 //.IsRequired()
                 .HasMaxLength(255)
                 .IsUnicode(false);

                entity.Property(e => e.IdMaterial)
                  //.IsRequired()
                  .HasMaxLength(255)
                  .IsUnicode(false);

                entity.Property(e => e.IdCeBe)
                  //.IsRequired()
                  .HasMaxLength(255)
                  .IsUnicode(false);

                entity.Property(e => e.NombreG1)
                 //.IsRequired()
                 .HasMaxLength(255)
                 .IsUnicode(false);

                entity.Property(e => e.NombreG2)
                 //.IsRequired()
                 .HasMaxLength(255)
                 .IsUnicode(false);

                entity.Property(e => e.NombreG3)
                 //.IsRequired()
                 .HasMaxLength(255)
                 .IsUnicode(false);


                entity.Property(e => e.Linea)
                 //.IsRequired()
                 .HasMaxLength(255)
                 .IsUnicode(false);

                entity.Property(e => e.IdGrArticulos)
                 //.IsRequired()
                 .HasMaxLength(255)
                 .IsUnicode(false);

                entity.Property(e => e.NombreGrArticulos)
                 //.IsRequired()
                 .HasMaxLength(255)
                 .IsUnicode(false);


                entity.Property(e => e.Intercompany).HasColumnType("int(1, 0)");

                entity.Property(e => e.CantidadTotal).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.CantidadBonificada).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.CantidadMuestra).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.CantidadFacturada).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.CostoML).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.VentaML).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.CostoMG).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.VentaMG).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.CostoMF).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.VentaMF).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.CostoPromedioMaterial).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.PptoMlocal).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.PptoUSD).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.PptoMG).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.Unidades).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.PptoUSD).HasColumnType("decimal(16, 0)");

                entity.Property(e => e.AjusteFormato).HasColumnType("int(1, 0)");

                entity.Property(e => e.RepresentanteVentas)
               //.IsRequired()
               .HasMaxLength(255)
               .IsUnicode(false);

                entity.Property(e => e.CodTipo)
               //.IsRequired()
               .HasMaxLength(2)
               .IsUnicode(false);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}