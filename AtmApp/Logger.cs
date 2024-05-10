using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmApp
{
    static class Logger
    {
        static string KlasorYolu;
        static string DosyaYolu;

        static Logger()
        {
            KlasorYolu = @"C:\Users\mami_\OneDrive\Masaüstü\C# projeleri";
            DosyaYolu = KlasorYolu + $"\\EOD_Tarih({DateTime.Now:dd.MM.yyy}).txt";
            Kontrol();
        }

        static void Kontrol()
        {
            if (!Directory.Exists(KlasorYolu)) //Klasör yoksa
                Directory.CreateDirectory(KlasorYolu); //Oluştur
            if (!File.Exists(DosyaYolu))    //Dosya yoksa
            {
                File.Create(DosyaYolu).Close(); //oluştur, ardından kapat
            }
        }
        internal static string DosyaOku()
        {
            return File.ReadAllText(DosyaYolu);
        }
        internal static void DosyaYaz(string deger)
        {
            deger = $"\n{DateTime.Now:T} \nYapılan İşlem: {deger} \n";
            File.AppendAllText(DosyaYolu, deger);
        }
    }
}
