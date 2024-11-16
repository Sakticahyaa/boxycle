using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ItemDescription_Penjual.xaml
    /// </summary>
    public partial class ItemDescription_Penjual : Window
    {
        int jumlahBarang = 0;
        private int _limbahId;

        public ItemDescription_Penjual(string namaProduk, string deskripsi, BitmapImage productImage, int limbahId)
        {
            InitializeComponent();

            #if DEBUG
            this.Width = 813;
            this.Height = 475;
            #endif

            // Set JumlahBarang awal
            TextBlockJumlahProduk.Text = jumlahBarang.ToString();

            // Set Nama Produk dan Harga
            TextBlockNamaProduk.Text = namaProduk;
            TextBlockDeskripsiProduk.Text = deskripsi;
            ImageKemasan.Source = productImage;
            _limbahId = limbahId;
        }

        // Connect to Postgre
        private NpgsqlConnection conn;
        string connstring = "";
        public DataTable dt;
        public static NpgsqlCommand cmd;

        private void MovetoAnotherPage(Window newWindow)
        {
            this.Close();
            newWindow.Show();
        }

        private void MinButton_Click(object sender, RoutedEventArgs e)
        {
            if (jumlahBarang > 0)
            {
                jumlahBarang--;
                TextBlockJumlahProduk.Text = jumlahBarang.ToString();
            }
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            jumlahBarang++;
            TextBlockJumlahProduk.Text = jumlahBarang.ToString();
        }

        private void MovetoShoppingCart(Window newWindow)
        {
            this.Close();
            newWindow.Show();
        }

        private void PilihProduk_Click(object sender, RoutedEventArgs e)
        {
            MainProduct_Penjual mainProductPenjualPage = new MainProduct_Penjual();
            MovetoAnotherPage(mainProductPenjualPage);
        }
    }
}
