using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfnovo.Interface;
using wpfnovo.Database;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Controls;
using System.Windows;

namespace wpfnovo.Models
{
    class ProductDao : IDAO<vehicles>
    {
        private database conn;

        public ProductDao()
        {
            conn = new database();
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
                "VALUES ( @modelo, @ano, @cor ); SELECT LAST_INSERT_ID();";

                query.Parameters.AddWithValue("@modelo", t.Modelo);
                query.Parameters.AddWithValue("@ano", t.Ano);
                query.Parameters.AddWithValue("@cor", t.Cor);

                conn.Open();

                var result = query.ExecuteNonQuery();

                MySqlDataReader rdr = query.ExecuteReader();

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
        public List<vehicles> List()
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "select * from vehicles;";

                conn.Open();
                MySqlDataReader rdr = query.ExecuteReader();
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
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
