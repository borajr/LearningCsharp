using System;

namespace OtogaleriOtomasyon_G018
{
    class Program
    {
        static Galeri OtoGaleri = new Galeri();

        static void Main(string[] args)
        {
            // !!! Araba classından haberi olmasın program classının
            //bütün veri işlemlerini galeri nesnesindeki matotlar üzerinden sürdürelim
            Uygulama();
        }


        static void Uygulama()
        {
            Menu();
            SahteVeriGir();

            //sinema uygulamasındaki gibi her bir seçenek ayrı metot içinden çalıştırılacak

            Console.WriteLine();
            while (true)
            {

                Console.WriteLine();
                string secim = SecimAl();
                Console.WriteLine();

                switch (secim)
                {
                    case "1":
                    case "K":
                        AracKiralamaIslemleri();
                        break;
                    case "2":
                    case "T":
                        AracTeslim();
                        break;
                    case "3":
                    case "R":
                        KiralikAracListele();
                        break;
                    case "4":
                    case "M":
                        MusaitAracListele();
                        break;
                    case "5":
                    case "A":
                        TumArabalariListele();
                        break;
                    case "6":
                    case "Y":
                        YeniAracEkle();
                        break;
                    case "S":
                    case "7":
                        AracSil();
                        break;
                    case "8":
                    case "G":
                        GaleriBilgileri();
                        break;

                }
            }

        }

        static void Menu()
        {
            Console.WriteLine("1-Araba Kirala(K)");
            Console.WriteLine("2-Araba Teslim Al(T)");
            Console.WriteLine("3-Kiradaki Arabaları Listele(R)");
            Console.WriteLine("4-Müsait Arabaları Listele(M)");
            Console.WriteLine("5-Tüm Arabaları Listele(A)");
            Console.WriteLine("6-Yeni Araba Ekle(Y)");
            Console.WriteLine("7-Araba Sil(S)");
            Console.WriteLine("8-Bilgileri Göster(G)");

        }



        static string SecimAl()
        {
            Console.Write("Seçim: ");
            return Console.ReadLine().ToUpper();
        }


        static void AracKiralamaIslemleri()
        {
            Console.Write("Arac Plakası girin: ");
            string plaka = Console.ReadLine();

            int sayı;
            bool numaraMı = int.TryParse(plaka.Substring(0, 2), out sayı);           
            Araba arb = null;
            if (numaraMı == true)
            {
                foreach (Araba araba in OtoGaleri.Arabalar)
                {
                    if (plaka == araba.Plaka)
                    {
                        if (araba.Durum == DURUM.Galeride)
                        {
                            arb = araba;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Araç Kirada");
                        }
                    }
                    //else
                    //{
                    //    Console.WriteLine("Bu plakada bir araç yok");
                    //}

                }
            }
            else
            {
                Console.WriteLine("Geçerli Bir Plaka Girin");
            }


            if (arb != null)
            {
                Console.Write("Aracı Kaç Saatliğine Kiralayacaksını: ");
                string kiralamaSuresi = Console.ReadLine();
                int kiralıkSure;
                bool dogruDegerMi = int.TryParse(kiralamaSuresi, out kiralıkSure);


                if (dogruDegerMi == true)
                {
                    OtoGaleri.ArabaKirala(plaka, kiralıkSure);
                }
                else
                {
                    Console.WriteLine("Geçerli bir süre giriniz");
                }
            }

            //burada, ArabaKirala metoduna veriler gönderilmeden önce yapılacak çok kontrol var.
            //araba galeride mi ? böyle bir araba var mı?
            //kiralama süresi için doğru format girildi mi ?

        }

        static void AracTeslim()
        {
            Console.WriteLine("-Araç Teslim-");

            Console.WriteLine("Teslim Edilece Aracın Plakası");
            string plaka = Console.ReadLine();

            int sayı;
            bool numaraMı = int.TryParse(plaka.Substring(0, 2), out sayı);

            Araba arb = null;
            if (numaraMı == true)
            {
                foreach (Araba araba in OtoGaleri.Arabalar)
                {
                    if (plaka == araba.Plaka)
                    {
                        if (araba.Durum == DURUM.Kirada)
                        {
                            arb = araba;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Araç Galeride");
                        }
                    }
                    //else
                    //{
                    //    Console.WriteLine("Bu plakada bir araç yok");
                    //}

                }
            }
            else
            {
                Console.WriteLine("Geçerli Bir Plaka Girin");
            }

            if (arb != null)
            {
                arb.Durum = DURUM.Galeride;
            }

                

        }

        static void KiralikAracListele()
        {
            if (OtoGaleri.KiradakiAracSayisi == 0)
            {
                Console.WriteLine("Gösterilecek araç yok");
            }
            else
            {
                Console.WriteLine("3 - Kiralık Arabaların Listesi ");
                Console.WriteLine("                                  ");
                Console.WriteLine("Plaka           Marka             KiralamaBedeli             Durum           ");
                Console.WriteLine("----------------------------------");
                foreach (Araba araba in OtoGaleri.Arabalar)
                {
                    if (araba.Durum == DURUM.Kirada)
                    {
                        Console.WriteLine(araba.Plaka.PadRight(20, ' ') + araba.Marka.PadRight(20, ' ') + araba.KiralamaBedeli.ToString().PadRight(20, ' ') + araba.Durum);
                    }
                }
            }


        }

