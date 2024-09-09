using System;
using System Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoXycle
{
    public class Transaksi
    {
        private int _limbah;
        private int _berat;
        private int _metodePengiriman;
        private int _hub;
        private int _harga;

        public int Limbah
        {
            get { return _limbah; }
            set { _limbah = value; }
        }
        public int Berat
        {
            get { return _berat; }
            set { _berat = value; }
        }
        public int MetodePengiriman
        {
            get { return _metodePengiriman; }
            set { _metodePengiriman = value; }
        }
        public int Hub
        {
            get { return _hub; }
            set { _hub = value; }
        }
        public int Harga
        {
            get { return _harga; }
            set { _harga = value; }
        }
        public int BukaLimbah(int limbah)
        {
            return limbah;
        }
        public int PilihPengiriman(int metodePengiriman)
        {
            return metodePengiriman;
        }
        public int PilihHub(int hub)
        {
            return hub;
        }
        public bool Validasi(int limbah, int berat, int metodePengiriman, int hub)
        {
            if (limbah != -1 && berat != -1 && metodePengiriman != -1 && hub != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Bayar(int harga)
        {
            return harga;
        }
    }
}
