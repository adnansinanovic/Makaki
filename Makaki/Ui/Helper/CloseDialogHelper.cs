using System.Windows;

namespace Makaki.Ui.Helper
{
    public static class CloseDialogHelper
    {
        public static void Close(object obj)
        {
            object[] array = obj as object[];
            if (array != null)
            {
                if (array.Length == 2)
                {
                    Window window = array[0] as Window;
                    bool result = array[1].ToString().ToLower() == "True".ToLower();

                    if (window != null)
                    {
                        window.DialogResult = result;
                        window.Close();
                    }
                }
            }
            else
            {
                Window window = obj as Window;
                window?.Close();
            }
        }
    }
}
