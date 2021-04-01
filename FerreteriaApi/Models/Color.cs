using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaApi.Models
{
    public class Color
    {
        [Key]
        public int IdColor { get; set; }
        public string Nombre { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}
