namespace ApiPeliculas.Modelos.Dtos
{
    public class UsuarioLoginRespuestaDTOS
    {
        public UsuarioDatosDtos Usuario { get; set; }
        public string Role { get;set; }
        public string Token { get;set; }
    }
}
