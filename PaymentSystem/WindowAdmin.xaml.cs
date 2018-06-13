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
using PaymentSystem.ViewModels;
using PaymentSystem.Models.Providers;

namespace PaymentSystem
{
    /// <summary>
    /// Interaction logic for WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : Window
    {
        public ProviderAdmin provider;
        public AdminViewModel adminViewModel;
        public WindowAdmin(ProviderAdmin provider, AdminViewModel adminViewModel)
        {
            this.provider = provider;
            this.adminViewModel = adminViewModel;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = adminViewModel;
        }

        private void BlockedAdminCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            adminViewModel.BlockedAdminCommandModel.OnExecute(this, e);
        }

        private void BlockedAdminCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute=adminViewModel.CanBlocked;
        }

        private void UnBlockedAdminCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            adminViewModel.UnBlockedAdminCommandModel.OnExecute(this, e);
        }

        private void UnBlockedAdminCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = adminViewModel.CanUnBlocked;
        }
    }
}
