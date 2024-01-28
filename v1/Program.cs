using System.Net.Mime;
using System.Reflection;
using System;
using System.Windows;
using TextCopy;

startLine:
Kutuphane islemler = new Kutuphane();

#region StartQues

Console.Clear();
Console.WriteLine("====================================================================================================");
Console.WriteLine("Yapmak istediğiniz işlem nedir? \n (harften sayıya çevirme:1) \n (sayıdan harfe çevirme: 2) \n (çıkış: 0)");
#endregion

#region Static

string sonuc= Console.ReadLine();
if (sonuc == "1")
{
    devamke(1);
}
else if (sonuc == "2")
{
    devamke(2);
}
else if (sonuc == "0")
{
    Environment.Exit(0);
}
else
{
    goto startLine;
}
#endregion

#region Cont

void devamke(int index)
{
    Console.Clear();
    if (index == 1)
    {
        Console.WriteLine("çevirmek istediğiniz metin: ");
        string text = Console.ReadLine();
        
        islemler.harf2sayi(text);
    }
    else if (index == 2)
    {
        Console.WriteLine("Çevirmek istediğiniz sayısal değer: ");
        string number = Console.ReadLine();
        
        islemler.sayi2harf(number);
    }
}
if (islemler.denetim == true)
{
    Console.ReadKey();
}
goto startLine;
#endregion
//============================================================================================================================================

public class Kutuphane()
{
    #region Dynamic

        public Boolean denetim = false;
        string harfler = "a b c ç d e f g ğ h ı i j k l m n o ö p r s ş t u ü v y z 0 1 2 3 4 5 6 7 8 9 + - / * ^ (   )"; // Harfleri bir string içinde tanımladım
        string[] sayilar = {"01", "02", "03", "04", "05", "06", "07", "08", "09", "11", "12", "13", "14", "15", "16", "17", "18", "19", "21", "22", "23", "24", "25", "26", "27", "28", "29", "31", "32", "35", "36", "37", "38", "39", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "99", "52"}; // Sayıları bir string dizisi içinde tanımladım
        Dictionary<char, string> harfSayi = new Dictionary<char, string>(); // Harf ve sayı karşılıklarını tutacak bir sözlük oluşturdum
    #endregion

    #region Static
        void DICKtionary()
        {
            for (int i = 0; i < harfler.Length; i += 2) // Harfler stringindeki her harf için
            {
                harfSayi.Add(harfler[i], sayilar[i / 2]); // Sözlüğe harf ve sayı karşılığını ekledim
            }    
        }
    
        public void harf2sayi(string kelimem)
        {
            DICKtionary();
            // Harfleri sayılara çeviren kod
            string kelime = kelimem; // Çevirmek istediğim kelime
            string sonuc = ""; // Çevrilen sayıları tutacak bir string
            foreach (char harf in kelime) // Kelimedeki her harf için
            {
                sonuc += harfSayi[harf]; // Sözlükten sayı karşılığını bulup sonuca ekledim
            }
            Console.WriteLine($"Result: {sonuc}"); // Sonucu yazdırdım
            CopySystem(sonuc);
        }

        public void sayi2harf(string sayim)
        {
            DICKtionary();
            // Sayıları harflere çeviren kod
            string sayi = sayim; // Çevirmek istediğim sayı
            string sonuc2 = ""; // Çevrilen harfleri tutacak bir string
            for (int i = 0; i < sayi.Length; i += 2) // Sayıdaki her iki basamak için
            {
                string basamak = sayi.Substring(i, 2); // Sayının iki basamağını aldım
                char harf = harfSayi.FirstOrDefault(x => x.Value == basamak).Key; // Sözlükten harf karşılığını buldum
                sonuc2 += harf; // Sonuca ekledim
            }
            Console.WriteLine($"Result: {sonuc2}"); // Sonucu yazdırdım
            CopySystem(sonuc2);
        }
    
        void CopySystem(string text)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("'C' to Copy");
            ConsoleKeyInfo cont = Console.ReadKey();
            if (cont.Key == ConsoleKey.C)
            {
                Console.Clear();
                ClipboardService.SetText(text);
                Console.WriteLine("Result copied.");
                denetim = true;
            }
        }
    #endregion
}