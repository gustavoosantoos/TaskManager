using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Domain.Models.Entities;

namespace TaskManager.Domain.Models.Policies
{
    public class MaxLevelTaskPolicy
    {
        private const int MAX_LEVEL = 3;

        public static bool IsSatisfiedBy(Tarefa tarefa)
        {
            int startLevel = 1;
            int currentLevel = startLevel;

            Tarefa tarefaAux = tarefa.TarefaPai;

            while (tarefaAux != null)
            {
                tarefaAux = tarefaAux.TarefaPai;
                currentLevel++;
            }

            return currentLevel <= MAX_LEVEL;
        }
    }
}
