using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Model
{
    public class Materia : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Categoria> Categorias { get; set; }
    }
}
