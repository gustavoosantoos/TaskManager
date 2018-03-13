using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Model
{
    public class Curso : BaseEntity
    {
        public string Nome { get; set; }
        public List<Materia> Materias { get; set; }
    }
}
