using Npgsql;
using System;
using System.Data;
using System.Windows;
using System.Windows.Media.Imaging;

namespace testApp
{
    /// <summary>
    /// Interaction logic for OpsiPengantaran.xaml
    /// </summary>
    public partial class OpsiPengantaran : Window
    {
        public string _namaProduk;
        public string _hargaProduk;
        public string _deskripsiProduk;
        public int _jumlahProduk;
        public int _subTotal;
        public BitmapImage _productImage;
        public int _limbahId;
        public int _sessionUserId; // Store session user ID

        public OpsiPengantaran()
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

        private void BtnkePesananDiproses_Click(object sender, RoutedEventArgs e)
        {
            PesananDiproses pesananDiprosesPage = new PesananDiproses();
            MovetoAnotherPage(pesananDiprosesPage);
        }

        private void BtnkeIsiAlamat_Click(object sender, RoutedEventArgs e)
        {
            AlamatPengiriman alamatPengirimanPage = new AlamatPengiriman();
            MovetoAnotherPage(alamatPengirimanPage);
        }

 
    }
}
