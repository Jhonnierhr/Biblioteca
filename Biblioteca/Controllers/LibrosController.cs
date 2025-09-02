using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    public class LibrosController : Controller
    {
        private readonly AplicationDbContent _context;

        public LibrosController(AplicationDbContent context)
        {
            _context = context;
        }

        // Muestra la lista de libros
        public async Task<IActionResult> Index()
        {
            var libros = await _context.Libros.ToListAsync();
            return View(libros);
        }

        // Muestra el formulario para crear un libro
        public IActionResult Create()
        {
            return View();
        }

        // Procesa la creación de un libro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libros.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // Muestra los detalles de un libro
        public async Task<IActionResult> Details(int id)
        {
            var libro = await _context.Libros.FirstOrDefaultAsync(l => l._idLibro == id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // Muestra el formulario para editar un libro
        public async Task<IActionResult> Edit(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // Procesa la edición de un libro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Libro libro)
        {
            if (id != libro._idLibro)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Libros.Any(e => e._idLibro == id))
                    {
                        return NotFound();
                    }
                    throw;
                }
            }
            return View(libro);
        }

        // Muestra el formulario para eliminar un libro
        public async Task<IActionResult> Delete(int id)
        {
            var libro = await _context.Libros.FirstOrDefaultAsync(l => l._idLibro == id);
            if (libro == null)
            {
                return NotFound();
            }
            return View(libro);
        }

        // Procesa la eliminación de un libro
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
