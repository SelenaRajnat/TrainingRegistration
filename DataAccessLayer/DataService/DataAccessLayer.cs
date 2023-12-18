using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeTrainingRegistration.DataService
{
    public class DataAccessLayer : IDataAccessLayer
    {
        public SqlConnection Connection { get; private set; }
        public string Connect()
        {
            try
            {
                var connectionString = ConfigurationManager.AppSettings["DefaultConnectionString"];
                if (!string.IsNullOrEmpty(connectionString))
                {
                    Connection = new SqlConnection(connectionString);
                    Connection.Open();
                }
            }
            catch (Exception ex)
            {
                return "Unable to find the connection string " + ex.Message;
            }
            return "Connection successful.";
        }
        public string Connect(string connectionString)
        {
            try
            {
                if (!string.IsNullOrEmpty(connectionString))
                {
                    Connection = new SqlConnection(connectionString);
                    Connection.Open();
                }
            }
            catch (Exception ex)
            {
                return "Unable to find the connection string " + ex.Message;
            }
            return "Connection successful.";
        }
        public void Disconnect()
        {
            if (Connection != null && Connection.State.Equals(ConnectionState.Open))
            {
                Connection.Close();
            }
        }
        public int ExecuteQuery(string query, List<SqlParameter> parameters)
        {
            Connect();
            using (SqlCommand cmd = new SqlCommand(query, Connection))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected;
            }
        }
        public SqlDataReader GetData(string query, List<SqlParameter> parameters)
        {
            Connect();
            using (SqlCommand cmd = new SqlCommand(query, Connection))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
        public SqlDataReader GetDataWithConditions(string query, List<SqlParameter> parameters)
        {
            Connect();
            using (SqlCommand command = new SqlCommand(query, Connection))
            {
                command.CommandType = CommandType.Text;
                if (parameters != null)
                {
                    parameters.ForEach(parameter => {
                        command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                    });
                }
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
        public SqlDataReader RetrieveData(string sql)
        {
            Connect();
            using (SqlCommand command = new SqlCommand(sql, Connection))
            {
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            
        }
    }
}