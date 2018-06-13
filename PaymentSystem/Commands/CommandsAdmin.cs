using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PaymentSystem.Commands
{
    public class CommandsAdmin
    {
        static CommandsAdmin()
        {
            BlockedAdminCommand = new RoutedCommand("BlockedAdminCommand", typeof(CommandsAdmin));
            UnBlockedAdminCommand = new RoutedCommand("UnBlockedAdminCommand", typeof(CommandsAdmin));
        }
        public static RoutedCommand BlockedAdminCommand { get; set; }
        public static RoutedCommand UnBlockedAdminCommand { get; set; }

    }
}
