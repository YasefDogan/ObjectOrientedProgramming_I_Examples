using System;
using System.Collections.Generic; // List<T> yapısını kullanmak için gerekli

// "Kitap" adında bir sınıf tanımlıyoruz
public class Kitap
{
    // Her kitap nesnesinin sahip olacağı bilgiler (alanlar)
    public string Ad;
    public string Yazar;
    public int Yil;

    // Kitap bilgilerini kullanıcıdan alan metot
    public void BilgiGir()
    {
        Console.WriteLine("\n--- YENİ KİTAP EKLEME ---");

        // Kullanıcıdan kitap adı alınır
        Console.Write("Kitap Adı: ");
        Ad = Console.ReadLine();

        // Kullanıcıdan yazar bilgisi alınır
        Console.Write("Yazar: ");
        Yazar = Console.ReadLine();

        // Kullanıcıdan yayın yılı alınır (Hata kontrolü eklenmiştir)
        Console.Write("Yayın Yılı: ");
        // TryParse ile kullanıcının yanlışlıkla metin girmesi durumunda programın çökmesi engellenir
        if (!int.TryParse(Console.ReadLine(), out Yil))
        {
            Console.WriteLine("Hata: Yayın yılı geçersiz bir sayı formatı! Yıl 0 olarak ayarlandı.");
            Yil = 0; // Geçersiz girişte varsayılan değer
        }
    }

    // Kitap bilgilerini ekrana yazdıran metot
    // Listeleme sırasında sıra numarasını da alacak şekilde güncellenmiştir.
    public void BilgiYazdir(int siraNo)
    {
        // Ekranda kitap detaylarını gösterir (String Interpolation kullanılmıştır)
        Console.WriteLine($"\n--- {siraNo}. Kitap Detayı ---");
        Console.WriteLine($"Ad: {Ad}");
        Console.WriteLine($"Yazar: {Yazar}");
        Console.WriteLine($"Yıl: {Yil}");
    }
}

// Ana program burada başlıyor
class Program
{
    // Main metodu: programın çalıştığı giriş noktasıdır
    static void Main()
    {
        bool devam = true;

        // Kitap nesnelerini saklamak için dinamik olarak büyüyebilen List<Kitap> koleksiyonu oluşturuldu.
        List<Kitap> kütüphane = new List<Kitap>();

        // Kullanıcı çıkmak isteyene kadar menüyü döngüyle gösteriyoruz
        while (devam)
        {
            // Menü ekranı
            Console.WriteLine("\n=========================");
            Console.WriteLine("=== KÜTÜPHANE MENÜSÜ ===");
            Console.WriteLine("=========================");
            Console.WriteLine("1. Yeni Kitap Ekle");
            Console.WriteLine($"2. Tüm Kitapları Görüntüle (Kayıt: {kütüphane.Count})");
            Console.WriteLine("0. Çıkış");
            Console.Write("Seçiminiz: ");

            string secim = Console.ReadLine();

            // Kullanıcının seçimine göre işlem yapılır
            if (secim == "1")
            {
                // Yeni bir Kitap nesnesi oluşturulur
                Kitap yeniKitap = new Kitap();

                // Kullanıcıdan bilgiler alınır
                yeniKitap.BilgiGir();

                // Yeni nesne, kütüphane listesine eklenir.
                kütüphane.Add(yeniKitap);

                Console.WriteLine("✅ Kitap kütüphaneye başarıyla eklendi.");
            }
            else if (secim == "2")
            {
                // Kitapları görüntüleme
                if (kütüphane.Count == 0)
                {
                    Console.WriteLine("\nKütüphanede henüz kayıtlı kitap bulunmamaktadır.");
                }
                else
                {
                    Console.WriteLine("\n=== KAYITLI TÜM KİTAPLAR LİSTESİ ===");
                    // for döngüsü ile listedeki her kitap tek tek dolaşılır
                    for (int i = 0; i < kütüphane.Count; i++)
                    {
                        // Listenin i. elemanındaki kitap nesnesinin BilgiYazdir metodu çağrılır
                        // Sıra numarası (i + 1) olarak gönderilir.
                        kütüphane[i].BilgiYazdir(i + 1);
                    }
                }
            }
            else if (secim == "0")
            {
                // 0 girilirse döngü sona erer ve program kapanır
                devam = false;
                Console.WriteLine("\nProgram sonlandırıldı. Hoşça kalın!");
            }
            else
            {
                // Tanımlı olmayan bir değer girilirse hata mesajı
                Console.WriteLine("Geçersiz seçim! Lütfen 0, 1 veya 2 giriniz.");
            }
        }
    }
}
