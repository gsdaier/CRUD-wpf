﻿using System;
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
using wpfnovo.Models;

namespace wpfnovo
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
            Loaded += CreateAndEdit_Loaded;
        }

        private void CreateAndEdit_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void ClearTextBox()
        {
            TboxId.Text = "";
            TboxModelo.Text = "";
            TboxAno.Text = "";
            TboxCor.Text = "";
        }
    }
}
