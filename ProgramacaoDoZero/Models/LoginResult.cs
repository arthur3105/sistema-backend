using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramacaoDoZero.Models
{
    public class LoginResult : BaseResult
    {
        public Guid usuarioGuid { get; set; }
    }
}
