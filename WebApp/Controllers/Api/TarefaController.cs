using AutoMapper;
using Business.Interface;
using Core.Architecture;
using Microsoft.AspNetCore.Mvc;
using ModelData.Model;
using ModelData.Model.ViewModel;
using WebApp.Controllers.Arquitetura;

namespace WebApp.Controllers.Api
{
    /// <summary>
    /// API exclusivamente para trabalhar com tarefa
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : BaseApiController<Tarefa, TarefaViewModel>
    {
        private readonly ITaskBusiness _taskBusiness;

        /// <summary>
        /// Construtor da tarefa controller que receber por injeção de dependência aquilo que precisa para funcionar
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        /// <param name="taskBusiness"></param>
        public TarefaController(
            IGenericRepository<Tarefa> repository, 
            IMapper mapper,
            ITaskBusiness taskBusiness) : base(repository, mapper)
        {
            _taskBusiness = taskBusiness;
        }

        /// <summary>
        /// Marcar ou Desmarcar uma tarefa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="situacao">0 - desmarcar ou 1 - marcar</param>
        /// <returns></returns>
        [HttpPut("{id}/marcaroudesmarcar/{situacao}")]
        public IActionResult MarcarOuDesmarcar(long id, int situacao)
        {
            var tarefa = _repository.ObterPorID(id);
            if (tarefa == null)
                return NotFound("Informação não localizada");

            _taskBusiness.MarcarOuDesmarcar(id, situacao);

            return NoContent();
        }

        /// <summary>
        /// Criar uma tarefa
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public IActionResult Post([FromBody] TarefaViewModel viewModel)
        {
            if (viewModel == null)
                return BadRequest("Informação nula");

            var tarefa = _taskBusiness.Criar(viewModel);

            return CreatedAtRoute("Get", new { tarefa.Id }, tarefa);
        }

        /// <summary>
        /// Atualizar uma tarefa
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] TarefaViewModel viewModel)
        {
            if (viewModel == null)
                return BadRequest("Informação nula");

            var data = _repository.ObterPorID(viewModel.Id);
            if (data == null)
                return NotFound("Informação não localizada");

            _taskBusiness.Alterar(viewModel);

            return NoContent();
        }
    }
}
