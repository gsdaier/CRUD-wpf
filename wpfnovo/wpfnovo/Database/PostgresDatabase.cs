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
        private string host = "localhost";
        private string port = "5432";
        private string user = "postgres";
        private string password = "1234";
        private string bdname = "postgres";

        private NpgsqlConnection connec;
        private NpgsqlCommand command;
        public PostgresDatabase()
        {
            try
            {
                connec = new NpgsqlConnection($"Host={host};Database={bdname};Port={port};Username={user};Password={password};");
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
