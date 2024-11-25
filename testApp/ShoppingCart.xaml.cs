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
    /// Interaction logic for ShoppingCart.xaml
    /// </summary>
    public partial class ShoppingCart : Window
    {
        private string _namaProduk;
        private int _hargaProduk;
        private string _deskripsiProduk;
        private BitmapImage _productImage;
        private int _limbahId;
        private int _jumlahProduk;

        public ShoppingCart(string namaProduk, string hargaProduk, int jumlahProduk, BitmapImage productImage, int limbahId)
        {
            InitializeComponent();

            _namaProduk = namaProduk;
            _productImage = productImage;
            _limbahId = limbahId;
            _jumlahProduk = jumlahProduk;

            if (!decimal.TryParse(hargaProduk, out decimal harga))
            {
                MessageBox.Show("Harga produk tidak valid");
                return;
            }
            _hargaProduk = (int)harga;

            decimal subtotal = harga * jumlahProduk;
            TextBlockSubtotal.Text = subtotal.ToString("C");
            TextBlockNamaProduk.Text = namaProduk;
            TextBlockHargaProduk.Text = harga.ToString("C");
            TextBlockJumlahItem.Text = jumlahProduk.ToString();
            ImageProduk.Source = productImage;
        }


        private NpgsqlConnection conn;
        string connstring = "Host=conqueror.postgres.database.azure.com;Port=5432;Username=postgres;Password=Boxycle2;Database=Boxycle";
        public DataTable dt;
        public static NpgsqlCommand cmd;
        private string inputdata = null;

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

        private void BackButton2_Click(object sender, RoutedEventArgs e)
        {
            MainProduct mainProductPage = new MainProduct();
            MovetoAnotherPage(mainProductPage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (conn = new NpgsqlConnection(connstring))
                {
                    conn.Open();

                    string namaProduk = _namaProduk;
                    int hargaProduk = _hargaProduk;
                    int jumlahProduk = _jumlahProduk;
                    int limbahid = _limbahId;
                    int subTotal = hargaProduk * jumlahProduk;

                    // Define SQL insert query
                    inputdata = "INSERT INTO public.\"transaksi\" (\"namaproduk\", \"hargaproduk\", \"jumlahproduk\", \"subtotal\") " +
                                "VALUES (@namaProduk, @hargaProduk, @jumlahProduk, @subTotal)";


                    // Prepare command
                    using (cmd = new NpgsqlCommand(inputdata, conn))
                    {
                        cmd.Parameters.AddWithValue("@namaProduk", namaProduk);
                        cmd.Parameters.AddWithValue("@hargaProduk", hargaProduk);
                        cmd.Parameters.AddWithValue("@jumlahProduk", jumlahProduk);
                        cmd.Parameters.AddWithValue("@subTotal", subTotal);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        MessageBox.Show(rowsAffected > 0
                            ? "Data successfully inserted into the database."
                            : "Failed to insert data into the database.",
                            "Database Operation", MessageBoxButton.OK,
                            rowsAffected > 0 ? MessageBoxImage.Information : MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database operation failed: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            OpsiPengantaran opsiPengantaran = new OpsiPengantaran();
            MovetoAnotherPage(opsiPengantaran);
        }

    }
}
