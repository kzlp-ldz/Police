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
            var z = Bd_connection.connection.Employee.Where(a => a.ID == user.IdEmployee).FirstOrDefault();
            case_dg.ItemsSource = Bd_connection.connection.Case.Where(a => a.Level.Place == z.IdRang && a.IsDeleted == false).ToList();
            object_lb.Content = Bd_connection.connection.Object.FirstOrDefault(x=>x.ID == z.IdObject).Name;
        }

        private void MyCaseLb_Click(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new MyCasesPage(user));
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

        private void case_dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var v = case_dg.SelectedItem as Case; 
            if (v != null)
                NavigationService.Navigate(new OpenCasePage(v, user));
        }
    }
}
