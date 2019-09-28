using Core.Architecture;
using ModelData.Context;
using ModelData.Model;

namespace Repository
{
    /// <summary>
    /// Repositorio da tabela Tarefa
    /// </summary>
    public class TaskRepository : GenericRepository<TaskContext, Tarefa>, IGenericRepository<Tarefa>
    {
        public TaskRepository(TaskContext context) : base(context)
        { }
    }
}
