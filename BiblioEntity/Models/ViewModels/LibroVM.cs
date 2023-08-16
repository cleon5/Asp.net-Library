using Microsoft.AspNetCore.Mvc.Rendering;
namespace BiblioEntity.Models.ViewModels
{
    public class LibroVM
    {
        public Libro oLibro { get;set; }
        public List<SelectListItem> oListaGeneros {  get; set; }
    }
}
