using System;
using Util;

namespace ModelData.Model.ViewModel
{
    /// <summary>
    /// Tarefa viewmodel para representar o modelo de dados que será utilizado pela view
    /// muitas vezes é melhor ser feito dessa forma, para não expor todas as informações do banco, e suas estruturas
    /// </summary>
    public class TarefaViewModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public long Id { get; set; }

        //Propriedade privadas, não retornamos no json para o cliente
        public int Status { private get; set; }
        public DateTime? DataDeConclusao { private get; set; }
        public DateTime DataDeCriacao { private get; set; }

        public bool EstaFinalizado
        {
            get
            {
                return Status == (int)Enumeracao.ESituacao.Finalizado;
            }
        }

        public string DataDeConclusaoPt
        {
            get
            {
                if (DataDeConclusao.HasValue)
                    return string.Format("{0: dd/MM/yyyy HH:mm}", DataDeConclusao);
                return "-";
            }
        }

        public string DataDeCriacaoPt
        {
            get
            {
                return string.Format("{0: dd/MM/yyyy HH:mm}", DataDeCriacao);
            }
        }
    }
}
