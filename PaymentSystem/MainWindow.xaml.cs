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
using PaymentSystem.Models;
using PaymentSystem.Models.Providers;
using AutoMapper;
using BussinessObjects;
using DataObjects;

namespace PaymentSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Admin, AdminModel>();
                cfg.CreateMap<Request, RequestModel>();
                cfg.CreateMap<Card, CardModel>();
                cfg.CreateMap<Payment, PaymentModel>();
                cfg.CreateMap<User, UserModel>();

                cfg.CreateMap<AdminEntity, Admin>();
                cfg.CreateMap<Admin, AdminEntity>();
                cfg.CreateMap<CardEntity, Card>();
                cfg.CreateMap<Card, CardEntity>();
                cfg.CreateMap<PaymentEntity, Payment>();
                cfg.CreateMap<Payment, PaymentEntity>();
                cfg.CreateMap<RequestEntity, Request>();
                cfg.CreateMap<Request, RequestEntity>();
                cfg.CreateMap<UserEntity, User>();
                cfg.CreateMap<User, UserEntity>();
            });
        }

        private void Sign_Click(object sender, RoutedEventArgs e)
        {
            var provider = new ProviderUser();
            UserModel userModel = provider.Login(userBox.Text, passwordBox.Password);
            if (userModel == null)
                MessageBox.Show("Invalid name or password.");
            else
            {
                WindowClient windowClient = new WindowClient(provider, new ViewModels.UserViewModel(userModel, provider));
                //windowClient.provider = provider;
                //windowClient.userViewModel = new ViewModels.UserViewModel(userModel, provider);
                this.IsEnabled = false;
                windowClient.ShowDialog();
                this.IsEnabled = true;
            }
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            var provider = new ProviderAdmin();
            AdminModel adminModel = provider.Login(userBox.Text, passwordBox.Password);
            if (adminModel == null)
                MessageBox.Show("Invalid name or password.");
            else
            {
                WindowAdmin windowAdmin  = new WindowAdmin(provider, new ViewModels.AdminViewModel(adminModel, provider));
                //windowAdmin.provider = provider;
                //windowAdmin.adminViewModel = new ViewModels.AdminViewModel(adminModel, provider);
                this.IsEnabled = false;
                windowAdmin.ShowDialog();
                this.IsEnabled = true;
            }
        }
        private void New_Click(object sender, RoutedEventArgs e)
        {
            var provider = new ProviderUser();
            UserModel userModel = provider.NewUser(userBox.Text, passwordBox.Password);
            if (userModel == null)
                MessageBox.Show("Invalid name or password.");
            else
            {
                WindowClient windowClient = new WindowClient(provider, new ViewModels.UserViewModel(userModel, provider));
                //windowClient.provider = provider;
                //windowClient.userViewModel = new ViewModels.UserViewModel(userModel, provider);
                this.IsEnabled = false;
                windowClient.ShowDialog();
                this.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Gen.Gener();
        }
    }
}
