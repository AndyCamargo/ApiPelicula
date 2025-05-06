using ApiPeliculas.Modelos;

namespace ApiPeliculas.Repositorios.IRepositorio
{
    public interface ICategoriaRepositorio
    {
        ICollection<Categoria> GetCategorias();
        Categoria GetCategoria(int CategoriaId);
        bool ExisteCategoria(int id);
        bool ExisteCategoria(string nombre);

        bool CrearCategoria(Categoria categoria);
        bool ActualizarCategoria(Categoria categoria);
        bool BorraCategoria(Categoria categoria);
        bool Guardar();

    }
}
