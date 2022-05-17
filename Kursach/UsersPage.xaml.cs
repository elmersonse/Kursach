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

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
            DataGrid.ItemsSource = Repository.GetUsers().DefaultView;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Repository.SetAdmin(DataGrid, 1);
            DataGrid.ItemsSource = Repository.GetUsers().DefaultView;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Repository.DeleteUser(DataGrid);
            DataGrid.ItemsSource = Repository.GetUsers().DefaultView;
        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
            {
                DeleteButton.IsEnabled = true;
                AddButton.IsEnabled = true;
                RemoveButton.IsEnabled = true;
            }
            else
            {
                DeleteButton.IsEnabled = false;
                AddButton.IsEnabled = false;
                RemoveButton.IsEnabled = false;
            }
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Repository.SetAdmin(DataGrid, 2);
            DataGrid.ItemsSource = Repository.GetUsers().DefaultView;
        }
    }
}
