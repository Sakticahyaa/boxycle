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
    /// Interaction logic for RegisterAccount.xaml
    /// </summary>
    public partial class RegisterAccount : Window
    {
        public RegisterAccount()
        {
            InitializeComponent();
            #if DEBUG
            this.Width = 813;
            this.Height = 475;
            #endif
        }

        // Connect to Postgre
        private NpgsqlConnection conn;
        string connstring = "Host=conqueror.postgres.database.azure.com;Port=5432;Username=postgres;Password=Boxycle2;Database=Boxycle";
        public DataTable dt;
        public static NpgsqlCommand cmd;
        private string inputdata = null;

        private void OpenAnotherPage(Window newWindow)
        {
            this.Hide();
            newWindow.Show();
        }

        private void BtnRegistrasiAkun_Click(object sender, RoutedEventArgs e)
        {
            string email = MailTextBox.Text;
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;
            string password2 = PasswordTextBox2.Password;

            if (password != password2)
            {
                MessageBox.Show("Password tidak cocok! Silakan periksa kembali", "Masukkan Password Berbeda", MessageBoxButton.OK);
                return;
            }

            try
            {
                conn = new NpgsqlConnection(connstring);
                conn.Open();

                // Cek Email dan Username
                string checkusername = "SELECT COUNT(1) FROM public.\"pengguna\" WHERE \"email\" = @email OR \"username\" = @username";
                var cmd2 = new NpgsqlCommand(checkusername, conn);

                cmd2.Parameters.AddWithValue("Email", email);
                cmd2.Parameters.AddWithValue("Username", username);
                int exists = Convert.ToInt32(cmd2.ExecuteScalar());
                if (exists > 0)
                {
                    MessageBox.Show("Email atau Username sudah terdaftar. Silakan gunakan yang lain.", "Sign Up Failed", MessageBoxButton.OK);
                    return;
                }

                // Memasukkan data pengguna ke database
                inputdata = "INSERT INTO public.\"pengguna\" (\"email\", \"username\", \"password\", \"created_at\") VALUES (@email, @username, @password, @created_at)";
                cmd = new NpgsqlCommand(inputdata, conn);

                cmd.Parameters.AddWithValue("Email", email);
                cmd.Parameters.AddWithValue("Username", username);
                cmd.Parameters.AddWithValue("Password", password);
                cmd.Parameters.AddWithValue("Created_At", DateTime.Now);


                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Registrasi akun berhasil", "Success", MessageBoxButton.OK);
                    CompleteUserData completeUserDataPage = new CompleteUserData();
                    OpenAnotherPage(completeUserDataPage);
                }
                else
                {
                    MessageBox.Show("Registrasi akun gagal. Silakan coba lagi", "Error", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void MailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
