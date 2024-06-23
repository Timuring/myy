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
    /// Логика взаимодействия для LawyerMenu.xaml
    /// </summary>
    public partial class LawyerMenu : System.Windows.Window
    {
        public LawyerMenu()
        {
            InitializeComponent();
        }

        private void ContractsButton_Click(object sender, RoutedEventArgs e)
        {
            ContractsForLawyer contractsForLawyer = new ContractsForLawyer();
            contractsForLawyer.Show();
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
