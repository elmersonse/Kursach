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


namespace Kursach.AddPages
{
    /// <summary>
    /// Логика взаимодействия для CounselorAdd.xaml
    /// </summary>
    public partial class CounselorAdd : Page
    {
        private DataGrid DataGrid;
        private Grid Grid;
        private Frame Frame;

        private const string _connectionString = "Server=PASHA\\SQLEXPRESS;Database='Летний лагерь';Trusted_Connection=True;";
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        private DataTable _table;

        public CounselorAdd(DataGrid datagrid, Grid grid, Frame frame)
        {
            InitializeComponent();
            DataGrid = datagrid;
            Grid = grid;
            Frame = frame;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.Visibility = Visibility.Visible;
            Grid.Visibility = Visibility.Visible;
            Frame.Visibility = Visibility.Hidden;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            using(_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                _command = new SqlCommand("insert into Вожатый values (@surname, @name, @fathername, @birthdate, @phone)", _connection);
                _command.Parameters.Add("@surname", SqlDbType.VarChar).Value = tb1.Text;
                _command.Parameters.Add("@name", SqlDbType.VarChar).Value = tb2.Text;
                _command.Parameters.Add("@fathername", SqlDbType.VarChar).Value = tb3.Text;
                _command.Parameters.Add("@birthdate", SqlDbType.Date).Value = tb4.Text;
                _command.Parameters.Add("@phone", SqlDbType.VarChar).Value = tb5.Text;
                _command.ExecuteNonQuery();
                _command.CommandText = "select * from Вожатый";
                _reader = _command.ExecuteReader();
                _table = new DataTable();
                _table.Load(_reader);
                DataGrid.ItemsSource = _table.DefaultView;
                DataGrid.Columns[3].Header = "Дата рождения";
                DataGrid.Columns[0].Visibility = Visibility.Hidden;
                _reader.Close();
            }
            DataGrid.Visibility = Visibility.Visible;
            Grid.Visibility = Visibility.Visible;
            Frame.Visibility = Visibility.Hidden;
        }
    }
}
