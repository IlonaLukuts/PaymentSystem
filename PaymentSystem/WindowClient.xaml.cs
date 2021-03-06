﻿using System;
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
    /// Interaction logic for WindowClient.xaml
    /// </summary>
    public partial class WindowClient : Window
    {
        public ProviderUser provider;
        public UserViewModel userViewModel;
        public WindowClient(ProviderUser provider, UserViewModel userViewModel)
        {
            this.provider = provider;
            this.userViewModel = userViewModel;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = userViewModel;
            this.AccountBox.DataContext = userViewModel.NewPayment;
            this.MoneyBox.DataContext = userViewModel.NewPayment;
            this.NoticeBox.DataContext = userViewModel.NewPayment;
            this.NumberBox.DataContext = userViewModel.SelectedCard;
            this.CVVBox.DataContext = userViewModel.SelectedCard;
        }

        private void AddCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            userViewModel.AddCommandModel.OnExecute(this, e);
            AddingTab.Visibility = Visibility.Collapsed;
            CommandManager.InvalidateRequerySuggested();
        }

        private void BlockedCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            userViewModel.BlockedCommandModel.OnExecute(this, e);
            CommandManager.InvalidateRequerySuggested();
        }

        private void BlockedCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute=userViewModel.CanBlocked;
        }
        private void UnBlockedCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            userViewModel.UnBlockedCommandModel.OnExecute(this, e);
            UnBlockingTab.Visibility = Visibility.Collapsed;
            if (!e.Handled)
                MessageBox.Show("Invalid data.");
            CommandManager.InvalidateRequerySuggested();
        }

        private void UnBlockedCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = userViewModel.CanUnBlocked;
        }
        private void ViewJornalCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            userViewModel.ViewJornalCommandModel.OnExecute(this, e);
            CommandManager.InvalidateRequerySuggested();
        }

        private void ViewJornalCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = userViewModel.CanViewJournal;
        }
        private void PayCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            userViewModel.PayCommandModel.OnExecute(this, e);
            CommandManager.InvalidateRequerySuggested();
        }

        private void PayCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = userViewModel.CanPay;
        }

        private void UnblockButton_Click(object sender, RoutedEventArgs e)
        {
            UnBlockingTab.Visibility = Visibility.Visible;
            Tabs.SelectedItem = UnBlockingTab;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddingTab.Visibility = Visibility.Visible;
            Tabs.SelectedItem = AddingTab;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            JournalTab.Visibility = Visibility.Collapsed;
            Tabs.SelectedItem = Tabs.Items[0];
        }
    }
}
