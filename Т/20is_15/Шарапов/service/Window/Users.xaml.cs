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

namespace RealEstateAgency.Window
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : System.Windows.Window
    {
        public Users()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new ServiceContext())
            {
                var users = context.Users
                    .Include(u => u.Userrole)
                    .OrderBy(u => u.Userid)
                    .ToList();

                UsersDataGrid.ItemsSource = users;
            }
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MasterMenu adminMenu = new MasterMenu();
            adminMenu.Show();
            this.Close();
        }

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = UsersDataGrid.SelectedItem as User;

            if (selectedUser != null)
            {

                var result = MessageBox.Show($"Вы действительно хотите уволить {selectedUser.Firstname} {selectedUser.Lastname}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new ServiceContext())
                    {
                        var userToUpdate = context.Users.FirstOrDefault(u => u.Userid == selectedUser.Userid);
                        if (userToUpdate != null)
                        {
                            userToUpdate.Status = "Уволен";
                            context.SaveChanges();
                        }
                    }
                    selectedUser.Status = "Уволен";
                    UsersDataGrid.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите пользователя из списка.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}
