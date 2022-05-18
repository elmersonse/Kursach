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
    /// Логика взаимодействия для ReportsPage.xaml
    /// </summary>
    public partial class ReportsPage : Page
    {
        private Dictionary<int, string> OtryadCB;

        public ReportsPage()
        {
            InitializeComponent();
            OtryadCB = Repository.OtryadCB();
            cb.ItemsSource = OtryadCB.Values;
        }

        private void TablesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TablesListBox.SelectedIndex != -1)
            {
                b.IsEnabled = true;
                switch (TablesListBox.SelectedIndex)
                {
                    case 0:
                        tb1.Text = "Список записей в кружок с указанием фамилии и имени ребёнка, названия кружка и даты записи";
                        sp.Visibility = Visibility.Hidden;
                        break;
                    case 1:
                        tb1.Text = "Список отрядов с указанием количества проведённых мероприятий для каждого отряда";
                        sp.Visibility = Visibility.Hidden;
                        break;
                    case 2:
                        tb1.Text = "Список детей из указанного отряда";
                        sp.Visibility = Visibility.Visible;
                        break;
                }
            }
            else
            {
                b.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TablesListBox.SelectedIndex != -1)
            {
                switch (TablesListBox.SelectedIndex)
                {
                    case 0:
                        Repository.GenerateReport1();
                        break;
                    case 1:
                        Repository.GenerateReport2();
                        break;
                    case 2:
                        if(cb.SelectedIndex == -1)
                        {
                            MessageBox.Show("Выберите отряд!");
                            return;
                        }
                        Repository.GenerateReport3(cb.Text);
                        break;
                }
            }
        }
    }
}
