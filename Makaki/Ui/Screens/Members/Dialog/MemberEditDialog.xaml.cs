using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Makaki.Ui.Screens.Members.Dialog
{
    /// <summary>
    /// Interaction logic for MemberEditDialog.xaml
    /// </summary>
    public partial class MemberEditDialog : Window
    {
        public MemberEditDialog(MemberEditDialogViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}
