using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyControl.Api.Contract.Usuario
{
    public class UsuarioRequestContract : UsuarioLoginRequestContract
    {
        public DateTime? DataInativacao {get; set;}
    }
}