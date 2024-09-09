using System;
using System Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoXycle 
{
    public class Pengguna
    {
        public string Nama { get; set; }
        public int Telepon { get; set; }
        public int Role { get; set; }
        public string AlamatEmail { get; set; }
        public string Password { get; set; }

        public Pengguna(string nama, int telepon, int role, string alamatEmail, string password)
        {
            Nama = nama;
            Telepon = telepon;
            Role = role;
            AlamatEmail = alamatEmail;
            Password = password;
        }
        public bool Login(string inputEmail, string inputPassword)
        {
            if (AlamatEmail == inputEmail && Password == inputPassword)
            {
                Console.WriteLine("Login berhasil");
                return true;
            }
            else
            {
                Console.WriteLine("Login gagal");
                return false;
            }
        }
        public bool SignUp(string nama)
        {
            if (!string.IsNullOrEmpty(nama))
            {
                Console.WriteLine("Sign-up berhasil untuk: " + nama);
                return true;
            }
            else
            {
                Console.WriteLine("Sign-up gagal");
                return false;
            }
        }
        public bool Logout()
        {
            Console.WriteLine("Logout berhasil");
            return true;
        }
    }
    public class Program
    {
        public static void Main()
        {
            Pengguna pengguna1 = new Pengguna("Rafa", 123456789, 1, "Rafa@zmail.com", "password345");

            pengguna1.Login("Rafa@zmail.com", "password345");
            pengguna1.SignUp("Rafa");
            pengguna1.Logout();
        }
    }
}