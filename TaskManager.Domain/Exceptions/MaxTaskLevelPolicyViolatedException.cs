using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Domain.Exceptions
{
    public class MaxTaskLevelPolicyViolatedException : Exception
    {
        public MaxTaskLevelPolicyViolatedException() : base("A tarefa atingiu o limite máximo de sub-tarefas permitidas.")
        {
        }

        public MaxTaskLevelPolicyViolatedException(string message) : base(message)
        {
        }
    }
}
