using ApiPeliculas.Modelos;
using ApiPeliculas.Modelos.Dtos;

namespace ApiPeliculas.Repositorios.IRepositorio
{
    public interface IUsuarioRepositorio
    {
        ICollection<AppUsuario> GetUsuarios();
        AppUsuario GetUsuario(string usuarioID);
        bool IsUniqueUser(string usuario);
        Task<UsuarioLoginRespuestaDTOS> Login(UsuarioLoginDtos usuarioLoginDtos);
        Task<UsuarioDatosDtos> Registro(UsuarioRegistroDtos usuarioRegistroDtos);

    }
}
