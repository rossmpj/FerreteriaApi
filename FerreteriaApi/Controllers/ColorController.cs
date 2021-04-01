using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ColorController(ApplicationDBContext context)
        {
            _context = context;
        }
        // GET: ColorController
        [HttpGet]
        public async Task<IActionResult> GetColores()
        {
            try
            {
                var list_colores = await _context.Colores.Select(p => new
                {
                    IdColor = p.IdColor,
                    Nombre = p.Nombre
                }).ToListAsync();

                return Ok(list_colores);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /*public ActionResult Index()
        {
            return View();
        }

        // GET: ColorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ColorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ColorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ColorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ColorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ColorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/
    }
}
