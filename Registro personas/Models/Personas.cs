using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;

namespace Registro_personas.Models;

public class Personas
{
    [Key]
    public int PersonaId { get; set; }

    [Required(ErrorMessage = "Favor de introducir un nombre.")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "Favor de introducir un apellido.")]
    public string Apellido { get; set; }

    [Range(1, 99, ErrorMessage = "Favor de introducir una edad de 1 a 99.")]
    public int Edad { get; set; }
}
