using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workApi.IRepository.ContextWebConnection
{
    public class DbWebContext
    {
        public object? this[string name]
        {
            get
            {
                if (Sessoes == null)
                {
                    Sessoes = new Dictionary<string, object>();
                }

                if(Sessoes.ContainsKey(name))
                    return Sessoes[name];

                return null;
            }
            set { Sessoes.Add(name, value); }
        }

        private static Dictionary<string, object> Sessoes = null;

        public int Count => Sessoes.Any() ? Sessoes.Count() : 0;
        public IEnumerator GetEnumerator() => Sessoes.GetEnumerator();
    }
}
