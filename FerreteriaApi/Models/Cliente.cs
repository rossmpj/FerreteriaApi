using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaApi.Models
{
    public class Cliente
    {
        [Key]
        [StringLength(10)]
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        [Display(Name = "Full Name Client")]
        public string FullNameClient
        {
            get
            {
                return Nombre + " " + Apellido;
            }
        }
        public ICollection<Ventas> Ventas { get; set; }
    }
}
