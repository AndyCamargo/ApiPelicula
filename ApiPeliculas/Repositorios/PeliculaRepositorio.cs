using ApiPeliculas.Data;
using ApiPeliculas.Modelos;
using ApiPeliculas.Repositorios.IRepositorio;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculas.Repositorios
{
    public class PeliculaRepositorio :IPeliculaRepositorio
    {
        private readonly ApplicationDBContext _bd;

        public PeliculaRepositorio(ApplicationDBContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarPelicula(Pelicula pelicula)
        {
            pelicula.FechaCreacion = DateTime.Now;

            //arregalr problema del put
            var peliculaExistente = _bd.Pelicula.Find(pelicula.Id);
            if (peliculaExistente != null)
            {
                _bd.Entry(peliculaExistente).CurrentValues.SetValues(pelicula);
            }
            else
            {
                _bd.Pelicula.Update(pelicula);
            }

            return Guardar();
        
        }

    

        public bool BorrarPelicula(Pelicula pelicula)
        {
          _bd.Pelicula.Remove(pelicula);
            return Guardar();
        }

        public IEnumerable<Pelicula> BuscarPelicula(string nombre)
        {
            IQueryable<Pelicula> query = _bd.Pelicula;
            if (!string.IsNullOrEmpty(nombre)) 
            {
                query = query.Where(e => e.Nombre.Contains(nombre) || e.Descripcion.Contains(nombre));
            }      
        return query.ToList();
        }

        public bool CrearPelicula(Pelicula pelicula)
        {
            pelicula.FechaCreacion = DateTime.Now;
            _bd.Pelicula.Add(pelicula);
            return Guardar();
        }

        public bool ExistePelicula(int id)
        {
            return _bd.Pelicula.Any(c => c.Id == id);
        }

        public bool ExistePelicula(string nombre)
        {
            bool valor = _bd.Pelicula.Any(c=> c.Nombre.ToLower().Trim() == nombre.ToLower());//convierto en minuscula y comparp si existe por nombre
            return valor;
        }

        public Pelicula GetPelicula(int PeliculaId)
        {
            return _bd.Pelicula.FirstOrDefault(c => c.Id == PeliculaId);    

        }

        public ICollection<Pelicula> GetPeliculas(int pageNumber,int pageSize)
        {

            return _bd.Pelicula.OrderBy(c => c.Nombre).Skip((pageNumber -1)*pageSize).Take(pageSize).ToList();
          
        }


        public int GetTotalPeliculas() 
        {
            return _bd.Pelicula.Count();
        
        }
         



        //metodo anterior
        //public ICollection<Pelicula> GetPeliculas()
        //{
        //   
        //    return _bd.Pelicula.OrderBy(c => c.Nombre).ToList();
        //}


        public ICollection<Pelicula> GetPeliculasEnCategoria(int CatId)
        {
            return _bd.Pelicula.Include(ca => ca.Categoria).Where(ca =>ca.categoriaId == CatId).ToList();

        }

        public bool Guardar()
        {
           return _bd.SaveChanges() >=0 ? true : false; //// si es mayor a cero es verdadero si es cero retorna falso y no se puede guardar los cambios
        }
    }
}
