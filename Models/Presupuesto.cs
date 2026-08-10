using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("PBI_FactPresupuesto")]
    public class Presupuesto
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

        public int CantidadTotal { get; set; }
        public int CantidadBonificada { get; set; }
        public int CantidadMuestra { get; set; }
        public int CantidadFacturada { get; set; }
        public int CostoML { get; set; }
        public int VentaML { get; set; }
        public int CostoMG { get; set; }
        public int VentaMG { get; set; }
        public int CostoMF { get; set; }
        public int VentaMF { get; set; }
        public int CostoPromedioMaterial { get; set; }
        public int PptoMlocal { get; set; }
        public int PptoUSD { get; set; }
        public int PptoMG { get; set; }
        public int Unidades { get; set; }
        public decimal AjusteFormato { get; set; }
        public string RepresentanteVentas { get; set; }

        [StringLength(2)]
        public string CodTipo { get; set; }
    }
}