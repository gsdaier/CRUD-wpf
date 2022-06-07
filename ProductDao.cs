using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using treinamentowpf.Interface;
using treinamentowpf.Database;

namespace treinamentowpf.Models
{
    class ProductDao : IDAO<vehicles>
    {
        private static database conn;

        public ProductDao()
        {
            conn = new database();
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
                query.CommandText = "INSERT INTO vehicles (id_vehi, modelo_vehi, ano_vehi, cor_vehi)" +
                "VALUES (@id, @modelo, @ano, @cor)";
                //Func

                query.Parameters.AddWithValue("@id", t.Id);
                query.Parameters.AddWithValue("@modelo", t.Modelo);
                query.Parameters.AddWithValue("@ano", t.Ano);
                query.Parameters.AddWithValue("@cor", t.Cor);

                var result = query.ExecuteNonQuery();

            } catch (Exception e)
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
            throw new NotImplementedException();
        }

        vehicles IDAO<vehicles>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        List<vehicles> IDAO<vehicles>.List()
        {
            throw new NotImplementedException();
        }
    }
}