        static void MusaitAracListele()
        {
            if (OtoGaleri.GaleridekiAracSayisi == 0)
            {
                Console.WriteLine("Gösterilecek araba yok.");
            }
            else
            {

                Console.WriteLine("4 - Müsait Arabaların Listesi ");
                Console.WriteLine("                                  ");
                Console.WriteLine("Plaka           Marka             KiralamaBedeli             Durum           ");
                Console.WriteLine("----------------------------------");

                foreach (Araba araba in OtoGaleri.Arabalar)
                {

                    if (araba.Durum == DURUM.Galeride)
                    {
                        Console.WriteLine(araba.Plaka.PadRight(15, ' ') + araba.Marka.PadRight(15, ' ') + araba.KiralamaBedeli.ToString().PadRight(15, ' ') + araba.Durum);
                    }

                }
            }
        }

        static void YeniAracEkle()
        {
            Console.WriteLine("-Yeni Araç Ekle-");
            Console.WriteLine();

            Console.Write("Plaka: ");
            string plaka = Console.ReadLine();

            foreach (Araba araba in OtoGaleri.Arabalar)
            {
                if (plaka == araba.Plaka)
                {
                    Console.WriteLine("Aynı plakada araç mevcut. Girdiğiniz plakayı kontrol edin");
                }
                else
                {
                    Console.Write("Marka: ");
                    string marka = Console.ReadLine();

                    Console.Write("Kiralama Bedeli");
                    float kiralamaBedeli = float.Parse(Console.ReadLine());

                    Console.WriteLine("Araç Tipleri");
                    Console.WriteLine();
                    Console.WriteLine("SUV için 1");
                    Console.WriteLine("Hatchback için 2");
                    Console.WriteLine("Sedan için 3");
                    Console.WriteLine();
                    Console.Write("Araç tipi seçin: ");
                    string secim = Console.ReadLine();

                    switch (secim)
                    {
                        case "1":
                            OtoGaleri.ArabaEkle(plaka, marka, kiralamaBedeli, ARAC_TIPI.SUV);
                            Console.WriteLine("Araç eklendi");
                            break;
                        case "2":
                            OtoGaleri.ArabaEkle(plaka, marka, kiralamaBedeli, ARAC_TIPI.Hatchback);
                            Console.WriteLine("Araç Eklendi");
                            break;
                        case "3":
                            OtoGaleri.ArabaEkle(plaka, marka, kiralamaBedeli, ARAC_TIPI.Sedan);
                            Console.WriteLine("Araç Eklendi");
                            break;
                    }


                }
            }

        }

        static void AracSil()
        {
            Console.WriteLine("-Araç Sil-");
            Console.WriteLine();

            Console.Write("Plaka: ");
            string plaka = Console.ReadLine();

            Araba arb = null;

            foreach (Araba araba in OtoGaleri.Arabalar)
            {
                if (araba.Plaka == plaka)
                {
                    arb = araba;
                    break;
                }
            }

            if (arb != null)
            {
                Console.WriteLine("Marka: " + arb.Marka);
                Console.WriteLine("Araç Tipi: " + arb.AracTipi);
                Console.WriteLine();
                Console.WriteLine("Arabayı Silmek istediğinize emin misin (E/H)");
                string yanıt = Console.ReadLine();
                if (yanıt.ToUpper() == "E" || yanıt.ToUpper() == "EVET")
                {
                    OtoGaleri.Arabalar.Remove(arb);
                    Console.WriteLine("Araba Silindi");
                }
                else
                {
                    Console.WriteLine("Araba Silinmedi");
                }
            }
            else
            {
                Console.WriteLine("Böyle bir araba yok");
            }

        }
        static void SahteVeriGir()
        {
            OtoGaleri.ArabaEkle("23asd2323", "Opel", 80, ARAC_TIPI.Sedan);
            OtoGaleri.ArabaEkle("34ccc61", "Tofaş", 20, ARAC_TIPI.Sedan);
            OtoGaleri.ArabaEkle("55cb5522", "Audi", 100, ARAC_TIPI.Hatchback);
        }

        static void GaleriBilgileri()
        {
            Console.WriteLine("-Galeri Bilgileri-");
            Console.WriteLine();
            Console.WriteLine("Toplam Araç Sayısı: " + OtoGaleri.ToplamAracSayisi);
            Console.WriteLine("Kiradaki Araç Sayısı: " + OtoGaleri.KiradakiAracSayisi);
            Console.WriteLine("Galerideki Araç Sayısı: " + OtoGaleri.GaleridekiAracSayisi);
            //Console.WriteLine("Toplam araç kiralanma süresi: " + OtoGaleri.ToplamAracKiralanmaSuresi);
            //Console.WriteLine("Toplam araç kiralanma adedi: " + OtoGaleri.toplamarackiralanmaadedi);
            Console.WriteLine("Ciro: " + OtoGaleri.Ciro);
        }

        static void TumArabalariListele()
        {
            Console.WriteLine("5 - Tüm Arabaların Listesi ");
            Console.WriteLine("                                  ");
            Console.WriteLine("Plaka           Marka             KiralamaBedeli             Soyad           ");
            Console.WriteLine("----------------------------------");
            if (OtoGaleri.Arabalar.Count == 0)
            {
                Console.WriteLine("Gösterilecek araba yok.");
            }
            else
            {
                foreach (Araba x in OtoGaleri.Arabalar)
                {
                    Console.WriteLine(x.Plaka.PadRight(15, ' ') + x.Marka.PadRight(15, ' ') + x.KiralamaBedeli.ToString().PadRight(15, ' ') + x.KiralanmaSureleri.Count.ToString().PadRight(15, ' ') + x.Durum);
                }
            }

        }



    }
}
