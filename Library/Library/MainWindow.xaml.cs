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

            RoutedUICommand uicmd = new RoutedUICommand("MyCommand","MyCommand",typeof(ApplicationCommands));
            MenuCatalogs.CommandBindings.Add(new CommandBinding(uicmd, MenuCatalogss_Click));


            MenuCatalogs.Items.Add(new MenuItem() { Header = "Books", Command = uicmd, CommandParameter = db.Books});
            MenuCatalogs.Items.Add(new MenuItem() { Header = "Themes", Command = uicmd, CommandParameter = db.Themes });
            MenuCatalogs.Items.Add(new MenuItem() { Header = "Categories", Command = uicmd, CommandParameter = db.Categories });
            MenuCatalogs.Items.Add(new Separator());

            MenuCatalogs.Items.Add(new MenuItem() { Header = "Authors", Command = uicmd, CommandParameter = db.Authors });
            MenuCatalogs.Items.Add(new MenuItem() { Header = "Press", Command = uicmd, CommandParameter = db.Press });
            MenuCatalogs.Items.Add(new Separator());

            MenuCatalogs.Items.Add(new MenuItem() { Header = "Students", Command = uicmd, CommandParameter = db.Students });
            MenuCatalogs.Items.Add(new MenuItem() { Header = "Teachers", Command = uicmd, CommandParameter = db.Teachers });
            MenuCatalogs.Items.Add(new Separator());

            MenuCatalogs.Items.Add(new MenuItem() { Header = "Groups", Command = uicmd, CommandParameter = db.Groups });
            MenuCatalogs.Items.Add(new MenuItem() { Header = "Faculties", Command = uicmd, CommandParameter = db.Faculties });
            MenuCatalogs.Items.Add(new MenuItem() { Header = "Departments", Command = uicmd, CommandParameter = db.Departments });

           
            //TextBlock tb = new TextBlock(){Text="{Binding Score}"};
            //Binding bind = new Binding();
            //bind.Path = new PropertyPath("Name");
            //tb.SetBinding(TextBlock.TextProperty, bind);
            
            //DataTemplate dt = new DataTemplate();
            //dt.VisualTree = tb;
            //Departments;
        }

        private void MenuCatalogss_Click(object sender, RoutedEventArgs e)
        {
            object Param = (e.Source as MenuItem).CommandParameter;
            IQueryable enumerator = (Param as IQueryable);

            datagrid.ItemsSource = enumerator;
            datagrid.AutoGenerateColumns = false;
            datagrid.Columns.Clear();

            foreach (var item in enumerator.ElementType.GetProperties())
            {
                if (!item.Name.Contains("Id_")) // Исключим ИД
                {
                    if (item.PropertyType.IsValueType || item.PropertyType == typeof(string))
                        datagrid.Columns.Add(new DataGridTextColumn() { Header = item.Name, Binding = new Binding(item.Name),IsReadOnly=true });
                    
                  //  else
                 //       datagrid.Columns.Add(new DataGridComboBoxColumn() { Header = item.Name, ItemsSource = db.Authors, SelectedItemBinding = new Binding(item.Name) });
                }
                

            }
            //Binding bind = new Binding("Id");
            //datagrid.Columns.Add(new DataGridTextColumn() { Header = "Test",Binding= new Binding("Id") });
            
        }

        private void datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Edit editWindow = new Edit( (sender as DataGrid).CurrentItem );
            editWindow.ShowDialog();
        }

 

      
    }
}
