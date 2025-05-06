using ApiPeliculas.Modelos;

namespace ApiPeliculas.Repositorios.IRepositorio
{
    public interface IPeliculaRepositorio
    {
        //ICollection<Pelicula> GetPeliculas();
        ICollection<Pelicula> GetPeliculas(int pageNumber,int pageSize);
        int GetTotalPeliculas();
        ICollection<Pelicula> GetPeliculasEnCategoria(int CatId);
        IEnumerable<Pelicula> BuscarPelicula(string nombre);

        Pelicula GetPelicula(int peliculaId);
        bool ExistePelicula(int id);
        bool ExistePelicula(string nombre);

        bool CrearPelicula(Pelicula Pelicula);
        bool ActualizarPelicula(Pelicula Pelicula);
        bool BorrarPelicula(Pelicula Pelicula);
        bool Guardar();

    }
}
