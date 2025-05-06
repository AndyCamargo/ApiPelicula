using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ApiPeliculas.Modelos
{
    /// <summary>
    /// este es el modelo para la base de datos 
    /// </summary>
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }

    }
}
