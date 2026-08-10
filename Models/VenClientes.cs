using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("PBI_FactVentasClientes")]
    public class VenClientes
    {
        [Key]
        public DateTime Fecha { get; set; }

        [StringLength(4)]
        public int Anyo { get; set; }

        public string Linea { get; set; }
        public string UndNegocio { get; set; }
        public string IdOrgVentas { get; set; }
        public string IdCliente { get; set; }
        public string NombreComercial { get; set; }
        public string IdMaterial { get; set; }
        public string Producto { get; set; }
        public decimal VentaML { get; set; }
        public decimal VentaMG { get; set; }
        public string RepresentanteVentas { get; set; }

        [StringLength(1)]
        public int AjusteFormato { get; set; }
    }
}