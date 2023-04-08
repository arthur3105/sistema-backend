using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramacaoDoZero.Models
{
    public class CadastroRequest
    {
        public string nome { get; set; }

        public string sobrenome { get; set; }

        public string email { get; set; }

        public string telefone { get; set; }

        public string genero { get; set; }

        public string senha { get; set; }
    }
}
