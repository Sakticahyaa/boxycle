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
using static System.Collections.Specialized.BitVector32;

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

        public static class Session
        {
            public static int? UserId { get; set; }
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

                // Query to check if email and password exist in the database
                sql = "SELECT \"userid\", \"roles\" FROM public.\"pengguna\" WHERE \"email\" = @Email AND \"password\" = @Password";
                cmd = new NpgsqlCommand(sql, conn);

                // Use parameters to prevent SQL injection
                cmd.Parameters.AddWithValue("Email", email);
                cmd.Parameters.AddWithValue("Password", password);

                // Execute the query
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // Check if the query returns a result
                    {
                        // Retrieve userId and roles
                        int userId = reader.GetInt32(0);
                        bool roles = reader.GetBoolean(1);

                        // Save the userId in the session
                        Session.UserId = userId;

                        MessageBox.Show("Sign in berhasil", "Success", MessageBoxButton.OK);

                        // Navigate based on the roles value
                        if (roles) // If roles is true
                        {
                            MainProduct mainProductPage = new MainProduct();
                            MovetoAnotherPage(mainProductPage);
                        }
                        else // If roles is false
                        {
                            MainProduct_Penjual mainProductPenjualPage = new MainProduct_Penjual();
                            MovetoAnotherPage(mainProductPenjualPage);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email atau Password salah. Tolong coba lagi", "Sign in Failed", MessageBoxButton.OK);
                    }
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
