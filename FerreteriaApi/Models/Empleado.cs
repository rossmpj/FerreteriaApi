using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaApi.Models
{
    public class Empleado
    {
        [Key]
        public string IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public bool Estado { get; set; }
        public string Correo { get; set; }
        [Display(Name = "Full Name Emp")]
        public string FullNameEmp
        {
            get
            {
                return Nombre + " " + Apellido;
            }
        }
        public ICollection<Ventas> Ventas { get; set; }
    }
}
