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
    /// Логика взаимодействия для MyCasesPage.xaml
    /// </summary>
    public partial class MyCasesPage : Page
    {
        User user = new User();
        public MyCasesPage(User userr)
        {
            InitializeComponent();
            user = userr;
            var z = Bd_connection.connection.Employee.Where(a => a.ID == user.IdEmployee).FirstOrDefault();
            case_dg.ItemsSource = Bd_connection.connection.OpenCase.Where(a => a.IdEmployee == z.ID && a.Case.IsDeleted == true).Select(x=> x.Case).ToList();
        }

        private void AllCasesLb_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AllCasesPage(user));
        }

        private void gooutlb_Click(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Точно выйти?", "Выйти",
            MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

                System.Windows.Application.Current.Shutdown();
            }
        }
    }
}
