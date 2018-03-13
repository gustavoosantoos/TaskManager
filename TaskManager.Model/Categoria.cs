using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Model
{
    public class Categoria : BaseEntity
    {
        public string Descricao { get; set; }
        public List<Tarefa> Tarefas { get; set; }
    }
}
