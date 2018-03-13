using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManager.Domain.Models.Entities
{
    [Table("Materias")]
    public class Materia : BaseEntity
    {
        [Required, MinLength(5), MaxLength(30)]
        public string Nome { get; set; }

        [MaxLength(300)]
        public string Descricao { get; set; }

        public int CursoId { get; set; }

        public virtual List<Categoria> Categorias { get; set; }

    }
}
