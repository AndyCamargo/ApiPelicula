using ApiPeliculas.Data;
using ApiPeliculas.Modelos;
using ApiPeliculas.Repositorios.IRepositorio;

namespace ApiPeliculas.Repositorios
{
    public class CategoriaRepositorio :ICategoriaRepositorio
    {
        private readonly ApplicationDBContext _bd;

        public CategoriaRepositorio(ApplicationDBContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarCategoria(Categoria categoria)
        {
            categoria.FechaCreacion = DateTime.Now;
            //arregalr problema del put
            var categoriaExistente = _bd.Categorias.Find(categoria.Id);
            if (categoriaExistente != null) 
            {
           _bd.Entry(categoriaExistente).CurrentValues.SetValues(categoria);
            }
            else
            {
                _bd.Categorias.Update(categoria);
            }
                
            return Guardar();
        }

        public bool BorraCategoria(Categoria categoria)
        {
          _bd.Categorias.Remove(categoria);
            return Guardar();
        }

        public bool CrearCategoria(Categoria categoria)
        {
            categoria.FechaCreacion = DateTime.Now;
            _bd.Categorias.Add(categoria);
            return Guardar();
        }

        public bool ExisteCategoria(int id)
        {
            return _bd.Categorias.Any(c => c.Id == id);
        }

        public bool ExisteCategoria(string nombre)
        {
            bool valor = _bd.Categorias.Any(c=> c.Nombre.ToLower().Trim() == nombre.ToLower());//convierto en minuscula y comparp si existe por nombre
            return valor;
        }

        public Categoria GetCategoria(int CategoriaId)
        {
            return _bd.Categorias.FirstOrDefault(c=> c.Id == CategoriaId);
        }

        public ICollection<Categoria> GetCategorias()
        {
            return _bd.Categorias.OrderBy(c => c.Nombre).ToList();
        }

        public bool Guardar()
        {
           return _bd.SaveChanges() >=0 ? true : false; //// si es mayor a cero es verdadero si es cero retorna falso y no se puede guardar los cambios
        }

       
    }
}
