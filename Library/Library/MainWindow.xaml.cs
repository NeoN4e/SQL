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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

          //  ApplicationCommands Chose = new ApplicationCommands();
 
            //this.CommandBindings.Add( new CommandBinding(ApplicationCommands.New, MenuBooks_Click));
            //ApplicationCommands.a
            //InputGestureCollection inputs = new InputGestureCollection();
            //inputs.Add(new KeyGesture(Key.E, ModifierKeys.Control, "Ctrl+E"));

            //RoutedCommand cmd = new RoutedCommand();
            

            RoutedUICommand uicmd = new RoutedUICommand("MyCommand","MyCommand",typeof(ApplicationCommands));
            MenuCatalogs.CommandBindings.Add(new CommandBinding(uicmd, MenuCatalogss_Click));

            MenuCatalogs.Items.Add(new MenuItem() { Header = "Books", Command = uicmd, CommandParameter = db.Books});
            MenuCatalogs.Items.Add(new MenuItem() { Header = "Themes", Command = uicmd, CommandParameter = db.Themes });
            MenuCatalogs.Items.Add(new MenuItem() { Header = "Authors", Command = uicmd, CommandParameter = db.Authors });
        }

        private void MenuCatalogss_Click(object sender, RoutedEventArgs e)
        {
            object Param = (e.Source as MenuItem).CommandParameter;
            datagrid.ItemsSource = (Param as System.Collections.IEnumerable);
        }

        //private void MenuBooks_Click(object sender, RoutedEventArgs e)
        //{
        //    datagrid.ItemsSource = db.Books;
        //}

        //private void MenuAuthors_Click(object sender, RoutedEventArgs e)
        //{
        //    datagrid.ItemsSource = db.Authors;
        //}

        //private void MenuThemes_Click(object sender, RoutedEventArgs e)
        //{
        //    datagrid.ItemsSource = db.Themes;
        //}

        //private void MenuCategories_Click(object sender, RoutedEventArgs e)
        //{
        //    datagrid.ItemsSource = db.Categories;
        //}


    }
}
