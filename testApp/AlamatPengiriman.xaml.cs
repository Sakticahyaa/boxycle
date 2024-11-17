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
    /// Interaction logic for AlamatPengiriman.xaml
    /// </summary>
    public partial class AlamatPengiriman : Window
    {
        public AlamatPengiriman()
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

        private void BtnSimpanAlamat_Click(object sender, RoutedEventArgs e)
        {
            PesananDiproses pesananDiprosesPage = new PesananDiproses();
            MovetoAnotherPage(pesananDiprosesPage);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            OpsiPengantaran opsiPengantaranPage = new OpsiPengantaran();
            MovetoAnotherPage(opsiPengantaranPage);
        }
    }
}
