using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadırYeriRezervasyonu
{
    class CadirRezervasyonu : Rezervasyon
    {
        public void CadirRezervasyonu1()
        {
            kiralanan = "Yer";
        }
        //static void Main(string[] args)
        //{
        //    Rezervasyon rezervasyon = new Rezervasyon();
        //    rezervasyon.RastegeleDoldur();
        //    while (true)
        //    {
        //        Console.WriteLine("");
        //        Console.WriteLine("      Çadır Yeri Rezervasyonu");
        //        Console.WriteLine("1-Bugunku bos yerleri goster");
        //        Console.WriteLine("2-30 gunluk doluluk durumu");
        //        Console.WriteLine("3-Gün bazında doluluk oranları");
        //        Console.WriteLine("4-Bugun icin hizli rezervasyon(küçük çadır)");
        //        Console.WriteLine("5-Iki tarih arasi rezervasyon(küçük çadır)");
        //        Console.WriteLine("6-Bugun icin hizli rezervasyon(büyük çadır)");
        //        Console.WriteLine("7-Iki tarih arasi rezervasyon(büyük çadır)");
        //        Console.WriteLine("8-Gun sonu islemi");

        //        switch (Console.ReadKey().KeyChar)
        //        {
        //            case '1':
        //                {
        //                    Console.WriteLine();
        //                    Console.WriteLine("Bugunku bos yer yok");
        //                    rezervasyon.BugunkuBosOdalar();
        //                    break;
        //                }
        //            case '2':
        //                {
        //                    Console.WriteLine();
        //                    Console.WriteLine("30 gunluk doluluk durumu");
        //                    Console.Write("      ");
        //                    rezervasyon.AylikDolulukDurumu();
        //                    break;
        //                }
        //            case '3':
        //                {
        //                    Console.WriteLine();
        //                    Console.WriteLine("Gün bazında doluluk oranları");
        //                    rezervasyon.GunBazindaDolulukOranlari();
        //                    break;

        //                }
        //            case '4':
        //                {
        //                    Console.WriteLine();
        //                    Console.WriteLine("Bugun icin hizli rezervasyon(küçük çadır)");
        //                    rezervasyon.KucukCadirHizliRezervasyon(DateTime.Today, DateTime.Today);
        //                    break;

        //                }
        //            case '5':
        //                {
        //                    Console.WriteLine();
        //                    Console.WriteLine("Iki tarih arasi rezervasyon(küçük çadır)");

        //                    rezervasyon.IkiTarihArasiRezervasyon(DateTime.Today, DateTime.Today);
        //                    break;
        //                }
        //            case '6':
        //                {
        //                    Console.WriteLine();
        //                    Console.WriteLine("Bugun icin hizli rezervasyon(büyük çadır)");
        //                    rezervasyon.BuyukCadirHizliRezervasyon(DateTime.Today, DateTime.Today);
        //                    break;
        //                }
        //            case '7':
        //                {
        //                    Console.WriteLine();
        //                    Console.WriteLine("Iki tarih arasi rezervasyon(büyük çadır)");

        //                    rezervasyon.IkiTarihArasıRezervasyonBuyukCadir(DateTime.Today, DateTime.Today);
        //                    break;
        //                }
        //            case '8':
        //                {
        //                    Console.WriteLine();
        //                    Console.WriteLine("Gun sonu islemi");
        //                    rezervasyon.GunSonuIslemi();
        //                    break;
        //                }
        //        }
        //    }
        //}
    }
    class Rezervasyon
    {
        protected const int odaSayisi = 10;
        protected const int gunSayisi = 30;
        protected enum RezervasyonEnum
        {
            Bos = 0,
            Dolu = 1,
            Temizlik = 2
        };
        protected string kiralanan = "Oda";
        protected RezervasyonEnum[,] rezervasyonDurumu = new RezervasyonEnum[odaSayisi, gunSayisi];

        public void RastegeleDoldur()
        {
            rezervasyonDurumu[0, 0] = RezervasyonEnum.Dolu;
            rezervasyonDurumu[0, 1] = RezervasyonEnum.Temizlik;
            rezervasyonDurumu[0, 5] = RezervasyonEnum.Dolu;
            rezervasyonDurumu[0, 6] = RezervasyonEnum.Temizlik;
            rezervasyonDurumu[1, 7] = RezervasyonEnum.Dolu;
            rezervasyonDurumu[1, 8] = RezervasyonEnum.Temizlik;
            rezervasyonDurumu[2, 9] = RezervasyonEnum.Dolu;
            rezervasyonDurumu[2, 10] = RezervasyonEnum.Temizlik;
            rezervasyonDurumu[5, 15] = RezervasyonEnum.Dolu;
            rezervasyonDurumu[5, 16] = RezervasyonEnum.Temizlik;
            rezervasyonDurumu[8, 20] = RezervasyonEnum.Dolu;
            rezervasyonDurumu[8, 21] = RezervasyonEnum.Temizlik;
            rezervasyonDurumu[0, 27] = RezervasyonEnum.Dolu;
            rezervasyonDurumu[0, 28] = RezervasyonEnum.Temizlik;
            rezervasyonDurumu[9, 29] = RezervasyonEnum.Dolu;
            rezervasyonDurumu[4, 0] = RezervasyonEnum.Temizlik;
            rezervasyonDurumu[5, 1] = RezervasyonEnum.Dolu;
            rezervasyonDurumu[5, 2] = RezervasyonEnum.Temizlik;

        }
        public void IkiTarihArasıRezervasyonBuyukCadir(DateTime date1, DateTime date2)
        {
            Console.WriteLine();
            Console.WriteLine("Iki tarih arasi rezervasyon");
            //DateTime date1 = new DateTime();
            //DateTime date2 = new DateTime();
            try
            {
                Console.Write("Rezervasyon baslangic tarihi (gg/aa/yyyy): ");
                string baslangicTarihi = Console.ReadLine();
                date1 = Convert.ToDateTime(baslangicTarihi);

                Console.Write("Rezervasyon bitis tarihi (gg/aa/yyyy): ");
                string bitisTarihi = Console.ReadLine();
                date2 = Convert.ToDateTime(bitisTarihi);
            }
            catch (FormatException)
            {
                Console.WriteLine("Tarih formatina dikkat ediniz");
            }
            if (date1 < DateTime.Today)
            {
                Console.WriteLine("Baslangic tarih bugunden kucuk olamaz");

            }
            if (date2 < date1)
            {
                Console.WriteLine("Bitis tarihi baslangic tarihinden kucuk olamaz");

            }
            if ((date1 - DateTime.Today).Days >= gunSayisi)
            {
                Console.WriteLine("Baslangic tarihi {0:dd/MM/yyyy} tarihinden buyuk olamaz", DateTime.Today.AddDays(gunSayisi - 1));

            }
            if ((date2 - DateTime.Today).Days >= gunSayisi)
            {
                Console.WriteLine("Bitis tarihi {0:dd/MM/yyyy} tarihinden buyuk olamaz", DateTime.Today.AddDays(gunSayisi - 1));

            }
            int gun1 = (date1 - DateTime.Today).Days;
            int gun2 = (date2 - DateTime.Today).Days;
            bool bosOdaYok = true;
            for (int i = 0; i < odaSayisi; i++)
            {
                bool odaMusait = true;
                for (int j = gun1; j <= gun2; j++)
                {
                    if ((rezervasyonDurumu[i, j] == RezervasyonEnum.Dolu || rezervasyonDurumu[i, j] == RezervasyonEnum.Temizlik || rezervasyonDurumu[i, gun2 + 1] == RezervasyonEnum.Dolu) || (rezervasyonDurumu[i + 1, j] == RezervasyonEnum.Dolu || rezervasyonDurumu[i + 1, j] == RezervasyonEnum.Temizlik || rezervasyonDurumu[i + 1, gun2 + 1] == RezervasyonEnum.Dolu))
                    {
                        odaMusait = false;
                        break;
                    }
                }
                if (odaMusait)
                {
                    for (int j = gun1; j <= gun2; j++)
                    {
                        rezervasyonDurumu[i, j] = RezervasyonEnum.Dolu;
                        rezervasyonDurumu[i + 1, j] = RezervasyonEnum.Dolu;
                    }
                    bosOdaYok = false;
                    rezervasyonDurumu[i, gun2 + 1] = RezervasyonEnum.Temizlik;
                    rezervasyonDurumu[i + 1, gun2 + 1] = RezervasyonEnum.Temizlik;
                    Console.WriteLine("{0} ve {1} numarali  " + kiralanan + " sizin icin ayrildi", i + 1, i + 2);
                    break;
                }
                else if (bosOdaYok)
                    Console.WriteLine("Bu tarih araliginda bos " + kiralanan + " yok");
            }
        }
        public void BuyukCadirHizliRezervasyon(DateTime date1, DateTime date2)
        {
            if (date1 < DateTime.Today)
            {
                Console.WriteLine("Baslangic tarih bugunden kucuk olamaz");

            }
            if (date2 < date1)
            {
                Console.WriteLine("Bitis tarihi baslangic tarihinden kucuk olamaz");

            }
            if ((date1 - DateTime.Today).Days >= gunSayisi)
            {
                Console.WriteLine("Baslangic tarihi {0:dd/MM/yyyy} tarihinden buyuk olamaz", DateTime.Today.AddDays(gunSayisi - 1));

            }
            if ((date2 - DateTime.Today).Days >= gunSayisi)
            {
                Console.WriteLine("Bitis tarihi {0:dd/MM/yyyy} tarihinden buyuk olamaz", DateTime.Today.AddDays(gunSayisi - 1));

            }
            int gun1 = (date1 - DateTime.Today).Days;
            int gun2 = (date2 - DateTime.Today).Days;
            bool bosOdaYok = true;
            for (int i = 0; i < odaSayisi; i++)
            {
                bool odaMusait = true;
                for (int j = gun1; j <= gun2; j++)
                {
                    if ((rezervasyonDurumu[i, j] == RezervasyonEnum.Dolu || rezervasyonDurumu[i, j] == RezervasyonEnum.Temizlik || rezervasyonDurumu[i, gun2 + 1] == RezervasyonEnum.Dolu) || (rezervasyonDurumu[i + 1, j] == RezervasyonEnum.Dolu || rezervasyonDurumu[i + 1, j] == RezervasyonEnum.Temizlik || rezervasyonDurumu[i + 1, gun2 + 1] == RezervasyonEnum.Dolu))
                    {
                        odaMusait = false;
                        break;
                    }
                }
                if (odaMusait)
                {
                    for (int j = gun1; j <= gun2; j++)
                    {
                        rezervasyonDurumu[i, j] = RezervasyonEnum.Dolu;
                        rezervasyonDurumu[i + 1, j] = RezervasyonEnum.Dolu;
                    }
                    bosOdaYok = false;
                    rezervasyonDurumu[i, gun2 + 1] = RezervasyonEnum.Temizlik;
                    rezervasyonDurumu[i + 1, gun2 + 1] = RezervasyonEnum.Temizlik;
                    Console.WriteLine("{0} ve {1} numarali  " + kiralanan + " sizin icin ayrildi", i + 1, i + 2);
                    break;
                }
                else if (bosOdaYok)
                    Console.WriteLine("Bu tarih araliginda bos " + kiralanan + " yok");
            }
        }
        public void KucukCadirHizliRezervasyon(DateTime date1, DateTime date2)
        {
            Console.WriteLine();




            if (date1 < DateTime.Today)
            {
                Console.WriteLine("Baslangic tarih bugunden kucuk olamaz");

            }
            if (date2 < date1)
            {
                Console.WriteLine("Bitis tarihi baslangic tarihinden kucuk olamaz");

            }
            if ((date1 - DateTime.Today).Days >= gunSayisi)
            {
                Console.WriteLine("Baslangic tarihi {0:dd/MM/yyyy} tarihinden buyuk olamaz", DateTime.Today.AddDays(gunSayisi - 1));

            }
            if ((date2 - DateTime.Today).Days >= gunSayisi)
            {
                Console.WriteLine("Bitis tarihi {0:dd/MM/yyyy} tarihinden buyuk olamaz", DateTime.Today.AddDays(gunSayisi - 1));

            }
            int gun1 = (date1 - DateTime.Today).Days;
            int gun2 = (date2 - DateTime.Today).Days;
            bool bosOdaYok = true;
            for (int i = 0; i < odaSayisi; i++)
            {
                bool odaMusait = true;
                for (int j = gun1; j <= gun2; j++)
                {
                    if (rezervasyonDurumu[i, j] == RezervasyonEnum.Dolu || rezervasyonDurumu[i, j] == RezervasyonEnum.Temizlik || rezervasyonDurumu[i, gun2 + 1] == RezervasyonEnum.Dolu)
                    {
                        odaMusait = false;
                        break;
                    }

                }
                if (odaMusait)
                {
                    for (int j = gun1; j <= gun2; j++)
                    {
                        rezervasyonDurumu[i, j] = RezervasyonEnum.Dolu;
                    }


                    bosOdaYok = false;
                    rezervasyonDurumu[i, gun2 + 1] = RezervasyonEnum.Temizlik;
                    Console.WriteLine("{0} numarali oda sizin icin ayrildi", i + 1);
                    break;
                }

                else if (odaMusait)
                    Console.WriteLine("Bu tarih araliginda bos oda yok");

            }


        }
        static void TarihCetveliniYazdir(string onKisim)
        {
            Console.Write(onKisim);
            for (int j = 0; j < gunSayisi; j++)
            {
                Console.Write(" {0:00}", DateTime.Today.AddDays(j).Day);
            }
            Console.WriteLine();
        }
        public void GunBazindaDolulukOranlari()
        {
            TarihCetveliniYazdir("          ");
            Console.Write("Doluluk % ");
            int doluOdaSayisi = 0;
            for (int j = 0; j < gunSayisi; j++)
            {
                doluOdaSayisi = 0;
                for (int i = 0; i < odaSayisi; i++)
                {
                    if (rezervasyonDurumu[i, j] == RezervasyonEnum.Dolu)
                    {
                        doluOdaSayisi++;
                    }

                }
                Console.Write("{0,3}", (int)(100f * doluOdaSayisi / odaSayisi));
            }

        }
        public void BugunkuBosOdalar()
        {
            Console.WriteLine();
            Console.WriteLine("Bugunku bos " + kiralanan);
            bool bosOdaYok = true;
            for (int i = 0; i < odaSayisi; i++)
            {
                if (rezervasyonDurumu[i, 0] != RezervasyonEnum.Dolu)
                {
                    bosOdaYok = false;
                    Console.WriteLine(i + 1);
                }

            }
            if (bosOdaYok)
                Console.WriteLine("Bugun icin bos " + kiralanan + " yok");

        }
        public void AylikDolulukDurumu()
        {
            TarihCetveliniYazdir("");
            for (int i = 0; i < odaSayisi; i++)
            {
                Console.Write(kiralanan + " {0:00}", i + 1);
                for (int j = 0; j < gunSayisi; j++)
                {
                    if (rezervasyonDurumu[i, j] == RezervasyonEnum.Bos)
                        Console.Write(" - ");
                    else if (rezervasyonDurumu[i, j] == RezervasyonEnum.Dolu)
                        Console.Write(" D ");
                    else
                        Console.Write(" T ");
                }
                Console.WriteLine();
            }

        }
        public void BugunHizliRez()
        {
            bool bosOdaYok = true;
            for (int i = 0; i < odaSayisi; i++)
            {
                if ((rezervasyonDurumu[i, 0] == RezervasyonEnum.Bos) && (rezervasyonDurumu[i, 0] != RezervasyonEnum.Temizlik) && (rezervasyonDurumu[i, 1] != RezervasyonEnum.Dolu))
                {
                    bosOdaYok = false;
                    rezervasyonDurumu[i, 0] = RezervasyonEnum.Dolu;
                    rezervasyonDurumu[i, 1] = RezervasyonEnum.Temizlik;
                    Console.WriteLine("{0} numarali " + kiralanan + " sizin icin ayrildi", i + 1);
                    break;
                }
            }
            if (bosOdaYok)
                Console.WriteLine("Bugun icin bos " + kiralanan + " yok");

        }
        public void IkiTarihArasiRezervasyon(DateTime date1, DateTime date2)
        {
            Console.WriteLine();

            //DateTime date1 = new DateTime();
            //DateTime date2 = new DateTime();
            try
            {
                Console.Write("Rezervasyon baslangic tarihi (gg/aa/yyyy): ");
                string baslangicTarihi = Console.ReadLine();
                date1 = Convert.ToDateTime(baslangicTarihi);

                Console.Write("Rezervasyon bitis tarihi (gg/aa/yyyy): ");
                string bitisTarihi = Console.ReadLine();
                date2 = Convert.ToDateTime(bitisTarihi);
            }
            catch (FormatException)
            {
                Console.WriteLine("Tarih formatina dikkat ediniz");
            }


            if (date1 < DateTime.Today)
            {
                Console.WriteLine("Baslangic tarih bugunden kucuk olamaz");

            }
            if (date2 < date1)
            {
                Console.WriteLine("Bitis tarihi baslangic tarihinden kucuk olamaz");

            }
            if ((date1 - DateTime.Today).Days >= gunSayisi)
            {
                Console.WriteLine("Baslangic tarihi {0:dd/MM/yyyy} tarihinden buyuk olamaz", DateTime.Today.AddDays(gunSayisi - 1));

            }
            if ((date2 - DateTime.Today).Days >= gunSayisi)
            {
                Console.WriteLine("Bitis tarihi {0:dd/MM/yyyy} tarihinden buyuk olamaz", DateTime.Today.AddDays(gunSayisi - 1));

            }
            int gun1 = (date1 - DateTime.Today).Days;
            int gun2 = (date2 - DateTime.Today).Days;
            bool bosOdaYok = true;
            for (int i = 0; i < odaSayisi; i++)
            {
                bool odaMusait = true;
                for (int j = gun1; j <= gun2; j++)
                {
                    if (rezervasyonDurumu[i, j] == RezervasyonEnum.Dolu || rezervasyonDurumu[i, j] == RezervasyonEnum.Temizlik || rezervasyonDurumu[i, gun2 + 1] == RezervasyonEnum.Dolu)
                    {
                        odaMusait = false;
                        break;
                    }

                }
                if (odaMusait)
                {
                    for (int j = gun1; j <= gun2; j++)
                    {
                        rezervasyonDurumu[i, j] = RezervasyonEnum.Dolu;
                    }


                    bosOdaYok = false;
                    rezervasyonDurumu[i, gun2 + 1] = RezervasyonEnum.Temizlik;
                    Console.WriteLine("{0} numarali oda sizin icin ayrildi", i + 1);
                    break;
                }

                else if (odaMusait)
                    Console.WriteLine("Bu tarih araliginda bos oda yok");

            }


        }
        public void GunSonuIslemi()
        {
            for (int i = 0; i < odaSayisi; i++)
            {
                for (int j = 0; j < gunSayisi - 1; j++)
                {
                    rezervasyonDurumu[i, j] = rezervasyonDurumu[i, j + 1];

                }
                rezervasyonDurumu[i, gunSayisi - 1] = RezervasyonEnum.Bos;
                if (rezervasyonDurumu[i, gunSayisi - 2] == RezervasyonEnum.Dolu)
                {
                    rezervasyonDurumu[i, gunSayisi - 1] = RezervasyonEnum.Temizlik;
                }

            }


        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Rezervasyon rezervasyon = new Rezervasyon();
            rezervasyon.RastegeleDoldur();
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("      Çadır Yeri Rezervasyonu");
                Console.WriteLine("1-Bugunku bos yerleri goster");
                Console.WriteLine("2-30 gunluk doluluk durumu");
                Console.WriteLine("3-Gün bazında doluluk oranları");
                Console.WriteLine("4-Bugun icin hizli rezervasyon(küçük çadır)");
                Console.WriteLine("5-Iki tarih arasi rezervasyon(küçük çadır)");
                Console.WriteLine("6-Bugun icin hizli rezervasyon(büyük çadır)");
                Console.WriteLine("7-Iki tarih arasi rezervasyon(büyük çadır)");
                Console.WriteLine("8-Gun sonu islemi");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        {
                            Console.WriteLine();
                            Console.WriteLine("Bugunku bos yer yok");
                            rezervasyon.BugunkuBosOdalar();
                            break;
                        }
                    case '2':
                        {
                            Console.WriteLine();
                            Console.WriteLine("30 gunluk doluluk durumu");
                            Console.Write("      ");
                            rezervasyon.AylikDolulukDurumu();
                            break;
                        }
                    case '3':
                        {
                            Console.WriteLine();
                            Console.WriteLine("Gün bazında doluluk oranları");
                            rezervasyon.GunBazindaDolulukOranlari();
                            break;

                        }
                    case '4':
                        {
                            Console.WriteLine();
                            Console.WriteLine("Bugun icin hizli rezervasyon(küçük çadır)");
                            rezervasyon.KucukCadirHizliRezervasyon(DateTime.Today, DateTime.Today);
                            break;

                        }
                    case '5':
                        {
                            Console.WriteLine();
                            Console.WriteLine("Iki tarih arasi rezervasyon(küçük çadır)");

                            rezervasyon.IkiTarihArasiRezervasyon(DateTime.Today, DateTime.Today);
                            break;
                        }
                    case '6':
                        {
                            Console.WriteLine();
                            Console.WriteLine("Bugun icin hizli rezervasyon(büyük çadır)");
                            rezervasyon.BuyukCadirHizliRezervasyon(DateTime.Today, DateTime.Today);
                            break;
                        }
                    case '7':
                        {
                            Console.WriteLine();
                            Console.WriteLine("Iki tarih arasi rezervasyon(büyük çadır)");

                            rezervasyon.IkiTarihArasıRezervasyonBuyukCadir(DateTime.Today, DateTime.Today);
                            break;
                        }
                    case '8':
                        {
                            Console.WriteLine();
                            Console.WriteLine("Gun sonu islemi");
                            rezervasyon.GunSonuIslemi();
                            break;
                        }
                }
            }
        }
    }
}

