using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workApi.IRepository.ContextWebConnection
{
    public class WebContext
    {
        public static WebContext _instance = null;
        public DbWebContext Sessoes { get; }

        private WebContext()
        {
            if (Sessoes == null)
                Sessoes = new DbWebContext();
        }

        public static WebContext Current
        {
            get
            {
                lock (new object())
                {
                    _instance = new WebContext();
                }

                return _instance;
            }
        }


    }
}
