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
    public class MainWindowsVM
    {
        public ObservableCollection<vehicles> VehiclesList { get; set; }
        public ICommand Add { get; private set; }
        public ICommand Remove { get; private set; }
        public ICommand Edit { get; private set; }
        public vehicles ProductSelected { get; set; }
        public List<vehicles> listaVeiculos { get; set; }

        private ProductDao dao;

        public MainWindowsVM()
        {

            try
            {
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

                if (result == true)
                {
                    try
                    {
                        dao.Insert(VehicleInsert);
                        VehiclesList.Add(VehicleInsert);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            });

            Remove = new RelayCommand((object carro) =>
            {
                try
                {
                    dao.Delete(ProductSelected);
                    VehiclesList.Remove(ProductSelected);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }
            });

            Edit = new RelayCommand((object _) =>
            {
                if (ProductSelected != null) {
                    CreateAndEdit tela = new CreateAndEdit();
                    vehicles carro = ProductSelected.DeepCopy();
                    tela.DataContext = carro;
                    bool? result = tela.ShowDialog();
                    try
                    {
                        if (result == true)
                        {
                            dao.Update(carro);
                            ProductSelected.Modelo = carro.Modelo;
                            ProductSelected.Ano = carro.Ano;
                            ProductSelected.Cor = carro.Cor;
                        }
                        else
                        {
                            MessageBox.Show("Não editado");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                } else
                {
                    MessageBox.Show("Escolha um carro");
                }
            });
        }
    }
}