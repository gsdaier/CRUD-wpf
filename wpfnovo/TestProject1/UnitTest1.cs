using wpfnovo.Interface;
using wpfnovo.Models;

namespace TestProject1
{
    public class Tests
    {

        IDAO<vehicles> postgresDao = new PostgresDao();
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void SalvarCarroNoBanco()
        {
            vehicles carro = new vehicles();
            
            carro.Modelo = "Porshe 911 teste";
            carro.Ano = "2010";
            carro.Cor = "Branco";

            bool resultado = postgresDao.Insert(carro);
            Assert.IsTrue(resultado);

            bool resultadoRemove = postgresDao.Delete(carro);
            Assert.IsTrue(resultadoRemove);
        }
    }
}