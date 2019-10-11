using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workApi.IRepository.ContextWebConnection
{
    public class WebContext
    {
        private static WebContext _instance = null;
        public DbWebContext Sessoes { get; }
        public static WebContext Current 
        {
            get 
            {
                lock(new object())
                {
                    _instance = new WebContext();
                }

                return _instance;
            }       
        }

        
    }
}
