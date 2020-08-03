using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("PBI_FactVentasClientes")]
    public class VenClientes
    {
        [Key]
        public DateTime Fecha { get; }
        [StringLength(4)]
        public int Anyo { get; }
        public string Linea { get; }
        public string UndNegocio { get; }
        public string IdOrgVentas { get; }
        public string IdCliente { get; }
        public string NombreComercial { get; }
        public string IdMaterial { get; }
        public string Producto { get; }
        public decimal VentaML { get; }
        public decimal VentaMG { get; }
        public string RepresentanteVentas { get; }
        [StringLength(1)]
        public int AjusteFormato { get; }

    }
}
