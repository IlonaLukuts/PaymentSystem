using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PaymentSystem.Commands
{
    public static class CommandsUser
    {
        static CommandsUser()
        {
            AddCommand = new RoutedCommand("AddCommand", typeof(CommandsUser));
            BlockedCommand = new RoutedCommand("BlockedCommand", typeof(CommandsUser));
            UnBlockedCommand = new RoutedCommand("UnBlockedCommand", typeof(CommandsUser));
            ViewJornalCommand = new RoutedCommand("ViewJornalCommand", typeof(CommandsUser));
            PayCommand = new RoutedCommand("PayCommand", typeof(CommandsUser));
        }
        public static RoutedCommand AddCommand { get; set; }
        public static RoutedCommand BlockedCommand { get; set; }
        public static RoutedCommand UnBlockedCommand { get; set; }
        public static RoutedCommand ViewJornalCommand { get; set; }
        public static RoutedCommand PayCommand { get; set; }
    }
}
