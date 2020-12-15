using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("PBI_FactPresupuesto")]
    public class Presupuesto
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

        public int CantidadTotal { get; }
        public int CantidadBonificada { get; }
        public int CantidadMuestra { get; }
        public int CantidadFacturada { get; }
        public int CostoML { get; }
        public int VentaML { get; }
        public int CostoMG { get; }
        public int VentaMG { get; }
        public int CostoMF { get; }
        public int VentaMF { get; }
        public int CostoPromedioMaterial { get; }
        public int PptoMlocal { get; }
        public int PptoUSD { get; }
        public int PptoMG { get; }
        public int Unidades { get; }
        public decimal AjusteFormato { get; }
        public string RepresentanteVentas { get; }

        [StringLength(2)]
        public string CodTipo { get; }
    }
}