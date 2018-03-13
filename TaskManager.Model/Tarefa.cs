using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Model
{
    public class Tarefa : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool IsDone { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public DateTime? DataLimite { get; set; }
        public List<Tarefa> Tarefas { get; set; }
    }
}
