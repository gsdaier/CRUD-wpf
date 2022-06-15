using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using wpfnovo.Database;
using wpfnovo.Interface;
using wpfnovo.Models;

namespace wpfnovo
{
    public class MainWindowsVM
    {
        public ObservableCollection<vehicles> VehiclesListView { get; set; }
        public ICommand Add { get; private set; }
        public ICommand Remove { get; private set; }
        public ICommand Edit { get; private set; }
        public vehicles ProductSelected { get; set; }

        private IDAO<vehicles> dao;
        public MainWindowsVM()
        {
            try
            {
                dao = new ProductDao();

                VehiclesListView = new ObservableCollection<vehicles>(dao.List());
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

                CreateAndEdit screen = new CreateAndEdit();
                screen.DataContext = VehicleInsert;
                bool? result = screen.ShowDialog();

                if (result == true)
                {
                    try
                    {
                        dao.Insert(VehicleInsert);
                        VehiclesListView.Add(VehicleInsert);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            });

            Remove = new RelayCommand((object carro) =>
            {
                if (ProductSelected != null) { 
                    try
                    {
                        dao.Delete(ProductSelected);
                        VehiclesListView.Remove(ProductSelected);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um carro para remover");
                }
            });

            Edit = new RelayCommand((object _) =>
            {
                if (ProductSelected != null) {
                    CreateAndEdit screen = new CreateAndEdit();
                    vehicles carro = ProductSelected.DeepCopy();
                    screen.DataContext = carro;
                    bool? result = screen.ShowDialog();
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