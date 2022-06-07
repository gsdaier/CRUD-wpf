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
using System.Windows.Navigation;
using System.Windows.Shapes;
using treinamentowpf.Models;

namespace treinamentowpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowsVM ViewModel;
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainWindowsVM();
            DataContext = ViewModel;

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
