using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace wpfnovo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowsVM();
        }

        private void CadastroCarro_Click(object sender, RoutedEventArgs e)
        {
            //Button button = sender as Button;

            //switch (button.Name)
            //{
            //    case "CadastroCarro":
            //        var window = new CreateAndEdit();
            //        window.ShowDialog();
            //        break;
            //}
        }

        private void RemoverCarro_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
