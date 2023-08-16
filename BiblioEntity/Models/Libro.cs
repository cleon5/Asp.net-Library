using System;
using System.Collections.Generic;

namespace BiblioEntity.Models;

public partial class Libro
{
    public int IdLibro { get; set; }

    public string? Nombre { get; set; }

    public string? Tipo { get; set; }

    public int? Pages { get; set; }

    public int? IdGenero { get; set; }

    public virtual Genero oGenero { get; set; }
}
