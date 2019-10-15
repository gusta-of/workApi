using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workApi.Model
{
    public class Operador
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
    }
}
