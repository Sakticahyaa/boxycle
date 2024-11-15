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
    /// Interaction logic for CompleteUserData.xaml
    /// </summary>
    public partial class CompleteUserData : Window
    {
        public CompleteUserData()
        {
            InitializeComponent();
            #if DEBUG
            this.Width = 813;
            this.Height = 475;
            #endif
        }

        private void OpenAnotherPage(Window newWindow)
        {
            this.Hide();
            newWindow.Show();
        }

        // Connect to Postgre
        private NpgsqlConnection conn;
        string connstring = "";
        public DataTable dt;
        public static NpgsqlCommand cmd;
        private string inputdata = null;

        private void BtnSimpanDataPengguna_Click(object sender, RoutedEventArgs e)
        {
            string nama = NamaTextBox.Text;
            string notelp = NoTelpTextBox.Text;
            bool role = RbPembeli.IsChecked == true;

            try
            {
                conn = new NpgsqlConnection(connstring);
                conn.Open();

                inputdata = "UPDATE public.\"pengguna\" " +
                    "SET \"nama\" = @nama, \"nomor_telepon\" = @nomor_telepon, \"roles\" = @roles " +
                    "WHERE \"created_at\" = (SELECT MAX(\"created_at\") FROM public.\"pengguna\")";
                cmd = new NpgsqlCommand(inputdata, conn);

                cmd.Parameters.AddWithValue("Nama", nama);
                cmd.Parameters.AddWithValue("Nomor_Telepon", notelp);
                cmd.Parameters.AddWithValue("Roles", role);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data Pengguna Berhasil Tersimpan", "Success", MessageBoxButton.OK);

                    MainProduct mainProductPage = new MainProduct();
                    OpenAnotherPage(mainProductPage);
                }
                else
                {
                    MessageBox.Show("Pendaftaran gagal. Silakan coba lagi", "Error", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
