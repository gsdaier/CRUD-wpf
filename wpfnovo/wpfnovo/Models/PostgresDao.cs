using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wpfnovo.Database;
using wpfnovo.Interface;

namespace wpfnovo.Models
{
    class PostgresDao : IDAO<vehicles>
    {
        private PostgresDatabase conn;
        public PostgresDao()
        {
            conn = new PostgresDatabase();
        }
        public void Delete(vehicles t)
        {
            throw new NotImplementedException();
        }

        public void Insert(vehicles t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "insert into vehicles ( modelo, ano, cor )" +
                "VALUES ( @modelo, @ano, @cor ); SELECT LAST_INSERT_ID();";

                query.Parameters.AddWithValue("@modelo", t.Modelo);
                query.Parameters.AddWithValue("@ano", t.Ano);
                query.Parameters.AddWithValue("@cor", t.Cor);

                conn.Open();

                var result = query.ExecuteNonQuery();

                NpgsqlDataReader rdr = query.ExecuteReader();

                if (rdr.Read())
                {
                    t.Id = rdr.GetString(0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<vehicles> List()
        {
            throw new NotImplementedException();
        }

        public void Update(vehicles t)
        {
            throw new NotImplementedException();
        }
    }
}
