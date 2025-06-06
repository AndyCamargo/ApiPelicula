﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPeliculas.Modelos.Dtos
{
    public class PeliculasDtos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Duracion { get; set; }
        public string? RutaImagen { get; set; }
        public string? RutaLocalIMagen { get; set; }
        public enum TipoClasificacion { Siete, Trece, Dieciseis, Dieciocho }
        public TipoClasificacion Clasificacion { get; set; }
        public DateTime FechaCreacion { get; set; }

        // relacion con categoria
        public int categoriaId { get; set; }
      
    }
}
