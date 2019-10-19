using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contas.Model.Entities
{
    public class InvestimentoEntity
    {
        [Key]
        public int idInvestimento { get; set; }
        public string nomeInvestimento { get; set; }
        public DateTime dataInvestimento { get; set; }
        public double valorInvestimento { get; set; }
    }
}
