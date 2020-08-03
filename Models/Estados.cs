using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryService.Models
{
    [Table("PBI_EstadoResultado")]
    public class Estados
    {

        public string Rubro { get; }
        public Decimal Valor { get; }
        public string Ejercicio { get; }
        public string Moneda { get; }
        public string Anyo { get; }
        public DateTime Fecha { get; }
        public string UndNegocio { get; }
        public string IdSociedad { get; }
        public string MatCebe { get; }
        public string Tipo { get; }
        public string VentaPpto { get; }

    }
}
