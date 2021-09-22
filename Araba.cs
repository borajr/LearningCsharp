using System;
using System.Collections.Generic;
using System.Text;

namespace OtogaleriOtomasyon_G018
{
    class Araba
    {
        static Galeri glr = new Galeri();

        public string Plaka { get; set; }
        public string Marka { get; set; }
        public float KiralamaBedeli { get; set; }
        public List<int> KiralanmaSureleri = new List<int>();
        public int ToplamKiralanmaAdedi
        {
            get
            {
                return this.KiralanmaSureleri.Count;
            }
        }
        public int ToplamKiralanmaSuresi
        {
            get
            {
                int toplam = 0;
                foreach (int item in this.KiralanmaSureleri)
                {
                    toplam += item;
                }
                return toplam;
            }
        }
        public DURUM Durum { get; set; }
        public ARAC_TIPI AracTipi { get; set; }

        public Araba(string plaka, string marka, float kiralamaBedeli, ARAC_TIPI aracTipi)
        {
            this.Plaka = plaka;
            this.Marka = marka;
            this.KiralamaBedeli = kiralamaBedeli;
            this.AracTipi = aracTipi;
            this.Durum = DURUM.Galeride;
        }


    }

    public enum DURUM
    {
        Empty,
        Kirada,
        Galeride
    }

    public enum ARAC_TIPI
    {
        Empty,
        SUV,
        Hatchback,
        Sedan
    }




}
