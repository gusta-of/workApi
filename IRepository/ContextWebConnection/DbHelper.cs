using BibliotecaDeClasses.ConnectionContext;
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
               if(ManipuladorDeContexto.Current != null)
                {

                }
                return null;
            }
        }

        public string RetornaTeste()
        {
            return "Fincionou";
        }
    }
}
