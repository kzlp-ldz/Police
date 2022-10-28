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

namespace Police.Pages.AutoRegPages
{
    /// <summary>
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        User user = new User();
        Employee employee = new Employee();
        public AutoPage()
        {
            InitializeComponent();
        }
        private void btnConnect(object sender, RoutedEventArgs e)
        {
            var z = Bd_connection.connection.User.Where(a => a.Login == login.Text && a.Password == password.Password).FirstOrDefault();

            if (z != null)
            {
                NavigationService.Navigate(new CasePages.AllCasesPage(z));
            }
            else
            {
                MessageBox.Show("пароль и логин введены неверно", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnRegist(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistPage());
        }
    }
}
