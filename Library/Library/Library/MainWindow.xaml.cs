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
            listThemes.ItemsSource = db.Themes;
            listThemes.DisplayMemberPath = "Name";
            listThemes.SelectedIndex = 0;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Edit edit = new Edit(listThemes.SelectedItem);
            edit.ShowDialog();
            db.SubmitChanges();

        }

        private void listThemes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Themes t = (Themes)listThemes.SelectedItem;
            dgBooks.ItemsSource = t.Books;
            dgBooks.Columns[4].Visibility = Visibility.Hidden;
            dgBooks.Columns[5].Visibility = Visibility.Hidden;
            dgBooks.Columns[6].Visibility = Visibility.Hidden;
            dgBooks.Columns[7].Visibility = Visibility.Hidden;
            dgBooks.Columns[10].Visibility = Visibility.Hidden;
            dgBooks.Columns[11].Visibility = Visibility.Hidden;
        
           
        }
    }
}
