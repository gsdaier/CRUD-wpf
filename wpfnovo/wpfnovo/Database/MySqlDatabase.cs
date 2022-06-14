using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace wpfnovo.Database
{
    public class MySqlDatabase
    {
        private string host = "localhost";
        private string port = "3306";
        private string user = "root";
        private string password = "1234";
        private string bdname = "db_sistema";

        private MySqlConnection conecction;
        private MySqlCommand command;

        public MySqlDatabase()
        {
            try
            {
                conecction = new MySqlConnection($"server={host};database={bdname};port={port};user={user};password={password};");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MySqlCommand Query()
        {
            try
            {
                command = conecction.CreateCommand();
                command.CommandType = CommandType.Text;

                return command;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void getStatament()
        {

        }

        public void Open()
        {
            try 
            { 
            conecction.Open();
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
                conecction.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
