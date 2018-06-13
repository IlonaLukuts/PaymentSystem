using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentSystem.Models;
using PaymentSystem.Models.Providers;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows.Input;

namespace PaymentSystem.ViewModels
{
    public class AdminViewModel:INotifyPropertyChanged
    {
        public AdminModel adminModel;
        public ProviderAdmin providerAdmin;
        public ObservableCollection<RequestModel> Requests { get { return adminModel.RequestModels; } }
        private RequestModel selectedRequest;
        public RequestModel SelectedRequest
        {
            get { return selectedRequest; }
            set
            {
                selectedRequest = value;
                OnPropertyChanged("SelectedRequest");
            }
        }
        public CommandModel BlockedAdminCommandModel { private set; get; }
        public CommandModel UnBlockedAdminCommandModel { private set; get; }


        public AdminViewModel(AdminModel adminModel, ProviderAdmin providerAdmin)
        {
            this.adminModel = adminModel;
            this.providerAdmin = providerAdmin;

            BlockedAdminCommandModel = new BlockedAdminCommand(this);
            UnBlockedAdminCommandModel = new UnBlockedAdminCommand(this);
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        public bool CanBlocked
        {
            get { return Requests != null && Requests.Count != 0; }
        }

        public bool CanUnBlocked
        {
            get { return Requests != null && Requests.Count != 0; }
        }





        private class BlockedAdminCommand: CommandModel
        {
            private AdminViewModel adminViewModel;

            public BlockedAdminCommand(AdminViewModel adminViewModel)
            {
                this.adminViewModel = adminViewModel;
            }

            public override void OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute =
                    (true);

                e.Handled = true;
            }

            public override void OnExecute(object sender, ExecutedRoutedEventArgs e)
            {
                var request = adminViewModel.SelectedRequest;
                adminViewModel.providerAdmin.LeaveBlocked(request.Id);
                adminViewModel.adminModel.RequestModels.Remove(request);
            }
        }

        private class UnBlockedAdminCommand : CommandModel
        {
            private AdminViewModel adminViewModel;

            public UnBlockedAdminCommand(AdminViewModel adminViewModel)
            {
                this.adminViewModel = adminViewModel;
            }

            public override void OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute =
                    (true);

                e.Handled = true;
            }

            public override void OnExecute(object sender, ExecutedRoutedEventArgs e)
            {
                var request = adminViewModel.SelectedRequest;
                adminViewModel.providerAdmin.UnBlocked(request.Id,request.CardId);
                adminViewModel.adminModel.RequestModels.Remove(request);
            }
        }
    }
}
