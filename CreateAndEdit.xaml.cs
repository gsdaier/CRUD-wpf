using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace treinamentowpf
{
    /// <summary>
    /// Interaction logic for CriareEditarUsuario.xaml
    /// </summary>
    public partial class CreateAndEdit : Window
    {
        public CreateAndEdit()
        {
            DataContext = this;
            InitializeComponent();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string id, modelo, ano, cor;

            id = TboxId.Text;
            modelo = TboxModelo.Text;
            ano = TboxAno.Text;
            cor = TboxCor.Text;

            if (id == "")
            {
                MessageBox.Show("ID não pode ser vazio");
            }

            MessageBox.Show($"Id: {id}\n" +
                $"Modelo: {modelo}\n" +
                $"Ano: {ano}\n" +
                $"Cor: {cor}\n"
                );

            ClearTextBox();
        }

        private void ClearTextBox()
        {
            TboxId.Text = "";
            TboxModelo.Text = "";
            TboxAno.Text = "";
            TboxCor.Text = "";
        }
        private void TboxModelo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
