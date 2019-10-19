using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Contas.Model.Entities
{
    public class ResultadoMesEntity
    {
        [Key]
        public int idResultadoMes { get; set; }
        public double debitos { get; set; }
        public double saldo { get; set; }
    }
}
