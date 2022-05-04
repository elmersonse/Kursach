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
        private const string _connectionString = "Server=ALEXTRAZA\\SQLEXPRESS;Database=SummerCamp;Trusted_Connection=True;";
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private DataTable _table;

        public TableViewPage()
        {
            InitializeComponent();
            DataContext = new ViewModel();
            try
            {
                _connection = new SqlConnection(_connectionString);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
        }

        private void TablesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TablesListBox.SelectedIndex != -1)
            {
                AddButton.IsEnabled = true;
                try
                {
                    using (_connection = new SqlConnection(_connectionString))
                    {
                        _connection.Open();
                        _command = new SqlCommand();
                        _command.Connection = _connection;
                        _table = new DataTable();
                        switch (TablesListBox.SelectedIndex)
                        {
                            case 0:
                                _command.CommandText = "select Фамилия, Имя, Отчество, Дата_рождения, Телефон from Вожатый";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
                                DataGrid.Columns[3].Header = "Дата рождения";
                                _reader.Close();
                                break;
                            case 1:
                                _command.CommandText = "select * from Запись_в_кружок_П";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
                                DataGrid.Columns[3].Header = "Дата записи";
                                _reader.Close();
                                break;
                            case 2:
                                _command.CommandText = "select * from Комната_П";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
                                DataGrid.Columns[0].Header = "Номер комнаты";
                                DataGrid.Columns[1].Header = "Номер корпуса";
                                DataGrid.Columns[2].Header = "Тип комнаты";
                                DataGrid.Columns[3].Header = "Количество мест";
                                _reader.Close();
                                break;
                            case 3:
                                _command.CommandText = "select Номер_корпуса, Тип_корпуса from Корпус";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
                                DataGrid.Columns[0].Header = "Номер корпуса";
                                DataGrid.Columns[1].Header = "Тип корпуса";
                                _reader.Close();
                                break;
                            case 4:
                                _command.CommandText = "select * from Кружок_П";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
                                DataGrid.Columns[0].Header = "Название";
                                DataGrid.Columns[1].Header = "Номер комнаты";
                                _reader.Close();
                                break;
                            case 5:
                                _command.CommandText = "select Название, Тип_мероприятия from Мероприятие";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
                                DataGrid.Columns[1].Header = "Тип мероприятия";
                                _reader.Close();
                                break;
                            case 6:
                                _command.CommandText = "select * from Отряд_П";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
                                DataGrid.Columns[1].Header = "Фамилия вожатого";
                                DataGrid.Columns[2].Header = "Дата начала смены";
                                _reader.Close();
                                break;
                            case 7:
                                _command.CommandText = "select * from Ребёнок_П";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
                                DataGrid.Columns[4].Header = "Дата рождения";
                                DataGrid.Columns[5].Header = "Название отряда";
                                DataGrid.Columns[6].Header = "Номер комнаты";
                                _reader.Close();
                                break;
                            case 8:
                                _command.CommandText = "select Дата_начала, Дата_окончания from Смена";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
                                DataGrid.Columns[0].Header = "Дата начала";
                                DataGrid.Columns[1].Header = "Дата окончания";
                                _reader.Close();
                                break;
                            case 9:
                                _command.CommandText = "select * from Участие_в_мероприятии_П";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
                                DataGrid.Columns[2].Header = "Дата проведения";
                                _reader.Close();
                                break;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
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
            TableFrame.Navigate(new AddPages.CounselorAdd(DataGrid, ButtonGrid, TableFrame));
        }
    }
}
