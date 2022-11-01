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

namespace Police.Pages.CasePages
{
    /// <summary>
    /// Логика взаимодействия для OpenCasePage.xaml
    /// </summary>
    public partial class OpenCasePage : Page
    {
        Case casee = new Case();
        User user = new User();
        OpenCase open = new OpenCase();

        public OpenCasePage(Case casse, User useer)
        {
            InitializeComponent();

            casee = casse;
            user = useer;

            lb_surname.Content = casee.Client.Surname;
            lb_name.Content = casee.Client.Name;
            lb_patronymic.Content = casee.Client.Patronymic;
            lb_crime.Content = casee.CrimeType.Name;
            lb_level.Content = casee.Level.ID;

            this.DataContext = this;
        }

        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            casee.IsDeleted = true;

            open.IdCase = casee.ID;
            open.IdEmployee = user.IdEmployee;

            Bd_connection.connection.OpenCase.Add(open);

            user.Employee.Score += 1;
            Bd_connection.connection.SaveChanges();
            switch (user.Employee.Score)
            {
                case 20:
                    user.Employee.IdRang = 4;
                    user.Employee.IdObject = 1;
                    Bd_connection.connection.SaveChanges();
                    break;
                case 40:
                    user.Employee.IdRang = 3;
                    user.Employee.IdObject = 2;
                    Bd_connection.connection.SaveChanges();
                    break;
                case 60:
                    user.Employee.IdRang = 2;
                    user.Employee.IdObject = 3;
                    Bd_connection.connection.SaveChanges();
                    break;
                case 80:
                    user.Employee.IdRang = 1;
                    user.Employee.IdObject = 4;
                    Bd_connection.connection.SaveChanges();
                    break;
                default:
                    user.Employee.IdRang = user.Employee.IdRang;
                    user.Employee.IdObject = user.Employee.IdObject;
                    Bd_connection.connection.SaveChanges();
                    break;
            }

            
            NavigationService.Navigate(new AllCasesPage(user));
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
