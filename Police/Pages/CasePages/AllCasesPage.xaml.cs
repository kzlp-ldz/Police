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
    /// Логика взаимодействия для AllCasesPage.xaml
    /// </summary>
    public partial class AllCasesPage : Page
    {
        User user = new User();
        public AllCasesPage(User userr)
        {
            InitializeComponent();
            user = userr;
            Employee empuser = user.Employee;
            case_dg.ItemsSource = Bd_connection.connection.Case.ToList().Where(a => a.IdLevel == user.Employee.IdRang);
        }

        private void MyCaseLb_Click(object sender, MouseButtonEventArgs e)
        {

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
