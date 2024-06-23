using Microsoft.EntityFrameworkCore;
using RealEstateAgency.Models;
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

namespace RealEstateAgency.Window
{
    /// <summary>
    /// Логика взаимодействия для ContractsForLawyer.xaml
    /// </summary>
    public partial class ContractsForLawyer : System.Windows.Window
    {
        public ContractsForLawyer()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new AgenstvoContext())
            {
                var orders = context.Orders
                    .Include(o => o.Orderpersonlists)
                    .ThenInclude(op => op.Personr)
                    .ToList();

                ContractsDataGrid.ItemsSource = orders;
            }
        }

        private void ContractsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic selectedContract = ContractsDataGrid.SelectedItem;
            if (selectedContract != null)
            {
                ContractNumberTextBox.Text = $"Договор № {selectedContract.Orderid}";
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
            LawyerMenu lawyerMenu = new LawyerMenu();
            lawyerMenu.Show();
            this.Close();
        }
    }
}
