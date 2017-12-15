using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
namespace DontusSQL
{
    public class Conexao
    {
        public SqlConnection SqlConnection = new SqlConnection();

        public SqlConnection Conectar(string Server, string Banco)
        {

            // var connect = "Data Source =" + Server + "; Initial Catalog=master; Integrated Security = false; User ID = " + User + ";" + " Password =" + "'" + Senha + "'";
            //var connectionString = "Data Source=DESKTOP-HPV4FPU\\SQLEXPRESS01/;Initial Catalog=master;Integrated Security = true;";
            var connectionString = @"data source=DESKTOP-HPV4FPU\SQLEXPRESS01;initial catalog="+Banco+";integrated security=True;MultipleActiveResultSets=True;";
            SqlConnection.ConnectionString = connectionString.ToString();
            SqlConnection.Open();
            return SqlConnection;
        }
        //public void Conectar(string Server, string Banco)
        //{
        //     SqlConnection.(Banco) ;
        //}
        public void Desconectar()
        {
            SqlConnection.Close();
        }
    }
}
