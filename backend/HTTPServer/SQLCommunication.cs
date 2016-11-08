using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace backend.HTTPServer
{
    class SQLCommunication
    {
        public SQLCommunication()
        {

        }
        public IEnumerable<Dictionary<string, object>> Serialize(SqlDataReader reader)
        {
            var results = new List<Dictionary<string, object>>();
            var cols = new List<string>();
            for (var i = 0; i < reader.FieldCount; i++)
                cols.Add(reader.GetName(i));

            while (reader.Read())
                results.Add(SerializeRow(cols, reader));

            return results;
        }
        private Dictionary<string, object> SerializeRow(IEnumerable<string> cols, SqlDataReader reader)
        {
            var result = new Dictionary<string, object>();
            foreach (var col in cols)
                result.Add(col, reader[col]);
            return result;
        }
        public SqlConnection conn = new SqlConnection();
        public void connectToSQLServer()
        {
            try
            {
                this.conn.ConnectionString = "Server=MICHAL;Database=TAS;Trusted_Connection=true";
                this.conn.Open();
            }
            catch (SqlException er)
            {
                Console.WriteLine("There was an error reported by SQL Server, " + er.Message);
            }
        }
        public string executeSQLCommand(string SQLcommand)
        {
            string json = null;
            try
            {
                SqlCommand command = new SqlCommand(SQLcommand, this.conn);
                SqlDataReader reader = command.ExecuteReader();
                var r = Serialize(reader);
                json = JsonConvert.SerializeObject(r);
            }
            catch (SqlException er)
            {
                Console.WriteLine("There was an error reported by SQL Server, " + er.Message);
            }
            if (json == null) return null;
            else return json;
        }
        public void disconnectFromSQLServer()
        {
            this.conn.Close();
        }


    }
}

