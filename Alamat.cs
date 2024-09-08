using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Alamat
{
    public Alamat()
    {
        // Definisi Property
        public string Jalan { get; set; }
        public string Kecamatan { get; set; }
        public string KabupatenKota { get; set; }
        public string Provinsi { get; set; }
        public int KodePos { get; set; }
    }

    public bool PembaruanData(string Jalan, string Kecamatan, string KabupatenKota, string Provinsi, int KodePos)
    {
        try
        {
            Jalan = Jalan;
            Kecamatan = Kecamatan;
            KabupatenKota = KabupatenKota;
            Provinsi = Provinsi;
            KodePos = KodePos;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void HubTerdekat(string Jalan, string Kecamatan, string KabupatenKota, string Provinsi int KodePos)
    {
        var HubKodePosSama = Hubs.FirstOrderDefault(h => h.KodePos == this.KodePos);
        if (HubKodePosSama != null)
        {
            return true;
        }
        else
        {
            var HubKecamatanSama = Hubs.FirstOrderDefault(h => h.Kecamatan == this.Kecamatan);
            if (HubKecamaranSama != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool Validasi(string Jalan, string Kecamatan, string KabupatenKota, string Provinsi, int KodePos)
    {
        if (string.IsNullOrEmpty(Jalan) ||
        string.IsNullOrEmpty(Kecamatan) ||
        string.IsNullOrEmpty(KabupatenKota) ||
        string.IsNullOrEmpty(Provinsi)) ||
        KodePos <= 0) 
		    {
            return false; // Data tidak valid
        }

            else
        {
            return true; // Data Valid
        }
    }

}
class Program
{
    static void Main(string[] args)
    {
        Alamat Alamat1 = new Alamat("Jalan Utan Kayu 5", "Mlati", "Sleman", "DI Yogyakarta", 55284);

        Console.WriteLine("Jalan: " + Alamat1.Jalan);
        Console.WriteLine("Kecamatan: " + Alamat1.Kecamatan);
        Console.WriteLine("Kabupaten/Kota: " + Alamat1.KabupatenKota);
        Console.WriteLine("Provinsi: " + Alamat1.Provinsi);
        Console.WriteLine("Kode Pos: " + Alamat1.KodePos);
    }
}