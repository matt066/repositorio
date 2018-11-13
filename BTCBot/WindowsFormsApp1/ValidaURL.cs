using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    //Classe responsavel enviar a URL de acordo com a moeda informada
    public class ValidaURL
    {

        public String pegaUrl(string tipoMoeda, string tipoOperacao)
        {
            DominioUrl apiUrl = new DominioUrl();
            string urlValidada;
            urlValidada = apiUrl.FuncUrl(tipoMoeda, tipoOperacao);

            return urlValidada;
        }
    }
}
