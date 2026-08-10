using InventoryService.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace InventoryService.Data
{
    /// <summary>
    /// Seeds fake demo data for teaching visual validation. Never uses corporate sources.
    /// </summary>
    public static class TeachingDataSeeder
    {
        public static void Seed(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<InventoryContext>();
            var log = scope.ServiceProvider.GetRequiredService<ILoggerFactory>().CreateLogger("TeachingDataSeeder");

            db.Database.EnsureCreated();

            if (db.UserInfo.Any())
            {
                log.LogInformation("Teaching seed already present — skip.");
                return;
            }

            db.UserInfo.AddRange(
                new UserInfo
                {
                    UserId = 1,
                    FirstName = "Ada",
                    LastName = "Admin",
                    UserName = "admin",
                    Email = "admin@demo.local",
                    Password = "Admin123!",
                    CreatedDate = DateTime.UtcNow
                },
                new UserInfo
                {
                    UserId = 2,
                    FirstName = "Sam",
                    LastName = "Seller",
                    UserName = "seller",
                    Email = "seller@demo.local",
                    Password = "Seller123!",
                    CreatedDate = DateTime.UtcNow
                });

            db.Lineas.AddRange(
                new Lineas { Linea = "L01", UndNegocio = "UN1", UndNegocioNombre = "Agro demo" },
                new Lineas { Linea = "L02", UndNegocio = "UN2", UndNegocioNombre = "Retail demo" },
                new Lineas { Linea = "L03", UndNegocio = "UN1", UndNegocioNombre = "Agro demo" });

            db.Sociedades.AddRange(
                new Sociedades { IdSociedad = "DEMO", Sociedad = "Sociedad Demo Teaching" },
                new Sociedades { IdSociedad = "LAB1", Sociedad = "Lab Norte Teaching" });

            // Controllers read DbSet Cliente (singular).
            db.Cliente.AddRange(
                new Cliente { IdCliente = "C001", NombreComercial = "Cliente Demo Uno" },
                new Cliente { IdCliente = "C002", NombreComercial = "Cliente Demo Dos" },
                new Cliente { IdCliente = "C003", NombreComercial = "Distribuidora Valle Demo" });

            db.Products.AddRange(
                new Products
                {
                    ProductId = 1,
                    Name = "Café demo 500g",
                    Category = "Alimentos",
                    Color = "Café",
                    UnitPrice = 18500,
                    AvailableQuantity = 40
                },
                new Products
                {
                    ProductId = 2,
                    Name = "Azúcar demo 1kg",
                    Category = "Alimentos",
                    Color = "Blanco",
                    UnitPrice = 6200,
                    AvailableQuantity = 120
                },
                new Products
                {
                    ProductId = 3,
                    Name = "Leche demo 1L",
                    Category = "Lácteos",
                    Color = "N/A",
                    UnitPrice = 4500,
                    AvailableQuantity = 0
                });

            db.Productos.AddRange(
                new Productos
                {
                    idMaterial = "MAT-001",
                    Producto = "Café demo 500g",
                    IdGrArticulos = "G01",
                    NombreGrArticulos = "Granos",
                    AgrupacionMarca = "DemoBrand",
                    GrupoProductos = "Bebidas"
                },
                new Productos
                {
                    idMaterial = "MAT-002",
                    Producto = "Azúcar demo 1kg",
                    IdGrArticulos = "G02",
                    NombreGrArticulos = "Endulzantes",
                    AgrupacionMarca = "DemoBrand",
                    GrupoProductos = "Despensa"
                });

            db.VentClienProductos.AddRange(
                new VentClienProductos
                {
                    Linea = "L01",
                    UndNegocio = "UN1",
                    IdOrgVentas = "OV01",
                    IdMaterial = "MAT-001",
                    Producto = "Café demo 500g",
                    VentaML = 1500000,
                    AjusteFormato = 0
                },
                new VentClienProductos
                {
                    Linea = "L02",
                    UndNegocio = "UN2",
                    IdOrgVentas = "OV01",
                    IdMaterial = "MAT-002",
                    Producto = "Azúcar demo 1kg",
                    VentaML = 890000,
                    AjusteFormato = 0
                });

            // VenClientes / Estados have fragile key mapping in the legacy model — skip seed;
            // primary visual tabs (Líneas, Products, Clientes, Sociedades, VentClienProductos) are filled.

            db.SaveChanges();
            log.LogInformation("Teaching seed OK — rich demo rows for visual validation");
        }
    }
}
