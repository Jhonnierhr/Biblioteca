using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;
using Biblioteca.Data;
using System.Threading.Tasks;

namespace Biblioteca.Controllers
{
    public class PrestamosController : Controller
    {
        private readonly AplicationDbContent _context;

        public PrestamosController(AplicationDbContent context)
        {
            _context = context;
        }

        // Listar todos los préstamos
        public async Task<IActionResult> Index()
        {
            var prestamos = await _context.Prestamos
                .Include(p => p.Libro)
                .Include(p => p.Usuario)
                .ToListAsync();
            return View(prestamos);
        }

        // Ver detalles de un préstamo
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var prestamo = await _context.Prestamos
                .Include(p => p.Libro)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m._idPrestamo == id);

            if (prestamo == null) return NotFound();

            return View(prestamo);
        }

        // Mostrar formulario de creación
        public IActionResult Create()
        {
            ViewData["Libros"] = _context.Libros.ToList();
            ViewData["Usuarios"] = _context.Usuarios.ToList();
            return View();
        }

        // Procesar creación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("_idLibro,_idUsuario,_fechaInicio,_fechaFin")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Prestamos.Add(prestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Libros"] = _context.Libros.ToList();
            ViewData["Usuarios"] = _context.Usuarios.ToList();
            return View(prestamo);
        }

        // Mostrar formulario de edición
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null) return NotFound();

            ViewData["Libros"] = _context.Libros.ToList();
            ViewData["Usuarios"] = _context.Usuarios.ToList();
            return View(prestamo);
        }

        // Procesar edición
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("_idPrestamo,_idLibro,_idUsuario,_fechaInicio,_fechaFin")] Prestamo prestamo)
        {
            if (id != prestamo._idPrestamo) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prestamo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrestamoExists(prestamo._idPrestamo))
                        return NotFound();
                    else
                        throw;
                }
            }
            ViewData["Libros"] = _context.Libros.ToList();
            ViewData["Usuarios"] = _context.Usuarios.ToList();
            return View(prestamo);
        }

        // Mostrar confirmación de eliminación
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var prestamo = await _context.Prestamos
                .Include(p => p.Libro)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m._idPrestamo == id);

            if (prestamo == null) return NotFound();

            return View(prestamo);
        }

        // Procesar eliminación
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo != null)
            {
                _context.Prestamos.Remove(prestamo);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // Verificar existencia de préstamo
        private bool PrestamoExists(int id)
        {
            return _context.Prestamos.Any(e => e._idPrestamo == id);
        }
    }
}