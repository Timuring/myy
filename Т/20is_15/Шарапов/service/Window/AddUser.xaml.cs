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
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : System.Windows.Window
    {
        public AddUser()
        {
            InitializeComponent();
            RoleTextBox.ItemsSource = GetRoles();
        }

        private string[] GetRoles()
        {
            using (var context = new ServiceContext())
            {
                return context.Userroles.Select(r => r.Namerole).ToArray();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string surname = SurnameTextBox.Text;
            string middlename = MiddlenameTextBox.Text;
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;
            string selectedRole = RoleTextBox.SelectedItem as string;

            using (var context = new ServiceContext())
            {

                var user = new User
                {
                    Firstname = name,
                    Lastname = surname,
                    Middlename = middlename,
                    Login = login,
                    Password = password,
                    Userroleid = context.Userroles.FirstOrDefault(r => r.Namerole == selectedRole)?.Userroleid ?? 0,
                    Status = "Работает",
                };

                context.Users.Add(user);
                context.SaveChanges();

                MessageBox.Show("Пользователь успешно добавлен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                Users users = new Users();
                users.Show();
                this.Close();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Users users = new Users();
            users.Show();
            this.Close();
        }
    }
}
