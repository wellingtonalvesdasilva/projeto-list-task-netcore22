using AutoMapper;
using Core.Architecture;
using Microsoft.AspNetCore.Mvc;
using ModelData.Model.Arquitetura;
using System;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace WebApp.Controllers.Arquitetura
{
    /// <summary>
    /// Classe base para todas as APIs da aplicação
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TViewModal"></typeparam>
    public class BaseApiController<TModel, TViewModal> : ControllerBase 
        where TModel : BaseEntity
        where TViewModal : class
    {
        /// <summary>
        /// Repositório dinâmico de acordo com o modelo de dados
        /// </summary>
        public readonly IGenericRepository<TModel> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor da BaseAPI que será utilizado por todas as APIs
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public BaseApiController(IGenericRepository<TModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obter todos os dados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var todosAtivos = _repository.ObterTodos().Where(c => c.Status != (int)Enumeracao.ESituacao.Cancelado);
            return Ok(PrepararRetorno(todosAtivos));
        }

        /// <summary>
        /// Obter o dado por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            var data = _repository.ObterPorID(id);

            if (data == null)
                return NotFound("Informação não localizada");

            return Ok(PrepararRetorno(data));
        }


        /// <summary>
        /// Obter o dado por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var data = _repository.ObterPorID(id);

            if (data == null)
                return NotFound("Informação não localizada");

            //Não existe delete fisico, logo todos modelos são removidos logicamente
            data.DataDeRemocao = DateTime.Now;
            data.Status = (int)Enumeracao.ESituacao.Cancelado;
            _repository.Editar(data);

            return Ok();
        }

        /// <summary>
        /// Realiza o mapeamento do modelo para ViewModel
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private TViewModal PrepararRetorno(TModel model)
        {
            return _mapper.Map<TViewModal>(model);
        }

        /// <summary>
        /// Realiza o mapeamento de IQueryable do modelo para lista de ViewModel
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        private IList<TViewModal> PrepararRetorno(IQueryable<TModel> models)
        {
            var lista = new List<TViewModal>();
            foreach (var model in models)
                lista.Add(PrepararRetorno(model));
            return lista;
        }
    }
}
