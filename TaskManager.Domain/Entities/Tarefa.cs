﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManager.Domain.Models.Entities
{
    [Table("Tarefas")]
    public class Tarefa : BaseEntity
    {
        public Tarefa()
        {
            IsDone = false;
        }

        [Required, MinLength(5), MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(500)]
        public string Descricao { get; set; }
        
        [Required]
        public bool IsDone { get; set; }

        [DataType(DataType.Text)]
        public DateTime? DataFinalizacao { get; set; }

        [DataType(DataType.Text)]
        public DateTime? DataLimite { get; set; }

        public int CategoriaId { get; set; }

        public virtual Tarefa TarefaPai { get; set; }
    }
}