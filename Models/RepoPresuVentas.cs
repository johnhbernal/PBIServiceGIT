using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("PBI_ReportePresupuestoVentas")]
    public class RepoPresuVentas
    {
        [StringLength(7)]
        public string Periodo { get; set; }

        [Key]
        public string IdDimproductos { get; set; }

        public string IdOrgVentas { get; set; }
        public string IdVendedor { get; set; }
        public string IdMaterial { get; set; }
        public string IdCeBe { get; set; }
        public string NombreG1 { get; set; }
        public string NombreG2 { get; set; }
        public string NombreG3 { get; set; }
        public string Linea { get; set; }
        public string IdGrArticulos { get; set; }
        public string NombreGrArticulos { get; set; }

        [StringLength(1)]
        public int Intercompany { get; set; }

        public decimal CantidadTotal { get; set; }
        public decimal CantidadBonificada { get; set; }
        public decimal CantidadMuestra { get; set; }
        public decimal CantidadFacturada { get; set; }
        public decimal CostoML { get; set; }
        public decimal VentaML { get; set; }
        public decimal CostoMG { get; set; }
        public decimal VentaMG { get; set; }
        public decimal CostoMF { get; set; }
        public decimal VentaMF { get; set; }
        public decimal CostoPromedioMaterial { get; set; }
        public decimal PptoMlocal { get; set; }
        public decimal PptoUSD { get; set; }
        public decimal PptoMG { get; set; }
        public decimal Unidades { get; set; }

        [StringLength(1)]
        public decimal AjusteFormato { get; set; }

        public string RepresentanteVentas { get; set; }

        [StringLength(2)]
        public string CodTipo { get; set; }
    }
}