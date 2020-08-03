using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("PBI_ReportePresupuestoVentas")]
    public class RepoPresuVentas
    {

        [StringLength(7)]
        public string Periodo { get; }
        [Key]
        public string IdDimproductos { get; }
        public string IdOrgVentas { get; }
        public string IdVendedor { get; }
        public string IdMaterial { get; }
        public string IdCeBe { get; }
        public string NombreG1 { get; }
        public string NombreG2 { get; }
        public string NombreG3 { get; }
        public string Linea { get; }
        public string IdGrArticulos { get; }
        public string NombreGrArticulos { get; }
        [StringLength(1)]
        public int Intercompany { get; }
        public decimal CantidadTotal { get; }
        public decimal CantidadBonificada { get; }
        public decimal CantidadMuestra { get; }
        public decimal CantidadFacturada { get; }
        public decimal CostoML { get; }
        public decimal VentaML { get; }
        public decimal CostoMG { get; }
        public decimal VentaMG { get; }
        public decimal CostoMF { get; }
        public decimal VentaMF { get; }
        public decimal CostoPromedioMaterial { get; }
        public decimal PptoMlocal { get; }
        public decimal PptoUSD { get; }
        public decimal PptoMG { get; }
        public decimal Unidades { get; }
        [StringLength(1)]
        public decimal AjusteFormato { get; }
        public string RepresentanteVentas { get; }
        [StringLength(2)]
        public string CodTipo { get; }

    }
}
