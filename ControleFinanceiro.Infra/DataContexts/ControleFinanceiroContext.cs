using ControleFinanceiro.Shared;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ControleFinanceiro.Infra.DataContexts
{
    public class ControleFinanceiroContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public ControleFinanceiroContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
