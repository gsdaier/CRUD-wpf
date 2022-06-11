using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using wpfnovo.Database;
using wpfnovo.Models;

namespace wpfnovo
{
    public class MainWindowsVM : INotifyPropertyChanged
    {
        public ObservableCollection<vehicles> VehiclesList { get; set; }
        public ICommand Add { get; private set; }
        public ICommand Remove { get; private set; }
        public ICommand Edit { get; private set; }
        public vehicles ProductSelected { get; set; }
        public List<vehicles> listaVeiculos { get; set; }

        private ProductDao dao;

        public event PropertyChangedEventHandler PropertyChanged;
        public MainWindowsVM()
        {
            
            try { 
                dao = new ProductDao();
                listaVeiculos = dao.List();

                VehiclesList = new ObservableCollection<vehicles>(listaVeiculos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CommandInit();
        }

        public void CommandInit()
        {
            Add = new RelayCommand((object _) =>
            {
                vehicles VehicleInsert = new vehicles();

                CreateAndEdit tela = new CreateAndEdit();
                tela.DataContext = VehicleInsert;
                bool? result = tela.ShowDialog();

                if (result == true) {
                    try { 
                        dao.Insert(VehicleInsert);
                        VehiclesList.Add(VehicleInsert);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                   
                } 

                //ICollectionView view = CollectionViewSource.GetDefaultView(listaVeiculos);
                //view.Refresh();

                //Insert_Test();
            });

            Remove = new RelayCommand((object carro) =>
            {
                try
                {
                    VehiclesList.Remove(ProductSelected);
                    if (ProductSelected != null)
                    {
                        Remove_Test();
                    }
                    else
                    {
                        MessageBox.Show("Escolha um carro para excluir");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }
            });

            Edit = new RelayCommand((object _) =>
            {
                CreateAndEdit tela = new CreateAndEdit();
                tela.DataContext = ProductSelected;
                bool? result = tela.ShowDialog();
                // REGRA AQUI!
                if (result != true)
                {
                    MessageBox.Show("Não editado");
                }
            });
        }

        //private void Insert_Test()
        //{
        //    try
        //    {
        //        ProductDao productDao = new ProductDao();
        //        vehicles carro1 = new vehicles();
        //        carro1.Id = "05";
        //        carro1.Modelo = "Audi Q4";
        //        carro1.Cor = "Branco";
        //        carro1.Ano = "2022";

        //        productDao.Insert(carro1);

        //        MessageBox.Show("Carro adicionado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }

        //}

        private void Remove_Test()
        {
            try
            {
                var dao = new ProductDao();
                dao.Delete(ProductSelected);

                ICollectionView view = CollectionViewSource.GetDefaultView(listaVeiculos);
                view.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
