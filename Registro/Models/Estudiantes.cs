using System.ComponentModel.DataAnnotations;

namespace Registro.Models
{
    public class Estudiantes
    {
        [Key]
        public int EstudiantesId { get; set; }
        [Required(ErrorMessage="Es obligatorio introducir el nombre")]
        public string Nombres { get; set; }
        [Range(minimum:1,maximum:12,ErrorMessage="Seleccione un semestre")]
        public int Semestre { get; set; }
    }
}