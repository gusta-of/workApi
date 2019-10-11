using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workApi.IRepository.ContextWebConnection
{
    public class DbWebContext : ICollection
    {
        public object this[string name]
        {
            get { return Sessoes[name]; }
            set { Sessoes.Add(name, value); }
        }

        private static Dictionary<string, object> Sessoes
        {
            get
            {
                if (Sessoes == null) return new Dictionary<string, object>();
                return Sessoes;
            }
        }

        public int Count => Sessoes.Any() ? Sessoes.Count() : 0;

        public bool IsSynchronized => false;

        public object SyncRoot => true;

        public void CopyTo(Array array, int index) { return; }

        public IEnumerator GetEnumerator()
        {
            return Sessoes.GetEnumerator();
        }
    }
}
