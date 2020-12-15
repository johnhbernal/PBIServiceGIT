using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("PBI_FactVentas")]
    public class Ventas
    {
        public DateTime Fecha { get; }
        public string UndNegocio { get; }
        public string Linea { get; }
        public string IdOrgVentas { get; }
        public string IdVendedor { get; }
        public string RepresentanteVentas { get; }
        public string IdCliente { get; }
        public string IdPais { get; }
        public string Departamento { get; }
        public string Ciudad { get; }
        public string IdDimUndNegocios { get; }
        public string IdCeBe { get; }
        public string UndNegocioProducto { get; }
        public string NombreG1 { get; }
        public string NombreG2 { get; }
        public string NombreG3 { get; }
        public string Idmaterial { get; }

        [StringLength(1)]
        public int Intercompany { get; }

        public decimal CantidadTotal { get; }
        public decimal CantidadBonificada { get; }
        public decimal CantidadMuestra { get; }
        public decimal CantidadFacturada { get; }
        public decimal VentaML { get; }
        public decimal CostoML { get; }
        public decimal CostoBonificadoML { get; }
        public decimal VentaMG { get; }
        public decimal VentaMF { get; }
        public decimal CostoMG { get; }
        public decimal CostoMF { get; }
        public string CantidadKGL { get; }
        public string IdDimVendedores { get; }
        public decimal ValorSinFlete { get; }
        public decimal CostoPromedioMaterial { get; }

        [StringLength(1)]
        public decimal AjusteFormato { get; }

        public string IdSociedad { get; }
    }
}