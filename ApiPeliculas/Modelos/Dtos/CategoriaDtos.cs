using System.ComponentModel.DataAnnotations;

namespace ApiPeliculas.Modelos.Dtos
{
    public class CategoriaDtos
    {
       
            [Key]
            public int Id { get; set; }
            [Required(ErrorMessage ="el nomnbre es obligatorio")]
            [MaxLength(100,ErrorMessage ="El numero maximo ded caracteres es de 100")]
            public string Nombre { get; set; }
            [Required]
            public DateTime FechaCreacion { get; set; }

        

    }
}
