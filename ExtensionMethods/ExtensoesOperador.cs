using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workApi.Model;

namespace workApi.ExtensionMethods
{
    public static class ExtensoesOperador
    {

        public static IEnumerable<Operador> ClearAllPassword(this IEnumerable<Operador> operadores)
        {
            return operadores.Select(op => op.ClearPassword());
        }

        public static Operador ClearPassword(this Operador operador)
        {
            operador.Senha = null;
            return operador;
        }

    }
}
