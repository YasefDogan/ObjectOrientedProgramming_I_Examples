using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sesliHarfSayimi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Bir kelime girin: "); // Kullanıcıdan bir kelime istiyoruz
            string kelime = Console.ReadLine();  // Konsoldan girilen değeri okuyoruz

            // Orijinal kelimeyi saklamak için ayrı bir değişken tutuyoruz
            string originalkelime = kelime;

            // Trim → baştaki ve sondaki boşlukları temizler
            kelime = kelime.Trim();
            Console.WriteLine(kelime);

            // Replace(" ", "") → tüm boşlukları kaldırır
            kelime = kelime.Replace(" ", "");
            Console.WriteLine(kelime);

            // ToLower → tüm karakterleri küçük harfe çevirir
            // (Böylece sesli harf kontrolünde büyük/küçük farkı ortadan kalkar)
            kelime = kelime.ToLower();
            Console.WriteLine(kelime);

            // Sesli harf sayısını tutacak sayaç
            int sesliHarf = 0;

            // Kelimenin tüm karakterlerini teker teker dolaş
            foreach (char c in kelime)
 {
     if ("aeıioöuü".Contains(c)) // Türkçe sesli harfler dizisini kontrol et
         sesliHarf++; // Eğer karakter bu string içinde varsa sesliHarf++ yapılır
 }


            // Sonucu yazdır
            Console.WriteLine(originalkelime + " kelimesindeki sesli harf sayısı: " + sesliHarf);
        }

    }
    
}
