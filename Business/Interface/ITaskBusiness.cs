using ModelData.Model;
using ModelData.Model.ViewModel;

namespace Business.Interface
{
    /// <summary>
    /// Interface da regra de negócio de tarefas
    /// </summary>
    public interface ITaskBusiness
    {
        void MarcarOuDesmarcar(long id, int situacao);
        void Alterar(TarefaViewModel viewModel);
        Tarefa Criar(TarefaViewModel viewModel);
    }
}
