﻿using System;
using System.Collections.Generic;
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

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        Object record;
        public Edit(Object record)
        {
            InitializeComponent();
            this.record = record;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ((Themes)record).Name = tbName.Text;
            Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            Themes t = (Themes)record;
            tbIdThemes.Text = t.Id.ToString();
            tbName.Text = t.Name;
        }
    }
}
