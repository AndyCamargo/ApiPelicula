﻿using System.ComponentModel.DataAnnotations;

namespace ApiPeliculas.Modelos
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string NombreUsuario { get; set; }    
        public string Nombre { get; set; }
        //public string Passwors { get; set; }
        public string Role {  get; set; }
        public string Password { get; set; }
    }
}

