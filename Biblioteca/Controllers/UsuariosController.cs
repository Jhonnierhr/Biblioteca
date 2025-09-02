using Microsoft.AspNetCore.Mvc;
using Biblioteca.Models;
using Biblioteca.Data;
using System.Linq;

namespace Biblioteca.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AplicationDbContent _context;

        public UsuariosController(AplicationDbContent context)
        {
            _context = context;
        }

        // Listar todos los usuarios
        public IActionResult Index()
        {
            var usuarios = _context.Usuarios.ToList();
            return View(usuarios);
        }

        // Mostrar detalles de un usuario
        public IActionResult Details(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
                return NotFound();
            return View(usuario);
        }

        // Mostrar formulario de creación
        public IActionResult Create()
        {
            return View();
        }

        // Procesar creación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // Mostrar formulario de edición
        public IActionResult Edit(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
                return NotFound();
            return View(usuario);
        }

        // Procesar edición
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Usuario usuario)
        {
            if (id != usuario._idUsario)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(usuario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // Mostrar confirmación de eliminación
        public IActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
                return NotFound();
            return View(usuario);
        }

        // Procesar eliminación
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}