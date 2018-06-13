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
    public class UserViewModel:INotifyPropertyChanged
    {
        public UserModel userModel;
        public ProviderUser providerUser;
        public ObservableCollection<CardModel> Cards { get { return userModel.CardModels; } }
        private CardModel selectedCard;
        public CardModel SelectedCard
        {
            get { return selectedCard; }
            set
            {
                selectedCard = value;
                OnPropertyChanged("SelectedCard");
            }
        }
        public ObservableCollection<PaymentModel> Payments;
        private PaymentModel newPayment;
        public PaymentModel NewPayment
        {
            get { return newPayment; }
            set
            {
                newPayment = value;
                OnPropertyChanged("NewPayment");
            }
        }

        public CommandModel AddCommandModel { private set; get; }
        public CommandModel UnBlockedCommandModel { private set; get; }
        public CommandModel BlockedCommandModel { private set; get; }
        public CommandModel ViewJornalCommandModel { private set; get; }
        public CommandModel PayCommandModel { private set; get; }




        public UserViewModel(UserModel userModel, ProviderUser providerUser)
        {
            this.userModel = userModel;
            this.providerUser = providerUser;
            newPayment = new PaymentModel();

            AddCommandModel = new AddCommand(this);
            BlockedCommandModel = new BlockedCommand(this);
            UnBlockedCommandModel = new UnBlockedCommand(this);
            ViewJornalCommandModel = new ViewJornalCommand(this);
            PayCommandModel = new PayCommand(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public bool CanBlocked
        {
            get { return Cards!=null && Cards.Count != 0; }
        }

        public bool CanUnBlocked
        {
            get { return Cards != null && Cards.Count != 0; }
        }

        public bool CanViewJournal
        {
            get { return Cards != null && Cards.Count != 0; }
        }

        public bool CanPay
        {
            get { return Cards != null && Cards.Count != 0; }
        }




        private class AddCommand : CommandModel
        {
            private UserViewModel userViewModel;

            public AddCommand(UserViewModel userViewModel)
            {
                this.userViewModel = userViewModel;
            }

            public override void OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute =
                    (!string.IsNullOrEmpty(userViewModel.SelectedCard.Number));

                e.Handled = true;
            }

            public override void OnExecute(object sender, ExecutedRoutedEventArgs e)
            {
                userViewModel.Cards.Add(userViewModel.providerUser.NewCard(userViewModel.SelectedCard.Number, userViewModel.userModel.Id));
            }
        }

        private class BlockedCommand : CommandModel
        {
            private UserViewModel userViewModel;

            public BlockedCommand(UserViewModel userViewModel)
            {
                this.userViewModel = userViewModel;
            }

            public override void OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                var card = userViewModel.SelectedCard;
                e.CanExecute =
                    (!card.IsBlocked);

                e.Handled = true;
            }

            public override void OnExecute(object sender, ExecutedRoutedEventArgs e)
            {
                var card = userViewModel.SelectedCard;
                userViewModel.providerUser.BlockedCard(card.Id);
                card.IsBlocked = true;
            }
        }

        private class UnBlockedCommand : CommandModel
        {
            private UserViewModel userViewModel;

            public UnBlockedCommand(UserViewModel userViewModel)
            {
                this.userViewModel = userViewModel;
            }

            public override void OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                var card = userViewModel.SelectedCard;
                e.CanExecute =
                    (card.IsBlocked&&!card.IsActive);

                e.Handled = true;
            }

            public override void OnExecute(object sender, ExecutedRoutedEventArgs e)
            {
                var card = userViewModel.SelectedCard;
                userViewModel.providerUser.UnBlockedCard(card.Id, card.CVV, card.Number);
            }
        }

        private class ViewJornalCommand : CommandModel
        {
            private UserViewModel userViewModel;

            public ViewJornalCommand(UserViewModel userViewModel)
            {
                this.userViewModel = userViewModel;
            }

            public override void OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute =
                    (true);

                e.Handled = true;
            }

            public override void OnExecute(object sender, ExecutedRoutedEventArgs e)
            {
                var card = userViewModel.SelectedCard;
                userViewModel.Payments = userViewModel.providerUser.GetPayments(card.Id);
            }
        }

        private class PayCommand : CommandModel
        {
            private UserViewModel userViewModel;

            public PayCommand(UserViewModel userViewModel)
            {
                this.userViewModel = userViewModel;
            }

            public override void OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                var payment = userViewModel.NewPayment;
                e.CanExecute =
                    (!string.IsNullOrEmpty(payment.Account));

                e.Handled = true;
            }

            public override void OnExecute(object sender, ExecutedRoutedEventArgs e)
            {
                var payment = userViewModel.NewPayment;
                userViewModel.providerUser.NewPayment(payment.CardId, payment.Account, payment.Money, payment.Notice);
                userViewModel.newPayment = new PaymentModel();
            }
        }
    }
}
