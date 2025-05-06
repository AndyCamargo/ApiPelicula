using ApiPeliculas.Modelos;
using ApiPeliculas.Modelos.Dtos;
using AutoMapper;


namespace ApiPeliculas.PeliculasMappers
{
    public class PeliculasMapper :Profile
    {

        public PeliculasMapper()
        {
            CreateMap<Categoria, CategoriaDtos>().ReverseMap();
            CreateMap<Categoria, CrearCategoriaDtos>().ReverseMap();
            CreateMap<Pelicula, PeliculasDtos>().ReverseMap();
            CreateMap<Pelicula, CrearPeliculasDtos>().ReverseMap();
            CreateMap<Pelicula, ActualizarPeliculaDtos>().ReverseMap();
            //CreateMap<Usuario, UsuarioDtos>().ReverseMap();
            //CreateMap<Usuario, UsuarioLoginDtos>().ReverseMap();
            CreateMap<AppUsuario, UsuarioDatosDtos>().ReverseMap();
            CreateMap<AppUsuario, UsuarioDtos>().ReverseMap();
        }

    }
}
