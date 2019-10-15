using BibliotecaDeClasses.ConnectionContext;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workApi.IRepository.ContextWebConnection
{
    public class DbHelper
    {
        private DbHelper() 
        {
        }

        public MySqlConnection GetConnection(string connectionString)
        {
            if(_connexa == null)
            {
                _connexa = new MySqlConnection(connectionString);
            }

            return _connexa;
        }

        private static DbHelper _instancia = null;
        private MySqlConnection _connexa = null;

        public static DbHelper Instancia 
        {
            get 
            {
               if(ManipuladorDeContexto.Current != null)
                {
                    if(ManipuladorDeContexto.Current.Sessoes == null)
                    {
                        ManipuladorDeContexto.Current.CrieArmazenDeContexto();
                    }

                   if(ManipuladorDeContexto.Current.Sessoes["SESSAO_CONEXAO"] == null) {
                        if(_instancia == null)
                        {
                            _instancia = new DbHelper();
                            ManipuladorDeContexto.Current.Sessoes["SESSAO_CONEXAO"] = _instancia;
                        }
                   }
                }

                return (DbHelper)ManipuladorDeContexto.Current.Sessoes["SESSAO_CONEXAO"];
            }
        }

        public string RetornaTeste()
        {
            return "Fincionou";
        }
    }
}
