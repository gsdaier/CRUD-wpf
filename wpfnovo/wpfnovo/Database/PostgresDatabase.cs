using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfnovo.Database
{
    public class PostgresDatabase
    {
        private string connstring = String.Format("Server={0};Port={1};" + 
            "User Id={2};Password={3};Database={4};",
            "localhost", 5432, "postgres",
            "17052016", "postgres");

        private NpgsqlConnection connec;
        private NpgsqlCommand command;
        public PostgresDatabase()
        {
            try
            {
                connec = new NpgsqlConnection(connstring);
            }
            catch (Exception)
            {
                throw;
            }
        }

       public NpgsqlCommand Query()
        {
            try
            {
                command = connec.CreateCommand();
                command.CommandType = CommandType.Text;

                return command;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Open()
        {
            try
            {
                connec.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Close()
        {
            try
            {
                connec.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
