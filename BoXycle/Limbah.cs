using System;
using System Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoXycle
{
    public class Limbah
    {
        public int JenisLimbah { get; set; }
        public bool Kualitas { get; set; }
        public int HargaPerKg { get; set; }


        public Limbah(int jenisLimbah, bool kualitas, int hargaPerKg)
        {
            JenisLimbah = jenisLimbah;
            Kualitas = kualitas;
            HargaPerKg = hargaPerKg;
        }
    }

    public class Program
    {
        public static void Main()
        {
            Limbah limbah = new Limbah(1, true, 5000);

            Console.WriteLine($"Jenis Limbah: {limbah.JenisLimbah}");
            Console.WriteLine($"Kualitas Limbah: {limbah.Kualitas}");
            Console.WriteLine($"Harga per Kg: {limbah.HargaPerKg}");
        }
    }
}