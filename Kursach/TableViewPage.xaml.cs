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
                                _command.CommandText = "select * from Вожатый";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
                                _reader.Close();
                                break;
                            case 1:
                                _command.CommandText = "select * from Запись_в_кружок";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
                                _reader.Close();
                                break;
                            case 2:
                                _command.CommandText = "select * from Комната";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
                                _reader.Close();
                                break;
                            case 3:
                                _command.CommandText = "select * from Корпус";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
                                _reader.Close();
                                break;
                            case 4:
                                _command.CommandText = "select * from Кружок";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
                                _reader.Close();
                                break;
                            case 5:
                                _command.CommandText = "select * from Мероприятие";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
                                _reader.Close();
                                break;
                            case 6:
                                _command.CommandText = "select * from Отряд";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
                                _reader.Close();
                                break;
                            case 7:
                                _command.CommandText = "select * from Ребёнок";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
                                _reader.Close();
                                break;
                            case 8:
                                _command.CommandText = "select * from Смена";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
                                _reader.Close();
                                break;
                            case 9:
                                _command.CommandText = "select * from Участие_в_мероприятии";
                                _reader = _command.ExecuteReader();
                                _table.Load(_reader);
                                DataGrid.ItemsSource = _table.DefaultView;
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
    }
}
