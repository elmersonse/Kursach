using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для TableViewPage.xaml
    /// </summary>
    public partial class TableViewPage : Page
    {

        public TableViewPage()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }

        private void TablesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid.Visibility = Visibility.Visible;
            ButtonGrid.Visibility = Visibility.Visible;
            TableFrame.Visibility = Visibility.Hidden;
            TableFrame.Source = null;
            if (TablesListBox.SelectedIndex != -1)
            {
                AddButton.IsEnabled = true;
                switch (TablesListBox.SelectedIndex)
                {
                    case 0:
                        DataGrid.ItemsSource = Repository.LoadVojatiy().DefaultView;
                        DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                        DataGrid.Columns[4].Header = "Дата рождения";
                        break;
                    case 1:
                        DataGrid.ItemsSource = Repository.LoadZapis().DefaultView;
                        DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                        DataGrid.Columns[4].Header = "Дата записи";
                        break;
                    case 2:
                        DataGrid.ItemsSource = Repository.LoadKomnata().DefaultView;
                        DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                        DataGrid.Columns[1].Header = "Номер комнаты";
                        DataGrid.Columns[2].Header = "Номер корпуса";
                        DataGrid.Columns[3].Header = "Тип комнаты";
                        DataGrid.Columns[4].Header = "Количество мест";
                        break;
                    case 3:
                        DataGrid.ItemsSource = Repository.LoadKorpus().DefaultView;
                        DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                        DataGrid.Columns[1].Header = "Номер корпуса";
                        DataGrid.Columns[2].Header = "Тип корпуса";
                        break;
                    case 4:
                        DataGrid.ItemsSource = Repository.LoadKruzhok().DefaultView;
                        DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                        DataGrid.Columns[1].Header = "Название";
                        DataGrid.Columns[2].Header = "Номер комнаты";
                        break;
                    case 5:
                        DataGrid.ItemsSource = Repository.LoadMeropriyatie().DefaultView;
                        DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                        DataGrid.Columns[2].Header = "Тип мероприятия";
                        break;
                    case 6:
                        DataGrid.ItemsSource = Repository.LoadOtryad().DefaultView;
                        DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                        DataGrid.Columns[2].Header = "Фамилия вожатого";
                        DataGrid.Columns[3].Header = "Дата начала смены";
                        break;
                    case 7:
                        DataGrid.ItemsSource = Repository.LoadRebenok().DefaultView;
                        DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                        DataGrid.Columns[5].Header = "Дата рождения";
                        DataGrid.Columns[6].Header = "Название отряда";
                        DataGrid.Columns[7].Header = "Номер комнаты";
                        break;
                    case 8:
                        DataGrid.ItemsSource = Repository.LoadSmena().DefaultView;
                        DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                        DataGrid.Columns[1].Header = "Дата начала";
                        DataGrid.Columns[2].Header = "Дата окончания";
                        break;
                    case 9:
                        DataGrid.ItemsSource = Repository.LoadUchastie().DefaultView;
                        DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                        DataGrid.Columns[3].Header = "Дата проведения";
                        break;
                }
            }
        }

        private void ViewsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ViewsListBox.SelectedIndex != -1)
            {

            }
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
            }
        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if(DataGrid.SelectedItem != null)
            {
                DeleteButton.IsEnabled = true;
                EditButton.IsEnabled = true;
            }
            else
            {
                DeleteButton.IsEnabled = false;
                EditButton.IsEnabled = false;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.Visibility = Visibility.Hidden;
            ButtonGrid.Visibility = Visibility.Hidden;
            TableFrame.Visibility = Visibility.Visible;
            if (TablesListBox.SelectedIndex != -1)
            {
                switch (TablesListBox.SelectedIndex)
                {
                    case 0:
                        TableFrame.Navigate(new AddPages.CounselorAdd(DataGrid, ButtonGrid, TableFrame));
                        break;
                    case 1:
                        TableFrame.Navigate(new AddPages.ZapisAdd(DataGrid, ButtonGrid, TableFrame));
                        break;
                    case 2:
                        TableFrame.Navigate(new AddPages.KomnataAdd(DataGrid, ButtonGrid, TableFrame));
                        break;
                    case 3:
                        TableFrame.Navigate(new AddPages.KorpusAdd(DataGrid, ButtonGrid, TableFrame));
                        break;
                    case 4:
                        TableFrame.Navigate(new AddPages.KruzhokAdd(DataGrid, ButtonGrid, TableFrame));
                        break;
                    case 5:
                        TableFrame.Navigate(new AddPages.MeropriyatieAdd(DataGrid, ButtonGrid, TableFrame));
                        break;
                    case 6:
                        TableFrame.Navigate(new AddPages.OtryadAdd(DataGrid, ButtonGrid, TableFrame));
                        break;
                    case 7:
                        TableFrame.Navigate(new AddPages.RebenokAdd(DataGrid, ButtonGrid, TableFrame));
                        break;
                    case 8:
                        TableFrame.Navigate(new AddPages.SmenaAdd(DataGrid, ButtonGrid, TableFrame));
                        break;
                    case 9:
                        TableFrame.Navigate(new AddPages.UchastieAdd(DataGrid, ButtonGrid, TableFrame));
                        break;
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            switch (TablesListBox.SelectedIndex)
            {
                case 0:
                    Repository.DeleteVojatiy(DataGrid);
                    DataGrid.ItemsSource = Repository.LoadVojatiy().DefaultView;
                    DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                    DataGrid.Columns[4].Header = "Дата рождения";
                    break;
                case 1:
                    Repository.DeleteZapis(DataGrid);
                    DataGrid.ItemsSource = Repository.LoadZapis().DefaultView;
                    DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                    DataGrid.Columns[4].Header = "Дата записи";
                    break;
                case 2:
                    Repository.DeleteKomnata(DataGrid);
                    DataGrid.ItemsSource = Repository.LoadKomnata().DefaultView;
                    DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                    DataGrid.Columns[1].Header = "Номер комнаты";
                    DataGrid.Columns[2].Header = "Номер корпуса";
                    DataGrid.Columns[3].Header = "Тип комнаты";
                    DataGrid.Columns[4].Header = "Количество мест";
                    break;
                case 3:
                    Repository.DeleteKorpus(DataGrid);
                    DataGrid.ItemsSource = Repository.LoadKorpus().DefaultView;
                    DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                    DataGrid.Columns[1].Header = "Номер корпуса";
                    DataGrid.Columns[2].Header = "Тип корпуса";
                    break;
                case 4:
                    Repository.DeleteKruzhok(DataGrid);
                    DataGrid.ItemsSource = Repository.LoadKruzhok().DefaultView;
                    DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                    DataGrid.Columns[1].Header = "Название";
                    DataGrid.Columns[2].Header = "Номер комнаты";
                    break;
                case 5:
                    Repository.DeleteMeropriyatie(DataGrid);
                    DataGrid.ItemsSource = Repository.LoadMeropriyatie().DefaultView;
                    DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                    DataGrid.Columns[2].Header = "Тип мероприятия";
                    break;
                case 6:
                    Repository.DeleteOtryad(DataGrid);
                    DataGrid.ItemsSource = Repository.LoadOtryad().DefaultView;
                    DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                    DataGrid.Columns[2].Header = "Фамилия вожатого";
                    DataGrid.Columns[3].Header = "Дата начала смены";
                    break;
                case 7:
                    Repository.DeleteRebenok(DataGrid);
                    DataGrid.ItemsSource = Repository.LoadRebenok().DefaultView;
                    DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                    DataGrid.Columns[5].Header = "Дата рождения";
                    DataGrid.Columns[6].Header = "Название отряда";
                    DataGrid.Columns[7].Header = "Номер комнаты";
                    break;
                case 8:
                    Repository.DeleteSmena(DataGrid);
                    DataGrid.ItemsSource = Repository.LoadSmena().DefaultView;
                    DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                    DataGrid.Columns[1].Header = "Дата начала";
                    DataGrid.Columns[2].Header = "Дата окончания";
                    break;
                case 9:
                    Repository.DeleteUchastie(DataGrid);
                    DataGrid.ItemsSource = Repository.LoadUchastie().DefaultView;
                    DataGrid.Columns[0].Visibility = Visibility.Collapsed;
                    DataGrid.Columns[3].Header = "Дата проведения";
                    break;
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.Visibility = Visibility.Hidden;
            ButtonGrid.Visibility = Visibility.Hidden;
            TableFrame.Visibility = Visibility.Visible;
            if (TablesListBox.SelectedIndex != -1)
            {
                switch (TablesListBox.SelectedIndex)
                {
                    case 0:
                        TableFrame.Navigate(new AddPages.CounselorAdd(DataGrid, ButtonGrid, TableFrame, 1));
                        break;
                    case 1:
                        TableFrame.Navigate(new AddPages.ZapisAdd(DataGrid, ButtonGrid, TableFrame, 1));
                        break;
                    case 2:
                        TableFrame.Navigate(new AddPages.KomnataAdd(DataGrid, ButtonGrid, TableFrame, 1));
                        break;
                    case 3:
                        TableFrame.Navigate(new AddPages.KorpusAdd(DataGrid, ButtonGrid, TableFrame, 1));
                        break;
                    case 4:
                        TableFrame.Navigate(new AddPages.KruzhokAdd(DataGrid, ButtonGrid, TableFrame, 1));
                        break;
                    case 5:
                        TableFrame.Navigate(new AddPages.MeropriyatieAdd(DataGrid, ButtonGrid, TableFrame, 1));
                        break;
                    case 6:
                        TableFrame.Navigate(new AddPages.OtryadAdd(DataGrid, ButtonGrid, TableFrame, 1));
                        break;
                    case 7:
                        TableFrame.Navigate(new AddPages.RebenokAdd(DataGrid, ButtonGrid, TableFrame, 1));
                        break;
                    case 8:
                        TableFrame.Navigate(new AddPages.SmenaAdd(DataGrid, ButtonGrid, TableFrame, 1));
                        break;
                    case 9:
                        TableFrame.Navigate(new AddPages.UchastieAdd(DataGrid, ButtonGrid, TableFrame, 1));
                        break;
                }
            }
        }
    }
}
