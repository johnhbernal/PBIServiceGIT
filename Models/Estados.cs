using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("PBI_EstadoResultado")]
    public class Estados
    {
        public string Rubro { get; set; }
        public Decimal Valor { get; set; }
        public string Ejercicio { get; set; }
        public string Moneda { get; set; }
        public string Anyo { get; set; }
        public DateTime Fecha { get; set; }
        public string UndNegocio { get; set; }
        public string IdSociedad { get; set; }
        public string MatCebe { get; set; }
        public string Tipo { get; set; }
        public string VentaPpto { get; set; }
    }
}