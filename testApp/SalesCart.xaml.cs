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
    /// Interaction logic for SalesCart.xaml
    /// </summary>
    public partial class SalesCart : Window
    {
        private string _namaProduk;
        private string _deskripsiProduk;
        private BitmapImage _productImage;
        private int _limbahId;

        public SalesCart(string namaProduk, int jumlahProduk, BitmapImage productImage, int limbahId)
        {
            InitializeComponent();

            _namaProduk = namaProduk;
            _productImage = productImage;
            _limbahId = limbahId;

            #if DEBUG
            this.Width = 813;
            this.Height = 475;
            #endif

            TextBlockNamaProduk.Text = namaProduk;
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

        private void BackButton3_Click(object sender, RoutedEventArgs e)
        {
            MainProduct_Penjual mainProductPenjualPage = new MainProduct_Penjual();
            MovetoAnotherPage(mainProductPenjualPage);
        }

        private void Mulai_BerjualanClick(object sender, RoutedEventArgs e)
        {
            MainProduct_Penjual mainProductPenjualPage = new MainProduct_Penjual();
            MovetoAnotherPage(mainProductPenjualPage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpsiPengantaran opsiPengantaaranPage = new OpsiPengantaran();
            MovetoAnotherPage(opsiPengantaaranPage);
        }
    }
}
