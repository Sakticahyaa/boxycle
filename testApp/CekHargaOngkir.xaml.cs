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
    /// Interaction logic for CekHargaOngkir.xaml
    /// </summary>
    public partial class CekHargaOngkir : Window
    {
        public CekHargaOngkir()
        {
            List<string> listKota = new List<string>();
            InitializeComponent();

#if DEBUG
            this.Width = 813;
            this.Height = 475;
#endif

            listKota = Ongkir.GetKotaList();

            // Ambil ID kota berdasarkan input kota asal dan kota tujuan
            int idAsal = GetIdKota(AsalTB.Text);
            int idTujuan = GetIdKota(TujuanTB.Text);
        }

        private int GetIdKota(string kota)
        {
            int idKota = -1;
            idKota = Ongkir.GetIdKotaList(kota);
            return idKota;
        }


        private void TampilkanDaftar(List<string> daftarLayanan)
        {
            // Membuat teks hasil daftar layanan
            string hasil = "Detail Layanan:";
            foreach (string layanan in daftarLayanan)
            {
                hasil += $"\n- {layanan}";
            }

            // Menampilkan teks dalam TextBlock yang ada di GroupBox
            TextBlockLayanan.Text = hasil;
        }

        private void BtnCekHarga_Click(object sender, RoutedEventArgs e)
        {
            string kurir = "";
            if (rbJNE.IsChecked == true)
                kurir = "jne";
            else if (rbPOS.IsChecked == true)
                kurir = "pos";
            else if (rbTIKI.IsChecked == true)
                kurir = "tiki";
            List<string> daftarLayanan = Ongkir.GetLayananList
                (GetIdKota(AsalTB.Text), GetIdKota(TujuanTB.Text), int.Parse(BeratTB.Text), kurir);
            TampilkanDaftar(daftarLayanan);
        }

        private void MovetoAnotherPage(Window newWindow)
        {
            this.Close();
            newWindow.Show();
        }

        private void BtnSelanjutnya_Click(object sender, RoutedEventArgs e)
        {
            PesananDiproses pesananDiprosesPage = new PesananDiproses();
            MovetoAnotherPage(pesananDiprosesPage);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AlamatPengiriman alamatPengirimanPage = new AlamatPengiriman();
            MovetoAnotherPage(alamatPengirimanPage);
        }
    }
}
