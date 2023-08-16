using System;
using System.Collections.Generic;

namespace BiblioEntity.Models;

public partial class Genero
{
    public int IdGenero { get; set; }

    public string? Genero1 { get; set; }

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
