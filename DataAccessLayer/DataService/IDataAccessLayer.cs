using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeTrainingRegistration.DataService
{
    public interface IDataAccessLayer
    {
        SqlConnection Connection { get; }
        string Connect();
        string Connect(string connectionString);
        void Disconnect();
        int ExecuteQuery(string sql, List<SqlParameter> parameters);
        SqlDataReader GetData(string sql, List<SqlParameter> parameters);
        SqlDataReader GetDataWithConditions(string query, List<SqlParameter> parameters);
        SqlDataReader RetrieveData(string sql);
    }
}
