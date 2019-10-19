using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public double Salario { get; set; }

        //A declaração virtual é o que deixa o construtor ser sobreescrito
        public virtual double GetBonificacao()
        {
            return Salario * 0.10;
        }
    }
}
