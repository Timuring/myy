using Microsoft.EntityFrameworkCore;
using service.Models;
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
    /// Логика взаимодействия для OrdersForAutodiagnost.xaml
    /// </summary>
    public partial class OrdersForAutodiagnost : System.Windows.Window
    {
        public OrdersForAutodiagnost()
        {
            InitializeComponent(); LoadData();
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

        private void ContractsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic selectedContract = ContractsDataGrid.SelectedItem;
            if (selectedContract != null)
            {
                ContractNumberTextBox.Text = $"Заказ № {selectedContract.Orderid}";
            }
        }

        private void ShowLogButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic selectedContract = ContractsDataGrid.SelectedItem;
            if (selectedContract != null)
            {
                selectedContract.Paymentstatus = "Принят";
                ContractsDataGrid.Items.Refresh();
            }
        }

        private void ShowClientCardButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic selectedContract = ContractsDataGrid.SelectedItem;
            if (selectedContract != null)
            {
                selectedContract.Paymentstatus = "Оплачен";
                ContractsDataGrid.Items.Refresh();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AutodiagnostMenu realtorMenu = new AutodiagnostMenu();
            realtorMenu.Show();
            this.Close();
        }
    }
}