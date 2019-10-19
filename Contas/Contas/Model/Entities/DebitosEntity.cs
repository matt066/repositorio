using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contas.Model.Entities
{
    public class DebitosEntity
    {
        [Key]
        public int idDebito { get; set; }
        public string nomeDebito { get; set; }
        public DateTime dataDebito { get; set; }
        public double valorDebito { get; set; }

    }
}
