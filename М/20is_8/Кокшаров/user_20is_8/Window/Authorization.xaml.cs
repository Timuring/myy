using Microsoft.EntityFrameworkCore;
using RealEstateAgency.Models;
using System.Linq;
using System.Windows;

namespace RealEstateAgency.Window
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : System.Windows.Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = ShowPasswordCheckBox.IsChecked == true ? PasswordTextBoxVisible.Text : PasswordTextBox.Password;

            using (var context = new AgenstvoContext())
            {
                var user = context.Users
                    .Include(u => u.Userrole)
                    .FirstOrDefault(u => u.Login == login && u.Password == password && u.Status != "Уволен");

                if (user != null)
                {
                    MessageBox.Show("Успешный вход", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    switch (user.Userrole.Namerole)
                    {
                        case "Администратор":
                            var adminWindow = new AdminMenu();
                            adminWindow.Show();
                            break;
                        case "Юрист":
                            var lawyerWindow = new LawyerMenu();
                            lawyerWindow.Show();
                            break;
                        case "Риелтор":
                            var realtorWindow = new RealtorMenu();
                            realtorWindow.Show();
                            break;
                        default:
                            MessageBox.Show("Неизвестная роль пользователя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowPasswordCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PasswordTextBoxVisible.Text = PasswordTextBox.Password;
            PasswordTextBox.Visibility = Visibility.Collapsed;
            PasswordTextBoxVisible.Visibility = Visibility.Visible;
        }

        private void ShowPasswordCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordTextBox.Password = PasswordTextBoxVisible.Text;
            PasswordTextBox.Visibility = Visibility.Visible;
            PasswordTextBoxVisible.Visibility = Visibility.Collapsed;
        }
    }
}
