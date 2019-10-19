using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contas.Model.Entities
{
    public class CreditosEntity
    {
        [Key]
        public int idCredito { get; set; }
        public string nomeCredito { get; set; }
        public DateTime dataCredito { get; set; }
        public double valorCredito { get; set; }
    }
}
