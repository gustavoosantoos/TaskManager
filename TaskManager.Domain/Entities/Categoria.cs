using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManager.Domain.Models.Entities
{
    [Table("Categorias")]
    public class Categoria : BaseEntity
    {
        [Required, MinLength(5), MaxLength(100)]
        public string Descricao { get; set; }

        public int MateriaId { get; set; }

        public virtual List<Tarefa> Tarefas { get; set; }

    }
}
