using System;
using System.Collections.Generic;
using System.Text;

namespace OtogaleriOtomasyon_G018
{

    class Galeri
    {
        

        public List<Araba> Arabalar = new List<Araba>();

        public int ToplamAracSayisi
        {
            get
            {
                return this.Arabalar.Count;
            }
        }
        public int KiradakiAracSayisi
        {
            get
            {
                int adet = 0;
                foreach (Araba item in this.Arabalar)
                {
                    if (item.Durum == DURUM.Kirada)
                    {
                        adet++;
                    }
                }
                return adet;
            }
        }
        public int GaleridekiAracSayisi
        {
            get
            {
                int adet = 0;
                foreach (Araba item in this.Arabalar)
                {
                    if (item.Durum == DURUM.Galeride)
                    {
                        adet++;
                    }
                }
                return adet;
            }
        }

        //public int toplamarackiralanmasuresi
        //{
        //    get
        //    {

        //    }
        //}

        //public int toplamarackiralanmaadedi
        //{
        //    get
        //    {

        //    }
        //}

        public float Ciro
        {
            get
            {
                float ciro = 0;
                foreach (Araba item in this.Arabalar)
                {
                    if (item.Durum == DURUM.Kirada)
                    {
                        ciro = ciro + item.KiralamaBedeli;
                    }
                }
                return ciro;
            }
        }

        public void ArabaEkle(string plaka, string marka, float kiralamaBedeli, ARAC_TIPI aracTipi)
        {
            Araba a = new Araba(plaka, marka, kiralamaBedeli, aracTipi);
            this.Arabalar.Add(a);
        }

        public void ArabaKirala(string plaka, int kiralamaSuresi)
        {
            Araba a = null;

            foreach (Araba item in this.Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    a = item;
                }
            }

            a.KiralanmaSureleri.Add(kiralamaSuresi);
            a.Durum = DURUM.Kirada;
        }




    }

}
