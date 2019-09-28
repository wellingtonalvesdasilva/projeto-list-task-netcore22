using AutoMapper;
using Business.Interface;
using Core.Architecture;
using ModelData.Model;
using ModelData.Model.ViewModel;
using System;
using Util;

namespace Business
{
    public class TaskBusiness : ITaskBusiness
    {
        private readonly IGenericRepository<Tarefa> _taskRepository;
        private readonly IMapper _mapper;

        public TaskBusiness(IGenericRepository<Tarefa> taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Realiza a marcação ou desmarcação de uma tarefa como concluida
        /// </summary>
        /// <param name="id"></param>
        /// <param name="situacao"></param>
        public void MarcarOuDesmarcar(long id, int situacao)
        {
            var tarefa = _taskRepository.ObterPorID(id);

            if (situacao == (int)Enumeracao.ETipoDeAcao.Marcar)
            {
                tarefa.Status = (int)Enumeracao.ESituacao.Finalizado;
                tarefa.DataDeConclusao = DateTime.Now;
            }
            else
            {
                tarefa.Status = (int)Enumeracao.ESituacao.Ativo;
                tarefa.DataDeConclusao = null;
            }

            _taskRepository.Editar(tarefa);
        }

        /// <summary>
        /// Realiza a alteração do conteudo de uma tarefa
        /// </summary>
        /// <param name="viewModel"></param>
        public void Alterar(TarefaViewModel viewModel)
        {
            var tarefa = _taskRepository.ObterPorID(viewModel.Id);

            //Utilizar automapper futur
            tarefa.Titulo = viewModel.Titulo;
            tarefa.Descricao = viewModel.Descricao;

            _taskRepository.Editar(tarefa);
        }

        /// <summary>
        /// Cria uma tarefa apartir de uma view model
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public Tarefa Criar(TarefaViewModel viewModel)
        {
            var tarefa = _mapper.Map<Tarefa>(viewModel);
            tarefa.DataDeCriacao = DateTime.Now;
            tarefa.Status = (int)Enumeracao.ESituacao.Ativo;
            _taskRepository.Criar(tarefa);

            return tarefa;
        }
    }
}
