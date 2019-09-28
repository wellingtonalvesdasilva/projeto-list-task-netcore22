using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelData.Model.Arquitetura
{
    /// <summary>
    /// Classe base de todos os modelos de entidades
    /// </summary>
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public DateTime? DataDeEdicao { get; set; }
        public DateTime? DataDeRemocao { get; set; }
        public int Status { get; set; }
    }
}
