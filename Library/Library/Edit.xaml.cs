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
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        object edititem;
        public Edit(object edititem)
        {
            InitializeComponent();
            this.edititem = edititem;

            //edititem.GetType().GetProperties()[0].Name
            //edititem.GetType().GetProperties()[0].GetValue(edititem)
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int row = 0;
            foreach (System.Reflection.PropertyInfo property in this.edititem.GetType().GetProperties())
            {

                if (!property.Name.Contains("Id_")) // Исключим ИД
                {
                    //1-я колонка
                    this.MainGrid.RowDefinitions.Add(new RowDefinition());

                    TextBlock tbl = new TextBlock() { Text = property.Name + ":", Margin = new Thickness(5), FontWeight = FontWeights.Bold, VerticalAlignment = System.Windows.VerticalAlignment.Center };
                    
                    Grid.SetColumn(tbl, 0);
                    Grid.SetRow(tbl, row);
                    this.MainGrid.Children.Add(tbl);
                    
                    //2-я колонка со значениями
                    FrameworkElement valueBox;

                    //if (property.PropertyType.IsValueType || property.PropertyType == typeof(string))
                        valueBox = new TextBox() { Text = property.GetValue(this.edititem).ToString() };
                    //else
                    //    valueBox = new ComboBox() { SelectedItem = property.GetValue(this.edititem) };

                    valueBox.Margin = new Thickness(3);
                    valueBox.VerticalAlignment = System.Windows.VerticalAlignment.Center;

                    Grid.SetColumn(valueBox, 1);
                    Grid.SetRow(valueBox, row++);
                    this.MainGrid.Children.Add(valueBox);
                }
            }
        }
    }
}
