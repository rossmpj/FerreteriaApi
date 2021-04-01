using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaApi.Models
{
    public class Marca
    {
        [Key]
        public int IdMarca { get; set; }
        public string Nombre { get; set; }
        public ICollection<Producto> Productos { get; set; }
    }
}