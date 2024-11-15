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
    /// Interaction logic for ItemDescription.xaml
    /// </summary>
    public partial class ItemDescription : Window
    {
        int jumlahBarang = 0;

        public ItemDescription(string namaProduk, string harga, string deskripsi, BitmapImage productImage)
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
            TextBlockHarga.Text = harga.ToString();
            TextBlockDeskripsiProduk.Text = deskripsi;
            ImageKemasan.Source = productImage;
        }

        private void MovetoAnotherPage(Window newWindow)
        {
            this.Close();
            newWindow.Show();
        }

        // Connect to Postgre
        private NpgsqlConnection conn;
        string connstring = "";
        public DataTable dt;
        public static NpgsqlCommand cmd;


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

        private void MovetoShoppingChart(Window newWindow)
        {
            this.Close();
            newWindow.Show();
        }

        private void BtnToShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            string namaProduk = TextBlockNamaProduk.Text;
            string hargaProduk = TextBlockHarga.Text;
            int jumlahProduk = jumlahBarang;
            BitmapImage productImage = ImageKemasan.Source as BitmapImage;
            ShoppingCart shoppingCart = new ShoppingCart(namaProduk, hargaProduk, jumlahProduk, productImage);
            if (jumlahBarang != 0)
            {
                shoppingCart.ShowBorder = true;
            }
            else
            {
                shoppingCart.ShowBorder = false;
            }
            MovetoShoppingChart(shoppingCart);
        }

        private void BtnKeranjang_Click(object sender, RoutedEventArgs e)
        {
            // ini ntar dibalikin ke halaman yang banyak produk, tapi datanya dimasukin ke database.
        }

        private void Mulai_Berbelanja_Click(object sender, RoutedEventArgs e)
        {
            MainProduct mainProductPage = new MainProduct();
            MovetoAnotherPage(mainProductPage);
        }

        private void BtnBeliLangsung_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
