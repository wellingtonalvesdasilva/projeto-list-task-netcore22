using ModelData.Model.Arquitetura;
using System;

namespace ModelData.Model
{
    /// <summary>
    /// Representação da tabela "Task" do banco de dados
    /// </summary>
    public class Tarefa : BaseEntity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataDeConclusao { get; set; }
    }
}
