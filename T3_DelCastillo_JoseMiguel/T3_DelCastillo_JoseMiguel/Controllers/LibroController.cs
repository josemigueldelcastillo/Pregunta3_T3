using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using T3_DelCastillo_JoseMiguel.Datos;
using T3_DelCastillo_JoseMiguel.Models;
using Microsoft.AspNetCore.Authorization;
using T3_DelCastillo_JoseMiguel.Services;

namespace T3_DelCastillo_JoseMiguel.Controllers
{
    public class LibroController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly OpenAIService _openAIService;

        public LibroController(ApplicationDbContext db, OpenAIService openAIService)
        {
            _db = db;
            _openAIService = openAIService;
        }

        public IActionResult Index()
        {
            IEnumerable<Libro> lista = _db.Libro;
            return View(lista);
        }

        [Authorize]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _db.Libro.Add(libro);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        [Authorize]
        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Libro.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _db.Libro.Update(libro);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        [Authorize]
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Libro.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(Libro libro)
        {
            if (libro == null)
            {
                return NotFound();
            }
            _db.Libro.Remove(libro);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ObtenerResumenPorNombre(string nombre)
        {
            try
            {
                var resumen = await _openAIService.GetSummaryByNameAsync(nombre);

                return Json(new { resumen });
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error al obtener el resumen del libro:", ex.Message);

                return BadRequest("Error al obtener el resumen del libro");
            }
        }
    }
}

