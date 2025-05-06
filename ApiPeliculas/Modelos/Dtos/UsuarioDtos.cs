using System.ComponentModel.DataAnnotations;
// este dto es para hacer la consulta de la base de datos con los campos requeridos 
namespace ApiPeliculas.Modelos.Dtos
{
    public class UsuarioDtos
    {
        [Key]
        //public int Id { get; set; }
        public string Id { get; set; }
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
      //public string Passwors { get; set; }
        //public string Role { get; set; }
    }
}
