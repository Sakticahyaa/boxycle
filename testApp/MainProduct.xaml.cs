using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Interaction logic for MainProduct.xaml
    /// </summary>
    public partial class MainProduct : Window
    {
        public MainProduct()
        {
            InitializeComponent();

            #if DEBUG
            this.Width = 813;
            this.Height = 475;
            #endif


        }

        // Connect to Postgre
        private NpgsqlConnection conn;
        string connstring = "";
        public DataTable dt;
        public static NpgsqlCommand cmd;

        private void TBItem1_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                string sql = "SELECT \"namalimbah\" FROM public.\"limbah\" LIMIT 1";
                cmd = new NpgsqlCommand(sql, conn);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    TBItem1.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("Data tidak ditemukan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void TBHargaItem1_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                string sql = "SELECT \"hargalimbah\" FROM public.\"limbah\" LIMIT 1";
                cmd = new NpgsqlCommand(sql, conn);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    TBHargaItem1.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("Data tidak ditemukan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void TBItem2_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                string sql = "SELECT \"namalimbah\" FROM public.\"limbah\" WHERE \"limbahid\" = 2";
                cmd = new NpgsqlCommand(sql, conn);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    TBItem2.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("Data tidak ditemukan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void TBHargaItem2_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                string sql = "SELECT \"hargalimbah\" FROM public.\"limbah\" WHERE \"limbahid\" = 2";
                cmd = new NpgsqlCommand(sql, conn);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    TBHargaItem2.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("Data tidak ditemukan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private string GetProductDescription(int productId)
        {
            string description = string.Empty;
            try
            {
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                string sql = $"SELECT \"deskripsilimbah\" FROM public.\"limbah\" WHERE \"limbahid\" = {productId}";
                cmd = new NpgsqlCommand(sql, conn);
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    description = result.ToString();
                }
                else
                {
                    MessageBox.Show("Data tidak ditemukan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return description;
        }

        private void MovetoAnotherPage(Window newWindow)
        {
            this.Close();
            newWindow.Show();
        }

        private BitmapImage ConvertToImage(byte[] imageData)
        {
            BitmapImage bitmap = new BitmapImage();
            using (MemoryStream stream = new MemoryStream(imageData))
            {
                bitmap.BeginInit();
                bitmap.StreamSource = stream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
            }
            return bitmap;
        }

        private void ImgItem1_Loaded(object sender, RoutedEventArgs e)
        {
            LoadImage(1, ImgItem1); 
        }

        private void ImgItem2_Loaded(object sender, RoutedEventArgs e)
        {
            LoadImage(2, ImgItem2); 
        }

        public void LoadImage(int limbahId, Image imgControl)
        {
            BitmapImage bitmapImage = null;
            try
            {
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                string sql = $"SELECT \"gambarlimbah\" FROM public.\"limbah\" WHERE \"limbahid\" = {limbahId}";
                cmd = new NpgsqlCommand(sql, conn);

                byte[] imageData = cmd.ExecuteScalar() as byte[];

                if (imageData != null && imageData.Length > 0)
                {
                    BitmapImage image = ConvertToImage(imageData);
                    imgControl.Source = image;
                }
                else
                {
                    MessageBox.Show($"No image data found for limbahid = {limbahId}.", "No Image", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButton.OK);
            }
            finally
            {
                conn.Close();
            }
        }

        private int GetLimbahIdForClickedItem(object sender)
        {
            // Logic to get limbahid based on sender (e.g., Button or UI control that triggered the event)
            // This might involve setting limbahid as a Tag on each Button or control representing an item

            Button clickedButton = sender as Button;
            return clickedButton != null && clickedButton.Tag is int ? (int)clickedButton.Tag : 0;
        }

        public void BtnItem1_Click(object sender, RoutedEventArgs e)
        {
            int limbahId = GetLimbahIdForClickedItem(sender);
            string namaProduk = TBItem1.Text;
            string harga = TBHargaItem1.Text;
            string deskripsi = GetProductDescription(1);
            BitmapImage productImage = ImgItem1.Source as BitmapImage;


            ItemDescription itemDescriptionPage = new ItemDescription(namaProduk, harga, deskripsi, productImage);
            MovetoAnotherPage(itemDescriptionPage);


        }

        public void BtnItem2_Click(object sender, RoutedEventArgs e)
        {
            int limbahId = GetLimbahIdForClickedItem(sender);
            string namaProduk = TBItem2.Text;
            string harga = TBHargaItem2.Text;
            string deskripsi = GetProductDescription(2);
            BitmapImage productImage = ImgItem2.Source as BitmapImage;

            ItemDescription itemDescriptionPage = new ItemDescription(namaProduk, harga, deskripsi, productImage);
            MovetoAnotherPage(itemDescriptionPage);
        }
    }
}
