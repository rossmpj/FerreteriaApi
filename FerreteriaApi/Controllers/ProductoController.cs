using FerreteriaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ProductoController(ApplicationDBContext context)
        {
            _context = context;
        }
        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            try
            {
                var list_productos = await _context.Productos
                    .Join(
                        _context.Marcas,
                        marca => marca.IdMarca,
                        producto => producto.IdMarca,
                        (producto, marca) => new 
                        { 
                            idMarca = marca.Nombre,
                            idCategoria = producto.IdCategoria,
                            nombre = producto.Nombre,
                            stock = producto.Stock,
                            medida = producto.Medida,
                            precio = producto.Precio,
                            idColor = producto.IdColor,
                            idProducto = producto.IdProducto,
                            estado = producto.Estado
                        }
                    )
                    .Join(
                         _context.Categorias,
                         producto => producto.idCategoria,
                         categoria => categoria.IdCategoria,
                         (producto, categoria) => new
                         {
                             idMarca = producto.idMarca,
                             nombre = producto.nombre,
                             stock = producto.stock,
                             medida = producto.medida,
                             idCategoria = categoria.Nombre,
                             precio = producto.precio,
                             idColor = producto.idColor,
                             idProducto = producto.idProducto,
                             estado = producto.estado
                         }
                    )
                    .Join(
                        _context.Colores,
                        producto => producto.idColor,
                        color => color.IdColor,
                        (producto, color) => new
                        {
                            idMarca = producto.idMarca,
                            nombre = producto.nombre,
                            stock = producto.stock,
                            medida = producto.medida,
                            idCategoria = producto.idCategoria,
                            precio = producto.precio,
                            idColor = color.Nombre,
                            idProducto = producto.idProducto,
                            estado = producto.estado
                        }
                    ).Where(s => s.estado == true).ToListAsync();
                return Ok(list_productos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("totalproductos"), HttpGet]
        public async Task<IActionResult> GetTotalProductos()
        {
            try
            {
                var list_productos = await _context.Productos.CountAsync();
                return Ok(list_productos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var producto = await _context.Productos.FindAsync(id);
                if (producto == null)
                {
                    return NotFound();
                }
                else
                {
                    var query = await _context.Productos
                     .Select(z => new
                     {
                         z.IdCategoria,
                         z.IdProducto,
                         z.IdColor,
                         z.IdMarca,
                         z.Nombre,
                         z.Precio,
                         z.Medida,
                         z.Stock
                     }).Where(s => s.IdProducto == id).FirstAsync();
                    return Ok(query);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto producto)
        {
            try
            {
                producto.Estado = true;
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return Ok(producto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Producto producto)
        {
            try
            {
                if (id != producto.IdProducto)
                {
                    return NotFound();
                }
                _context.Update(producto);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El producto se actualizó con éxito" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var producto = await _context.Productos.FindAsync(id);
                if(producto == null)
                {
                    return NotFound();
                }
                producto.Estado = false;
                await _context.SaveChangesAsync();
                return Ok(new { message = "El producto se eliminó con éxito" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
