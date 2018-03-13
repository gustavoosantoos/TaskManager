using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManager.Domain.Models.Entities
{
    [Table("Cursos")]
    public class Curso : BaseEntity
    {
        [Required]
        [MinLength(5, ErrorMessage="O campo deve ter ao menos {1} caracteres.")]
        [MaxLength(60, ErrorMessage="O campo deve ter no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Column("Codigo_Usuario")]
        public string CodigoUsuario { get; set; }

        public virtual List<Materia> Materias { get; set; }
    }
}
