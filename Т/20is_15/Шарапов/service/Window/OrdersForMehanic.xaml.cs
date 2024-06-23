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
    /// Логика взаимодействия для OrdersForMehanic.xaml
    /// </summary>
    public partial class OrdersForMehanic : System.Windows.Window
    {
        public OrdersForMehanic()
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
                selectedContract.Orderstatus = "Готовится";
                ContractsDataGrid.Items.Refresh();
            }
        }

        private void ShowClientCardButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic selectedContract = ContractsDataGrid.SelectedItem;
            if (selectedContract != null)
            {
                selectedContract.Orderstatus = "Готов";
                ContractsDataGrid.Items.Refresh();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MehanicMenu lawyerMenu = new MehanicMenu();
            lawyerMenu.Show();
            this.Close();
        }
    }
}
