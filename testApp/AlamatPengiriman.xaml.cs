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

        // Connect to Postgre
        private NpgsqlConnection conn;
        string connstring = "Host=conqueror.postgres.database.azure.com;Port=5432;Username=postgres;Password=Boxycle2;Database=Boxycle";
        public DataTable dt;
        public static NpgsqlCommand cmd;
        private string inputdata = null;

        private void BtnSimpanAlamat_Click(object sender, RoutedEventArgs e)
        {
            string jalan = JalanTextBox.Text;
            string kecamatan = KecamatanTextBox.Text;
            string kabupaten = KabupatenTextBox.Text;
            string provinsi = ProvinsiTextBox.Text;
            int kodepos;

            try
            {
                if (!int.TryParse(KodePosTextBox.Text, out kodepos))
                {
                    MessageBox.Show("Kode pos harus berupa angka. Silakan periksa kembali.", "Error", MessageBoxButton.OK);
                    return;
                }

                conn = new NpgsqlConnection(connstring);
                conn.Open();

                inputdata = "INSERT INTO public.\"alamat\" (\"jalan\", \"kecamatan\", \"kabupaten_kota\", \"provinsi\", \"kode_pos\") " +
                            "VALUES (@jalan, @kecamatan, @kabupaten, @provinsi, @kodepos)";
                cmd = new NpgsqlCommand(inputdata, conn);



                // Use parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("jalan", jalan);
                cmd.Parameters.AddWithValue("kecamatan", kabupaten);
                cmd.Parameters.AddWithValue("kabupaten", kabupaten);
                cmd.Parameters.AddWithValue("provinsi", provinsi);
                cmd.Parameters.AddWithValue("kodepos", kodepos);

                // Execute the update command
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Alamat Pengiriman Berhasil Tersimpan", "Success", MessageBoxButton.OK);

                    // Navigate to the next page, e.g., MainProduct
                    CekHargaOngkir cekhargaongkir = new CekHargaOngkir();
                    MovetoAnotherPage(cekhargaongkir);
                }
                else
                {
                    MessageBox.Show("Penyimpanan alamat gagal. Silakan coba lagi", "Error", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK);
            }
            finally
            {
                conn.Close();
            }


        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            OpsiPengantaran opsiPengantaranPage = new OpsiPengantaran();
            MovetoAnotherPage(opsiPengantaranPage);
        }


    }
}
