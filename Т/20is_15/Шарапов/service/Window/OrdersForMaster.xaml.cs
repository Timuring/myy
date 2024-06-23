using Microsoft.EntityFrameworkCore;
using service.Models;
using service.Window;
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
    /// Логика взаимодействия для OrdersForMaster.xaml
    /// </summary>
    public partial class OrdersForMaster : System.Windows.Window
    {
        public OrdersForMaster()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new ServiceContext())
            {
                var orders = context.Orders
                    .Include(o => o.Orderuserlists)
                    .ThenInclude(op => op.User)
                    .ToList();

                ContractsDataGrid.ItemsSource = orders;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MasterMenu adminMenu = new MasterMenu();
            adminMenu.Show();
            this.Close();
        }
    }
}
