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
using System.Windows.Shapes;

namespace testApp
{
    /// <summary>
    /// Interaction logic for PesananDiproses.xaml
    /// </summary>
    public partial class PesananDiproses : Window
    {
        public PesananDiproses()
        {
            InitializeComponent();

            #if DEBUG
            this.Width = 813;
            this.Height = 475;
            #endif
        }

        private void MovetoAnotherPage(Window newWindow)
        {
            this.Close();
            newWindow.Show();
        }


        private void BtnSignOut_Click(object sender, RoutedEventArgs e)
        {
            SignIn signInPage = new SignIn();
            MovetoAnotherPage(signInPage);
        }
    }
}
