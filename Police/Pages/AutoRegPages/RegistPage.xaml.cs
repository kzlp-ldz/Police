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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Police.BD;
using System.Collections.ObjectModel;

namespace Police.Pages.AutoRegPages
{
    /// <summary>
    /// Логика взаимодействия для RegistPage.xaml
    /// </summary>
    public partial class RegistPage : Page
    {
        public static ObservableCollection<User> listuser { get; set; }
        public RegistPage()
        {
            InitializeComponent();
        }
        private void btnRegist(object sender, RoutedEventArgs e)
        {

            Employee employee = new Employee();
            User user = new User();

            user.Login = tbx_login.Text;
            user.Password = tbx_password.Text;
            if (tbx_surname.Text != "" && tbx_name.Text != "" && tbx_patronymic.Text != "" && tbx_login.Text != "" && tbx_password.Text != "")
            {
                if (IsLoginCorrect())
                {
                    employee.Surname = tbx_surname.Text;
                    employee.Name = tbx_name.Text;
                    employee.Patronymic = tbx_patronymic.Text;
                    employee.IdRang = 5;
                    employee.Score = 0;
                    Bd_connection.connection.Employee.Add(employee);
                    Bd_connection.connection.SaveChanges();

                    user.IdEmployee = employee.ID;
                    Bd_connection.connection.User.Add(user);
                    Bd_connection.connection.SaveChanges();

                    MessageBox.Show("ДОБАВЛЕНО!!!");
                    NavigationService.Navigate(new AutoPage());
                }
            }
            else
                MessageBox.Show("Заполните все поля данными!");
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIsNumeric(e);
        }
        private void CheckIsNumeric(TextCompositionEventArgs e)
        {
            int result;

            if (!(int.TryParse(e.Text, out result) || e.Text == "."))
            {
                e.Handled = true;
            }
        }
        public bool IsLoginCorrect()
        {
            listuser = new ObservableCollection<User>(Bd_connection.connection.User.ToList());
            bool login = true;
            foreach (var a in listuser)
            {
                if (a.Login == tbx_login.Text)
                    login = false;
            }
            if (login)
                return true;
            else
            {
                MessageBox.Show("Такой логин уже занят, придумайте другой", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private void btnSign_click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AutoPage());
        }
    }
}
