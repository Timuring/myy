using RealEstateAgency.Window;
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

namespace service.Window
{
    /// <summary>
    /// Логика взаимодействия для AutodiagnostMenu.xaml
    /// </summary>
    public partial class AutodiagnostMenu : System.Windows.Window
    {
        public AutodiagnostMenu()
        {
            InitializeComponent();
        }
        private void ContractsButton_Click(object sender, RoutedEventArgs e)
        {
            OrdersForAutodiagnost contractsForRealtor = new OrdersForAutodiagnost();
            contractsForRealtor.Show();
            this.Close();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            this.Close();
        }
    }
}

