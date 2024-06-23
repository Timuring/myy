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
    /// Логика взаимодействия для ContractsForAdmin.xaml
    /// </summary>
    public partial class ContractsForAdmin : System.Windows.Window
    {
        public ContractsForAdmin()
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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            adminMenu.Show();
            this.Close();
        }
    }
}
