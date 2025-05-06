using System.ComponentModel.DataAnnotations;
///este dto es para hacer el insert ala base de datos con los campos que espera 
namespace ApiPeliculas.Modelos.Dtos
{
    public class UsuarioRegistroDtos
    {
        [Required(ErrorMessage ="El usuario es obligatorio")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El password es obligatorio")]
        public string Password { get; set; }
        public string Role { get; set; }
      
    }
}
