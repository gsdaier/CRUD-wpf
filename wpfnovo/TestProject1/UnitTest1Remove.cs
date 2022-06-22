using System.Collections.ObjectModel;
using wpfnovo.Interface;
using wpfnovo.Models;

namespace TestProject1
{
    public class Tests2
    {

        MySqlDao mySqlDao = new MySqlDao();
        //public ObservableCollection<vehicles> VehiclesListView { get; set; }

        
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void RemoverCarroNoBanco()
        {
            //VehiclesListView = new ObservableCollection<vehicles>(mySqlDao.List());
            vehicles carro = new vehicles();

            carro.Modelo = "Porshe 911 teste";
            carro.Ano = "2010";
            carro.Cor = "Branco";

            var resultado = mySqlDao.Insert(carro);
            Assert.AreEqual(true, resultado);

            mySqlDao.Delete(carro);
        }
    }
}