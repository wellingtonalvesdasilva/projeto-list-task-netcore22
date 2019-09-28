using Microsoft.EntityFrameworkCore;
using ModelData.Model;
using System.Threading.Tasks;

namespace ModelData.Context
{
    /// <summary>
    /// Contexto do banco de dados
    /// </summary>
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        { }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
