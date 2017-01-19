using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace backend.DAOs
{
    abstract class AbstractDAO <T>
    {
        protected SqlConnection conn = new SqlConnection();

        abstract protected List<T> Tokenize(string json);

        public AbstractDAO()
        {

        }

        protected List<T> ReceiveFromDatabase(string sql)
        {
            ConnectToSQLServer();
            string json = ExecuteSQLCommand(sql);
            DisconnectFromSQLServer();
            if (json == null) return null;
            return Tokenize(json);
        }

        protected string SendToDatabase(string sql)
        {
            if (CheckForSQLInjection(sql))
                throw new Exception();
            ConnectToSQLServer();
            string result = ExecuteSQLCommand(sql);
            DisconnectFromSQLServer();
            if (result == null) return null;
            return result;
        }
        private static readonly List<string> sqlInjectionCommands = new List<string>{"select", "delete", "drop", "update", "insert" };
        private bool CheckForSQLInjection(string sql)
        {
            foreach (string command in sqlInjectionCommands)
            {
                if (sql.ToLower().Contains(command))
                    return true;
            }
            return false;
        }

        protected IEnumerable<Dictionary<string, object>> Serialize(SqlDataReader reader)
        {
            var results = new List<Dictionary<string, object>>();
            var cols = new List<string>();
            for (var i = 0; i < reader.FieldCount; i++)
                cols.Add(reader.GetName(i));

            while (reader.Read())
                results.Add(SerializeRow(cols, reader));

            return results;
        }
        protected Dictionary<string, object> SerializeRow(IEnumerable<string> cols, SqlDataReader reader)
        {
            var result = new Dictionary<string, object>();
            foreach (var col in cols)
                result.Add(col, reader[col]);
            return result;
        }

        protected void ConnectToSQLServer()
        {
            try
            {
                this.conn.ConnectionString = "Server=" + ServerDefines.serverName 
                    + ";Database=" + ServerDefines.databaseName +";Trusted_Connection=true";
                this.conn.Open();
            }
            catch (SqlException er)
            {
                Console.WriteLine("There was an error reported by SQL Server, " + er.Message);
            }
        }

        protected string ExecuteSQLCommand(string SQLcommand)
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
        protected void DisconnectFromSQLServer()
        {
            this.conn.Close();
        }

    }
}

