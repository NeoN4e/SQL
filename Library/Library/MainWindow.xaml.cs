using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LibraryDataContext db = new LibraryDataContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            combobox.ItemsSource = db.Authors;
            combobox.DisplayMemberPath = "FirstName";
            combobox.SelectedIndex = 0;
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            dg.ItemsSource = (this.combobox.SelectedItem as Authors).Books;

            DataGridComboBoxColumn dgc = new DataGridComboBoxColumn();
            dgc.DisplayMemberPath = "LastName";
         //   dgc.ItemStringForma = "";
            dgc.ItemsSource = db.Authors;
            dgc.Header = "Test";
            dgc.SelectedItemBinding = new Binding("Authors");
            dg.Columns.Add(dgc);
        }


    }
}
