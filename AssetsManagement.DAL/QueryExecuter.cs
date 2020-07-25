using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AssetsManagement.DAL
{
    internal sealed class QueryExecuter
    {
        private readonly string connectionString;

        internal QueryExecuter(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Database sonnection string is not defined");
            }

            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error openning connection to database {ex.Message}", ex);
                }
            }

            this.connectionString = connectionString;
        }

        internal int ExecuteScalar(string sql, Dictionary<string, object> parameters = null)
        {

            using (var conn = new SqlConnection(connectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = sql;
                foreach (var item in parameters)
                {
                    command.Parameters.AddWithValue(item.Key, item.Value);
                }

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }


        internal int ExecuteNonQuery(string sql, Dictionary<string, object> parameters = null)
        {

            using (var conn = new SqlConnection(connectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = sql;
                foreach (var item in parameters)
                {
                    command.Parameters.AddWithValue(item.Key, item.Value);
                }

                return command.ExecuteNonQuery();
            }
        }

        internal void ExecuteReader(string query, Action<IDataReader> rowConsumer, Dictionary<string, object> parameters = null)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = query;
                
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        command.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    rowConsumer.Invoke(reader);
                }
            }
        }
    }
}
