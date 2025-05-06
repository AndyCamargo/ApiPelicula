using System.ComponentModel.DataAnnotations;

namespace ApiPeliculas.Modelos.Dtos
{
    public class CrearCategoriaDtos
    {

       
        [Required(ErrorMessage = "el nomnbre es obligatorio")]
        [MaxLength(100, ErrorMessage = "El numero maximo ded caracteres es de 100")]
        public string Nombre { get; set; }
       
    }
}
