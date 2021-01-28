using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace DontusSQL
{
    public class CommandsSql : Conexao
    {

        public string GerarCommands(string Commands)
        {

            var error = string.Empty;
            var Databases = RetornaTodosBancos();
            foreach (var item in Databases)
            {

                try
                {
                    Conectar("DESKTOP-TC3DMML\\SQLEXPRESS", item.name);
                    //SqlConnection.Open();
                    SqlConnection.Query(Commands);
                    SqlConnection.Close();
                }
                catch (SqlException ex)
                {
                    SqlConnection.Close();
                    error += item.name + ex.Message.ToString() + "</br>/n";

                }

            }
            return error;

        }
        public string GerarCommands(string Commands, string NomeBd)
        {
            var error = string.Empty;
            try
            {
                Conectar("DESKTOP-TC3DMML\\SQLEXPRESS", NomeBd);
                SqlConnection.Query(Commands);
                SqlConnection.Close();
            }
            catch (SqlException ex)
            {
                SqlConnection.Close();
                error =  ex.Message;
            }
            return error;
        }
        public List<dynamic> RetornaTodosBancos()
        {
            Conectar("DESKTOP-TC3DMML\\SQLEXPRESS", "master");
            var databases = SqlConnection.Query("select database_id, [name] from sys.databases where name NOT  IN ('master','model','msdb','tempdb','ReportServer$SQLEXPRESS','ReportServer$SQLEXPRESSTempDB') ").ToList();
            SqlConnection.Close();
            return databases;

        }

    }
}
