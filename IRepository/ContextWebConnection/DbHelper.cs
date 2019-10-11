using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workApi.IRepository.ContextWebConnection
{
    public class DbHelper
    {
        private DbHelper() { }
        private static DbHelper _instancia = null;

        public static DbHelper Instancia 
        {
            get 
            {
                if(WebContext.Current != null && WebContext.Current.Sessoes != null)
                {
                    if(WebContext.Current.Sessoes["SESSAO_INSTANCIA"] == null)
                    {
                        lock(new object())
                        {
                            _instancia = new DbHelper();
                            WebContext.Current.Sessoes["SESSAO_INSTANCIA"] = _instancia;
                        }

                        return (DbHelper)WebContext.Current.Sessoes["SESSAO_INSTANCIA"];
                    }
                }

                if (_instancia == null)
                {
                    _instancia = new DbHelper();
                }

                return _instancia;
            }
        }

        public string RetornaTeste()
        {
            return "Fincionou";
        }
    }
}
