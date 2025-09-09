using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.hafta_FinalProje_08._09._2025
{
    internal class Program
    {
        static Dictionary<int, (string ad, double ortalama)> ogrenciler = new Dictionary<int, (string ad, double ortalama)>();

        static int ReadInt(string mesaj)
        {
            while (true)
            {
                Console.Write(mesaj);
                if (int.TryParse(Console.ReadLine(), out int sayi))
                    return sayi;
                Console.WriteLine("⚠ Geçerli bir sayı giriniz!");
            }
        }

        static void OgrenciEkle()
        {
            int ogrNoInt;

            // Öğrenci numarası
            while (true)
            {
                Console.Write("Öğrenci Numarası: ");
                string ogrNo = Console.ReadLine();

                if (int.TryParse(ogrNo, out ogrNoInt))
                {
                    if (ogrenciler.ContainsKey(ogrNoInt))
                    {
                        Console.WriteLine("⚠ Bu numaralı öğrenci zaten kayıtlı!");
                        return;
                    }
                    break; // doğru giriş yapılınca döngüden çık
                }
                else
                {
                    Console.WriteLine("⚠ Geçerli bir numara giriniz!");
                }
            }

            Console.Write("Öğrenci Adı: ");
            string ogrAd = Console.ReadLine();

            // Notlar
            int S1 = ReadInt("1. Sınav Notu: ");
            int S2 = ReadInt("2. Sınav Notu: ");
            int S3 = ReadInt("3. Sınav Notu: ");

            double ogrOrt = (S1 + S2 + S3) / 3.0;

            ogrenciler.Add(ogrNoInt, (ogrAd, ogrOrt));
            Console.WriteLine($" {ogrAd} başarıyla eklendi! Ortalama: {ogrOrt:F2}\n");
            Console.WriteLine();


        }
        static void OgrenciSil()
        {
            Console.Write("Öğrencinin Numarasını Giriniz: ");
            int ogrNo = ReadInt("Öğrenci Numarasını giriniz: ");

            if (ogrenciler.Count == 0)
            {
                Console.WriteLine("Sistemimizde Öğrenci bulunmamaktadır!");
                return;
            }

            if (!ogrenciler.ContainsKey(ogrNo))
            {
                Console.WriteLine("Bu öğrenci sistemimizde kayıtlı değildir!");
                return;
            }
            ogrenciler.Remove(ogrNo);
            Console.WriteLine($"{ogrNo} numaralı öğrenci silinmiştir.");
            Console.WriteLine();
        }
        static void OgrenciAra()
        {
            Console.Write("Öğrencinin Numarasını giriniz: ");
            int ogrNo = Convert.ToInt32(Console.ReadLine());
            if (ogrenciler.Count <= 0)
            {
                Console.WriteLine("Sistemimizde Öğrenci bulunmamaktadır!");
                return;
            }
            else if (!ogrenciler.ContainsKey(ogrNo))
            {
                Console.WriteLine("Bu öğrenci Sistemimizde kayıtlı değildir!");
                return;
            }

            if (ogrenciler.TryGetValue(ogrNo, out var ogr))
            {
                Console.WriteLine($"Aradığınız öğrencinin numarası: {ogrNo} | Adı: {ogr.ad} | Ortalaması: {ogr.ortalama}");
                Console.WriteLine();
            }


        }
        static void Listele()
        {
            if (ogrenciler.Count == 0)
            {
                Console.WriteLine("⚠ Henüz öğrenci eklenmedi.");
                return;
            }

            Console.WriteLine("Öğrenci Listesi:\n");

            foreach (var item in ogrenciler)
            {
                Console.WriteLine($"No: {item.Key} | Adı: {item.Value.ad} | Ortalama: {item.Value.ortalama}");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        static void Ortalama()
        {
            if(ogrenciler.Count <= 1)
            {
                Console.WriteLine("Sıralama yapıcak kadar öğrenci bulunmamaktadır!");
                return;
            }
            Console.WriteLine("1-Büyükten Küçüğe\n2-Küçükten Büyüğe\n");
            int secim = ReadInt("Seçiminiz: ");
            if (secim != 1 && secim != 2)
            {
                Console.WriteLine(" Geçerli bir seçim yapınız!");
                return;
            }
            var sirali = (secim == 1)
            ? ogrenciler.OrderByDescending(x => x.Value.ortalama)
            : ogrenciler.OrderBy(x => x.Value.ortalama);

            foreach (var ogr in sirali)
            {
                Console.WriteLine($"Adı: {ogr.Value.ad} | No: {ogr.Key} | Ortalaması: {ogr.Value.ortalama}");
                Console.WriteLine();
            }
        }
        static void EnDusukEnBuyuk()
        {
            if (ogrenciler.Count == 0)
            {
                Console.WriteLine("⚠ Henüz öğrenci eklenmedi.");
                return;
            }

            var enBuyuk = ogrenciler.OrderByDescending(x => x.Value.ortalama).First();
            Console.WriteLine("En büyük ortalama:");
            Console.WriteLine($"Adı: {enBuyuk.Value.ad} | No: {enBuyuk.Key} | Ortalaması: {enBuyuk.Value.ortalama}");

            var enKucuk = ogrenciler.OrderBy(x => x.Value.ortalama).First();
            Console.WriteLine("En küçük ortalama:");
            Console.WriteLine($"Adı: {enKucuk.Value.ad} | No: {enKucuk.Key} | Ortalaması: {enKucuk.Value.ortalama}");

        }   



        static void Main(string[] args)
        {
            Console.WriteLine("Öğrenci Kayıt sistemine Hoş geldiniz.\n");
            while(true)
            {
                Console.WriteLine("1 - Öğrenci Ekle\n2 - Öğrenci Sil\n3 - Öğrenci Ara\n" +
                "4 - Tümünü Listele\n5 - En yüksek & en düşük ortalamayı bul\n6 - Ortalamaları sırala\n7 - Çıkış");
                Console.WriteLine("\n--------------------------------\n");
                string sec = Console.ReadLine();
                Console.WriteLine("\n--------------------------------\n");

                if (!int.TryParse(sec, out int secInt))
                {
                    Console.WriteLine("Hatalı giriş tekrar deneyin");
                }
                else
                {
                    switch (secInt)
                    {
                        case 1:
                            OgrenciEkle();
                            break;
                        case 2:
                            OgrenciSil(); break;
                        case 3:
                            OgrenciAra(); break;
                        case 4:
                            Listele(); break;
                        case 5:
                            EnDusukEnBuyuk(); break;
                        case 6:
                            Ortalama(); break;
                        case 7:
                            return;
                    }
                }

            }



        }
    }
}
