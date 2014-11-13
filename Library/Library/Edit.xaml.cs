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
            #region Заполнение
            int row = 0;
            foreach (System.Reflection.PropertyInfo property in this.edititem.GetType().GetProperties())
            {

                if (!property.Name.Contains("_")) // Исключим ИД
                {
                    //Добавим строку
                    this.DataGrid.RowDefinitions.Add(new RowDefinition());

                    //1-я колонка
                    TextBlock tbl = new TextBlock() { Text = property.Name + ":", Margin = new Thickness(5), FontWeight = FontWeights.Bold, VerticalAlignment = System.Windows.VerticalAlignment.Center };
                    
                    Grid.SetColumn(tbl, 0);
                    Grid.SetRow(tbl, row);
                    this.DataGrid.Children.Add(tbl);
                    
                    //2-я колонка со значениями
                    //FrameworkElement valueBox;
                    TextBox valueBox = new TextBox() { Margin = new Thickness(3), VerticalAlignment = System.Windows.VerticalAlignment.Center };

                    
                    if (property.PropertyType.IsValueType || property.PropertyType == typeof(string))
                    {
                        //Для значимых отобразим само значение
                        valueBox.Text = property.GetValue(this.edititem).ToString();
                    }
                    else
                    {
                        //Для ссылочных Получим Значение поля НАМЕ
                        valueBox.Text = StaticFunction.GetStringValue(property.GetValue(this.edititem));
                        valueBox.IsReadOnly = true;

                        //Добавим Кнопочку выбора
                        Button bt = new Button() { Content = "...", Height = 20 };
                        Grid.SetColumn(bt, 3);
                        Grid.SetRow(bt, row);
                        this.DataGrid.Children.Add(bt);
                    }

                    //Создадим темплате для Автор
                    DataTemplate dtAutors = new DataTemplate(typeof(Authors));

                    Grid.SetColumn(valueBox, 1);
                    Grid.SetRow(valueBox, row++);
                    this.DataGrid.Children.Add(valueBox);
                }
            }
            #endregion


        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
