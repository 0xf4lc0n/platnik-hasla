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

namespace PlatnikHasla
{
    public partial class MainWindow : Window
    {
        private Core _coreLogic;
        public MainWindow()
        {
            InitializeComponent();
            _coreLogic = new Core();
        }

        private void FindPasswordClick(object sender, RoutedEventArgs e)
        {
            _coreLogic.GetUserPasswords();
            _coreLogic.DecodeUserPasswords();
            _coreLogic.GetDatabasePasswords();
            _coreLogic.DecodeDatabasePasswords();
            UserPassword.Text = _coreLogic.UserPassword;
            DatabasePassword.Text = _coreLogic.DatabasePassword;
        }
    }
}
