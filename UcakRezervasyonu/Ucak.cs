using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcakRezervasyonu
{
    internal class Ucak
    {
        int UcakID { get; set; }
        int KoltukSayisi { get; set; }

        public string Ad;
        public char Cinsiyet;
        public string Tarih;
        public string Lokasyon;

        public Ucak(string AdX, char CinsiyetX)
        {
            Ad = AdX;
            Cinsiyet = CinsiyetX;
            UcakID = 1;
            KoltukSayisi = 90;

            Console.WriteLine("\nEtkin uçuşlar: ");
            LokasyonOlustur lokasyonOlustur = new LokasyonOlustur();

            for (int i = 0; i < lokasyonOlustur.Lokasyonlar.Count; i++)
            {
                Console.WriteLine("{0} - " + lokasyonOlustur.Lokasyonlar[i], i+1);
            }

            bool lokasyonok = false;

            while(lokasyonok == false)
            {
                Console.Write("\nLokasyonunuzu seçiniz: ");
                int lokasyonSecim = Convert.ToInt32(Console.ReadLine());

                if(lokasyonSecim > 0 && lokasyonSecim <= lokasyonOlustur.Lokasyonlar.Count)
                {
                    Lokasyon = lokasyonOlustur.Lokasyonlar[lokasyonSecim-1];
                    lokasyonok = true;
                }
            }

            Console.Write("\nTarih seçiniz (Gün/Ay/Yıl): ");
            Tarih = Console.ReadLine();

            Rezervasyon rezervasyon = new Rezervasyon();
        }

        public string Tamamla()
        {
            string tempReturn = "";
            Rezervasyon rezervasyon = new Rezervasyon();

            if(Cinsiyet == 'E')
                tempReturn= "\nSayın " + Ad + " bey; \nUçak numaranız: " + UcakID + "\nUçuş tarihiniz: " + Tarih + "\nLokasyonunuz: " + Lokasyon  + "\nBilet ücretiniz: " + rezervasyon.Fiyat + " TL\n";
            else if(Cinsiyet == 'K')
                tempReturn = "\nSayın " + Ad + " hanım; \nUçak numaranız: " + UcakID + "\nUçuş tarihiniz: " + Tarih + "\nLokasyonunuz: " + Lokasyon + "\nBilet ücretiniz: " + rezervasyon.Fiyat + " TL\n";

            return tempReturn;
        }
    }
}
