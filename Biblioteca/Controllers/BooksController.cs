using Microsoft.AspNetCore.Mvc;
using Biblioteca.Models;
using Biblioteca.Data;

namespace Biblioteca.Controllers
{
    public class BooksController : Controller
    {
        BooksData _LibroDatos =  new BooksData();
        public IActionResult List()
        {
            List<LibroModelo> listaLibro = _LibroDatos.ListBook();

            return View(listaLibro);
        }
        public IActionResult GetOne(int idLibro)
        {   
            LibroModelo libro = _LibroDatos.GetBook(idLibro);
            return View(libro);
        }
        public IActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save(LibroModelo libro)
        {

            if (!ModelState.IsValid)
                return View();

            if (libro.Id_Libro > 0)
            {

                bool resp = _LibroDatos.UpdateBook(libro);

                if (resp == true)
                    return RedirectToAction("List");
                else
                    return View();
            }
            else
            {
                bool resp = _LibroDatos.SaveBook(libro);

                if (resp == true)
                    return RedirectToAction("List");
                else
                    return View();
            }
            
        }
        public IActionResult Edit(int idLibro)
        {
            LibroModelo libro = _LibroDatos.GetBook(idLibro);
            return View(libro);
        }
        [HttpPost]
        public IActionResult Edit(LibroModelo libro)
        {
            _LibroDatos.UpdateBook(libro);
            return View();
        }
        public IActionResult Delete(int idLibro)
        {
            bool rsp = _LibroDatos.DeleteBook(idLibro);
            if(!rsp)
                return View();
            else
                return RedirectToAction("List");
        }
    }
}
