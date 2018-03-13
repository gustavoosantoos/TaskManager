using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.Domain.Models.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, DataType(DataType.Text), DisplayName("Data de Criação")]
        public DateTime DataCriacao { get; set; }

        [Required, DataType(DataType.Text), DisplayName("Ultima alteração")]
        public DateTime DataUltimaAlteracao { get; set; }
    }
}
