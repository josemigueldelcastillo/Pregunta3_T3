using System.ComponentModel.DataAnnotations;

namespace T3_DelCastillo_JoseMiguel.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El titulo del libro es obligatorio.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El autor es obligatorio.")]
        public string Autor {  get; set; }
        [Required(ErrorMessage = "El tema es obligatorio.")]
        public string Tema { get; set; }
        [Required(ErrorMessage = "La editorial es obligatoria.")]
        public string Editorial { get; set; }
        [Required(ErrorMessage = "El año de publicacion es obligatorio.")]
        [Range(1900,3000,ErrorMessage = "El rango es entre 1900 y 3000")]
        public int AnioPublicacion { get; set; }
        [Required(ErrorMessage = "El numero de paginas es obligatorio.")]
        [Range(10, 1000, ErrorMessage = "El rango es entre 10 y 1000")]
        public int Paginas { get; set; }
        [Required(ErrorMessage = "La categoria es obligatoria.")]
        public string Categoria { get; set; }



    }
}
