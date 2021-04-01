using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaApi.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Medida { get; set; }
        public string Imagen { get; set; }
        public int Stock { get; set; }
        public int IdColor { get; set; }
        public int IdCategoria { get; set; }
        public int IdMarca { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }

        [ForeignKey("IdMarca")]
        public Marca Marca { get; set; }

        [ForeignKey("IdColor")]
        public Color Color { get; set; }

        public ICollection<Ventas> Ventas { get; set; }
    }
}