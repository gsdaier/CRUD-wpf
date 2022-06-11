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

                //if (result == 0)
                //    throw new Exception("Carro não removido. Verifique e tente novamente.");

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

        //public vehicles GetById(int id)
        //{
        //    try
        //    {
        //        var query = conn.Query();
        //        query.CommandText = "SELECT * FROM vehicles WHERE id = @id";
                
        //        query.Parameters.AddWithValue("@id", id);

        //        MySqlDataReader rdr = query.ExecuteReader();

        //        while (rdr.Read())
        //        {
        //            vehicles t = new vehicles();
        //            t.Id = rdr.GetString(0);
        //            t.Modelo = rdr.GetString(1);
        //            t.Ano = rdr.GetString(2);
        //            t.Cor = rdr.GetString(3);
        //        }

               
        //    }
        //    catch(Exception e)
        //    {
        //        throw e;
        //    }
        //    finally
        //    {
        //        conn.Query();
        //    }
        //}

        public void Insert(vehicles t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "insert into vehicles ( modelo, ano, cor )" +
                "VALUES ( @modelo, @ano, @cor )";
                //vehi

                //query.Parameters.AddWithValue("@id", t.Id);
                query.Parameters.AddWithValue("@modelo", t.Modelo);
                query.Parameters.AddWithValue("@ano", t.Ano);
                query.Parameters.AddWithValue("@cor", t.Cor);

                conn.Open();

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Carro não inserido. Verifique e tente novamente.");

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
            throw new NotImplementedException();
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
                    t.Id = rdr.GetString(0);
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
