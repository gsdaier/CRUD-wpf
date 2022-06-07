using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using treinamentowpf.Database;
using treinamentowpf.Models;
using treinamentowpf.Interface;

namespace treinamentowpf
{
    public class MainWindowsVM
    {
        public ObservableCollection<vehicles> VehiclesList { get; set; }
        public ICommand Add { get; private set; }
        public ICommand Remove { get; private set; }
        public ICommand Edit { get; private set; }
        public vehicles ProductSelected { get; set; }
        public MainWindowsVM()
        {

            try
            {
                var conection = new database();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            VehiclesList = new ObservableCollection<vehicles>()
            {
                new vehicles()
                {
                    Id = "01",
                    Modelo = "Ford KA",
                    Ano = "2015",
                    Cor = "Prata",
                }
            };
            Insert_Test();
            CommandInit();
        }
        public void CommandInit()
        {
            Add = new RelayCommand((object _) =>
            {
                vehicles VehicleInsert = new vehicles();

                CreateAndEdit tela = new CreateAndEdit();
                tela.DataContext = VehicleInsert;
                tela.ShowDialog();

                VehiclesList.Add(VehicleInsert);
            });

            Remove = new RelayCommand((object carro) =>
            {
                VehiclesList.Remove((vehicles)carro);
            });

            Edit = new RelayCommand((object _) =>
            {

                CreateAndEdit tela = new CreateAndEdit();
                tela.DataContext = ProductSelected;
                tela.ShowDialog();

                
            });
        }

        private void Insert_Test()
        {
            ProductDao productDao = new ProductDao();
            vehicles carro1 = new vehicles();
            carro1.Id = "02";
            carro1.Modelo = "Porshe 911";
            carro1.Cor = "Azul";
            carro1.Ano = "2022";

            productDao.Insert(carro1);
            //AQUI
        }

        //private void Notifica(string VehiclesList)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(VehiclesList));
        //}
    }
}
