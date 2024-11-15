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
    /// Interaction logic for ShoppingCart.xaml
    /// </summary>
    public partial class ShoppingCart : Window
    {
        public ShoppingCart(string namaProduk, string hargaProduk, int jumlahProduk, BitmapImage productImage)
        {
            InitializeComponent();

            #if DEBUG
            this.Width = 813;
            this.Height = 475;
            #endif

            decimal harga;
            if (!decimal.TryParse(hargaProduk, out harga))
            {
                MessageBox.Show("Harga produk tidak valid");
                return;
            }

            decimal subtotal = harga * jumlahProduk;
            TextBlockSubtotal.Text = subtotal.ToString();

            TextBlockNamaProduk.Text = namaProduk;
            TextBlockHargaProduk.Text = hargaProduk.ToString();
            TextBlockJumlahItem.Text = jumlahProduk.ToString();
            ImageProduk.Source = productImage;


        }

        public bool ShowBorder { get; set; }
        private void BorderProduk1_Loaded(object sender, RoutedEventArgs e)
        {
            if (ShowBorder)
            {
                BorderProduk1.Visibility = Visibility.Visible;
            }
            else
            {
                BorderProduk1.Visibility = Visibility.Collapsed;
            }
        }

        private void BlmAdaBarang_Loaded(object sender, RoutedEventArgs e)
        {
            if (ShowBorder == true)
            {
                BlmAdaBarang.Visibility = Visibility.Collapsed;
            }
            else
            {
                BlmAdaBarang.Visibility = Visibility.Visible;
            }
        }

        private void MovetoAnotherPage(Window newWindow)
        {
            this.Close();
            newWindow.Show();
        }

        private void Mulai_Berbelanja_Click(object sender, RoutedEventArgs e)
        {
            MainProduct mainProductPage = new MainProduct();
            MovetoAnotherPage(mainProductPage);
        }
    }
}
