using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
    }
}
