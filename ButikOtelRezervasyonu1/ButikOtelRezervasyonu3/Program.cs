using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButikOtelRezervasyonu3
{
    class Rezervasyon
    {
        const int odaSayisi = 10;
        const int gunSayisi = 30;
        enum RezervasyonEnum
        {
            Bos = 0,
            Dolu = 1,
            Temizlik = 2
        }
        private RezervasyonEnum[,] rezervasyonDurumu = new RezervasyonEnum[odaSayisi, gunSayisi];

        public void RastgeleDoldur()
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
        public void BugunkuBosOdalar()
        {
            bool bosOdaYok = true;
            for (int i = 0; i < odaSayisi; i++)
            {
                if (rezervasyonDurumu[i, 0] != RezervasyonEnum.Dolu && rezervasyonDurumu[i,0] != RezervasyonEnum.Temizlik)
                {
                    bosOdaYok = false;
                    Console.WriteLine(i + 1);
                }
            }
            if (bosOdaYok)
                Console.WriteLine("Bugun icin bos oda yok");

        }
        public void AylıkDolulukDurumu()
        {
            for (int j = 0; j < gunSayisi; j++)
            {
                Console.Write(" {0:00}", DateTime.Today.AddDays(j).Day);
            }
            Console.WriteLine();
            for (int i = 0; i < odaSayisi; i++)
            {
                Console.Write("Oda {0:00}", i + 1);
                for (int j = 0; j < gunSayisi; j++)
                {
                    if (rezervasyonDurumu[i, j] == RezervasyonEnum.Bos)
                        Console.Write(" - ");
                    else if (rezervasyonDurumu[i, j] == RezervasyonEnum.Dolu)
                    {
                        Console.Write(" D ");
                    }

                    else if(rezervasyonDurumu[i,j]==RezervasyonEnum.Temizlik)
                        Console.Write(" T ");
                }
                Console.WriteLine();
            }
        }
        public void BugunIcınHızlıRezervasyon(DateTime time1, DateTime time2)
        {
            bool bosOdaYok = true;
            time1 = DateTime.Today;
            time2 = DateTime.Today;
            for (int i = 0; i < odaSayisi; i++)
            {
                if (rezervasyonDurumu[i, 0] == RezervasyonEnum.Bos && rezervasyonDurumu[i, 1] == RezervasyonEnum.Bos)
                {
                    bosOdaYok = false;
                    rezervasyonDurumu[i, 0] = RezervasyonEnum.Dolu;
                    rezervasyonDurumu[i, 1] = RezervasyonEnum.Temizlik;
                    Console.WriteLine("{0} numarali oda sizin icin ayrildi", i + 1);
                    break;
                }
            }
            if (bosOdaYok)
                Console.WriteLine("Bugun icin bos oda yok");
           // IkıTarihArasıRezervasyon(DateTime.Today, DateTime.Today);
        }
        public void IkıTarihArasıRezervasyon(DateTime date1, DateTime date2)
        {
            int gun1 = (date1 - DateTime.Today).Days;
            int gun2 = (date2 - DateTime.Today).Days;
            bool bosOdaYok = true;
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
            for (int i = 0; i < odaSayisi; i++)
            {
                bool odaMusait = true;
                for (int j = gun1; j <= gun2; j++)
                {
                    if (rezervasyonDurumu[i, j] == RezervasyonEnum.Dolu )
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
                        rezervasyonDurumu[i, j + 1] = RezervasyonEnum.Temizlik;
                    }
                    bosOdaYok = false;
                    Console.WriteLine("{0} numarali oda sizin icin ayrildi", i + 1);
                    break;
                }
            }
            if (bosOdaYok)
                Console.WriteLine("Bu tarih araliginda bos oda yok");
        }
        public void GunSonuIslemi()
        {
            for (int i = 0; i < odaSayisi; i++)
            {
                for (int j = 0; j < gunSayisi - 1; j++)
                {
                    rezervasyonDurumu[i, j] = rezervasyonDurumu[i, j + 1];
                    //rezervasyonDurumu[i,j]= 
                }
                rezervasyonDurumu[i, gunSayisi - 1] = RezervasyonEnum.Bos;
                if (rezervasyonDurumu[i, gunSayisi - 2] == RezervasyonEnum.Dolu)
                {
                    rezervasyonDurumu[i, gunSayisi - 1] = RezervasyonEnum.Temizlik;
                }
            }
        }


        class Program
        {
            static void Main(string[] args)
            {
                
                Rezervasyon rezervasyon = new Rezervasyon();
                rezervasyon.RastgeleDoldur();
                while (true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("        Butik Otel Rezervasyonu");
                    Console.WriteLine("1-Bugunku bos odalari goster");
                    Console.WriteLine("2-30 gunluk doluluk durumu");
                    Console.WriteLine("3-Bugun icin hizli rezervasyon");
                    Console.WriteLine("4-Iki tarih arasi rezervasyon");
                    Console.WriteLine("5-Gun sonu islemi");


                    switch (Console.ReadKey().KeyChar)
                    {
                        case '1':
                            {
                                Console.WriteLine();
                                Console.WriteLine("Bugunku bos odalar");
                                rezervasyon.BugunkuBosOdalar();
                                break;
                            }
                        case '2':
                            {
                                Console.WriteLine();
                                Console.WriteLine("30 gunluk doluluk durumu");
                                Console.Write("      ");
                                rezervasyon.AylıkDolulukDurumu();
                                break;
                            }
                        case '3':
                            {
                                Console.WriteLine();
                                Console.WriteLine("Bugun icin hizli rezervasyon");
                                rezervasyon.BugunIcınHızlıRezervasyon(DateTime.Today, DateTime.Today);
                                break;
                            }
                        case '4':
                            {

                                DateTime date1 = DateTime.Today;
                                DateTime date2 = DateTime.Today;
                                Console.WriteLine();
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
                                Console.WriteLine("Iki tarih arasi rezervasyon");
                               
                                rezervasyon.IkıTarihArasıRezervasyon(date1 , date2);
                                break;
                            }
                        case '5':
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
}