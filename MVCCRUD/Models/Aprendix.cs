using System;
using System.Collections.Generic;

namespace MVCCRUD.Models;

public partial class Aprendix
{
    public int IDaprendiz { get; set; }

    public string NombreAprendiz { get; set; } = null!;

    public string ApellidoAprendiz { get; set; } = null!;
}
