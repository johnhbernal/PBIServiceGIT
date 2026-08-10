using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("PBI_FactVentas")]
    public class Ventas
    {
        public DateTime Fecha { get; set; }
        public string UndNegocio { get; set; }
        public string Linea { get; set; }
        public string IdOrgVentas { get; set; }
        public string IdVendedor { get; set; }
        public string RepresentanteVentas { get; set; }
        public string IdCliente { get; set; }
        public string IdPais { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        public string IdDimUndNegocios { get; set; }
        public string IdCeBe { get; set; }
        public string UndNegocioProducto { get; set; }
        public string NombreG1 { get; set; }
        public string NombreG2 { get; set; }
        public string NombreG3 { get; set; }
        public string Idmaterial { get; set; }

        [StringLength(1)]
        public int Intercompany { get; set; }

        public decimal CantidadTotal { get; set; }
        public decimal CantidadBonificada { get; set; }
        public decimal CantidadMuestra { get; set; }
        public decimal CantidadFacturada { get; set; }
        public decimal VentaML { get; set; }
        public decimal CostoML { get; set; }
        public decimal CostoBonificadoML { get; set; }
        public decimal VentaMG { get; set; }
        public decimal VentaMF { get; set; }
        public decimal CostoMG { get; set; }
        public decimal CostoMF { get; set; }
        public string CantidadKGL { get; set; }
        public string IdDimVendedores { get; set; }
        public decimal ValorSinFlete { get; set; }
        public decimal CostoPromedioMaterial { get; set; }

        [StringLength(1)]
        public decimal AjusteFormato { get; set; }

        public string IdSociedad { get; set; }
    }
}