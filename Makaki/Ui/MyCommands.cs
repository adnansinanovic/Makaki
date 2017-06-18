using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Makaki.Ui.Helper;

namespace Makaki.Ui
{
    public class MyCommands
    {
        public static readonly ICommand CloseCommand = new RelayCommand<object>(Close);

        private static void Close(object obj)
        {
            CloseDialogHelper.Close(obj);
        }
    }
}
