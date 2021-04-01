using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaApi.Models
{
    public class Ventas
    {
        [Key]
        public long IdVenta { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public string codigo { get; set; }
        public int Cantidad { get; set; }
        [StringLength(10)]
        public string Cedula { get; set; }
        public string IdEmpleado{ get; set; }
        public int IdProducto { get; set; }

        [ForeignKey("Cedula")]
        public Cliente Cliente { get; set; }

        [ForeignKey("IdEmpleado")]
        public Empleado Empleado { get; set; }

        [ForeignKey("IdProducto")]
        public Producto Producto { get; set; }
    }
}
