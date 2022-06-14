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
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM vehicles WHERE modelo = @modelo";

                query.Parameters.AddWithValue("@modelo", t.Modelo);

                conn.Open();
                var result = query.ExecuteNonQuery();
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

        public void Insert(vehicles t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "insert into vehicles ( modelo, ano, cor )" +
                "VALUES ( @modelo, @ano, @cor );";

                query.Parameters.AddWithValue("@modelo", t.Modelo);
                query.Parameters.AddWithValue("@ano", t.Ano);
                query.Parameters.AddWithValue("@cor", t.Cor);

                conn.Open();

                var result = query.ExecuteNonQuery();

                NpgsqlDataReader rdr = query.ExecuteReader();

                if (rdr.Read())
                {
                    t.Id = rdr.GetInt32(0);
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
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM vehicles;";

                conn.Open();
                NpgsqlDataReader rdr = query.ExecuteReader();
                List<vehicles> list = new List<vehicles>();

                while (rdr.Read())
                {
                    vehicles t = new vehicles();
                    t.Id = rdr.GetInt32(0);
                    t.Modelo = rdr.GetString(1);
                    t.Ano = rdr.GetString(2);
                    t.Cor = rdr.GetString(3);

                    list.Add(t);
                }
                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(vehicles t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE vehicles SET modelo = @modelo, cor = @cor, ano = @ano " + "WHERE id = @id";

                query.Parameters.AddWithValue("@id", t.Id);
                query.Parameters.AddWithValue("@modelo", t.Modelo);
                query.Parameters.AddWithValue("@ano", t.Ano);
                query.Parameters.AddWithValue("@cor", t.Cor);

                conn.Open();

                var result = query.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("Carro não editado. Verifique e tente novamente.");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
