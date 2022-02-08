using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamenTecnico.Data;
using ExamenTecnico.Models;

namespace ExamenTecnico.Controllers
{
    public class NotasController : Controller
    {
        private readonly NotasContext _context;

        public NotasController(NotasContext context)
        {
            _context = context;
        }

        // GET: Notas

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            

            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }


            ViewData["CurrentFilter"] = searchString;

            var students = from s in _context.Notas
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Titulo.Contains(searchString)
                                       || s.Contenido.Contains(searchString));
            };
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Titulo);
                    break;
               // case "Date":
                  //  students = students.OrderBy(s => s.Contenido);
                   // break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.Fecha);
                    break;
                default:
                    students = students.OrderBy(s => s.Fecha);
                    break;
            }


            int pageSize = 5;
            return View(await PaginadoList<NotaModelo>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

  

        // GET: Notas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaModelo = await _context.Notas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notaModelo == null)
            {
                return NotFound();
            }

            return View(notaModelo);
        }

        // GET: Notas/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Notas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Contenido,Tema,Fecha")] NotaModelo notaModelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notaModelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notaModelo);
        }


        // GET: Notas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaModelo = await _context.Notas.FindAsync(id);
            if (notaModelo == null)
            {
                return NotFound();
            }
            return View(notaModelo);
        }

        // POST: Notas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Contenido,Tema,Fecha")] NotaModelo notaModelo)
        {
            if (id != notaModelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notaModelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaModeloExists(notaModelo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(notaModelo);
        }

        // GET: Notas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaModelo = await _context.Notas.FindAsync(id);
            _context.Notas.Remove(notaModelo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool NotaModeloExists(int id)
        {
            return _context.Notas.Any(e => e.Id == id);
        }
    }
}
