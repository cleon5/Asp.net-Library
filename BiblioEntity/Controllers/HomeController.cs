using BiblioEntity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using BiblioEntity.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BiblioEntity.Controllers
{
    public class HomeController : Controller
    {

        private readonly LibraryContext _DBContext;

        public HomeController(LibraryContext libraryContext)
        {
            _DBContext = libraryContext;
        }

        public IActionResult Index()
        {
            List<Libro> lista = _DBContext.Libros.Include(x => x.oGenero).ToList();
            return View(lista);
        }
        [HttpGet]
        public IActionResult GetLibro(int IdLibro)
        {
            LibroVM libro = new LibroVM()
            {
                oLibro = new Libro(),
                oListaGeneros = _DBContext.Generos.Select(gen => new SelectListItem()
                {
                    Text = gen.Genero1,
                    Value = gen.IdGenero.ToString()
                }).ToList()
            };

            if (IdLibro !=0 )
            {
                libro.oLibro = _DBContext.Libros.Find(IdLibro);
            }

            return View(libro) ;
        }
        [HttpPost]
        public IActionResult Save(LibroVM libroVM)
        {
            if(libroVM.oLibro.IdLibro == 0) {
                _DBContext.Libros.Add(libroVM.oLibro);
            }
            else
            {
                _DBContext.Libros.Update(libroVM.oLibro);
            }

            _DBContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Delete(int idLibro)
        {
            Libro libro = _DBContext.Libros.Find(idLibro);
            _DBContext.Libros.Remove(libro);
            _DBContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}