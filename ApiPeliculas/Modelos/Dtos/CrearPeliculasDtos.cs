using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPeliculas.Modelos.Dtos
{
    public class CrearPeliculasDtos
    {
       
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Duracion { get; set; }
        public string? RutaImagen { get; set; }
        public IFormFile Imagen {  get; set; }
        public enum CrearTipoClasificacion { Siete, Trece, Dieciseis, Dieciocho }
        public CrearTipoClasificacion Clasificacion { get; set; }
       
        // relacion con categoria
        public int categoriaId { get; set; }
      
    }
}
