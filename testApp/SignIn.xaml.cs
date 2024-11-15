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
using Npgsql;

namespace testApp
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
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
        string connstring = "";
        public DataTable dt;
        public static NpgsqlCommand cmd;
        private string sql = null;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(connstring))
            {
                MessageBox.Show("Connection string is null or empty.");
            }

            string email = MailTextBox.Text;
            string password = PasswordTextBox.Password;
            try
            {
                conn = new NpgsqlConnection(connstring);
                conn.Open();

                sql = "SELECT COUNT(1) FROM public.\"pengguna\" WHERE \"email\" = @email AND \"password\" = @password";
                cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("Email", email);
                cmd.Parameters.AddWithValue("Password", password);

                int userExists = Convert.ToInt32(cmd.ExecuteScalar());

                if (userExists > 0)
                {
                    MessageBox.Show("Sign in berhasil", "Success", MessageBoxButton.OK);
                    // ke main page
                    MainProduct mainProductPage = new MainProduct();
                    MovetoAnotherPage(mainProductPage);

                }
                else
                {
                    MessageBox.Show("Email atau Password salah. Tolong coba lagi", "Sign in Failed", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Fail to sign up", MessageBoxButton.OK);

            }
            finally
            {
                conn.Close();
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            RegisterAccount registerAccountPage = new RegisterAccount();
            MovetoAnotherPage(registerAccountPage);
        }

        private void LangsungkeMainPage_Click(object sender, RoutedEventArgs e)
        {
            MainProduct mainProductPage = new MainProduct();
            MovetoAnotherPage(mainProductPage);
        }
    }

    
}
