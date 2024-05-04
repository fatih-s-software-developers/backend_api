using backend_api.Business.Abstracts;
using backend_api.Business.Dto.Requests;
using backend_api.DataAccess.Abstracts;
using backend_api.DataAccess.Concretes;
using backend_api.Entities;

namespace backend_api.Business.Concretes;

public class OyuncuKayitTemelBilgilerManager : IOyuncuKayitTemelBilgilerManager
{

    IOyuncuKayitTemelBilgiler IOyuncuKayitTemelBilgiler;

    public OyuncuKayitTemelBilgilerManager(IOyuncuKayitTemelBilgiler iOyuncuKayitTemelBilgiler)
    {
        IOyuncuKayitTemelBilgiler = iOyuncuKayitTemelBilgiler;
    }

    public void temelkayitekle(TemelKayitEkleRequest temelKayitEkleRequest)
    {
        //temel kayit ekleme ile ilgili iş kuralları
        //yaş kategorisini belirleme
        //yaş kategorisi null check
        YasKategori yasKategori = YasKategoriIdKodla(temelKayitEkleRequest);
        if (yasKategori != null)
        {
            Console.WriteLine("kullanıcının tercihine uygun kategori bulundu");
            //kategori bulundu
            temelKayitEkleRequest.OyuncuTemelBilgiler.YasKategoriId = yasKategori.YasKategoriIdOlustur();
        }
        else
        {
            //kategori bulunamadı
            //burada hata da fırlatabilir iz ama şuanlık temelKayitEkleRequest.OyuncuTemelBilgiler.YasKategoriId değerine "0000000000" değerini atıyoruz
            Console.WriteLine("geliştiriciye not :kullanıcının tercihine uygun kategori bulunamadı bu yüzden temelKayitEkleRequest.OyuncuTemelBilgiler.YasKategoriId değeri 0000000000 olarak ayarlandı ");
            temelKayitEkleRequest.OyuncuTemelBilgiler.YasKategoriId = "0000000000";
        }
        //temel kayıt ekleme
        IOyuncuKayitTemelBilgiler.temelkayitekle(temelKayitEkleRequest.OyuncuTemelBilgiler,temelKayitEkleRequest.MacEs,temelKayitEkleRequest.Ucret,temelKayitEkleRequest.DahaOnceKatildigiLig);
    }
    //YENİ KATEGORİ EKLEMEK İÇİN BURAYI (yasKategorileri listesi) DEĞİŞTİRİN
    private List<YasKategori> yasKategorileri = new List<YasKategori>()
    {
        //Tek Erkekler
        new YasKategori(){YasBaslangic =30,YasBitis = 39,Cinsiyet = "ERKEK" ,CiftTercih = false,KarisikTercih = false },
        new YasKategori(){YasBaslangic = 40,YasBitis = 49,Cinsiyet = "ERKEK" ,CiftTercih = false,KarisikTercih = false},
        new YasKategori(){YasBaslangic = 50,YasBitis = 59,Cinsiyet = "ERKEK",CiftTercih = false ,KarisikTercih = false },
        new YasKategori(){YasBaslangic = 60,YasBitis = 64,Cinsiyet = "ERKEK",CiftTercih = false,KarisikTercih = false},
        new YasKategori(){YasBaslangic = 65,YasBitis = 69,Cinsiyet = "ERKEK",CiftTercih = false,KarisikTercih = false},
        new YasKategori(){YasBaslangic = 70,YasBitis = 74,Cinsiyet = "ERKEK",CiftTercih = false ,KarisikTercih = false},
        new YasKategori(){YasBaslangic = 75,YasBitis = 999,Cinsiyet = "ERKEK" ,CiftTercih = false,KarisikTercih = false },
        //Tek Kadınlar
        new YasKategori(){YasBaslangic = 30,YasBitis = 39,Cinsiyet = "KADIN",CiftTercih = false,KarisikTercih = false},
        new YasKategori(){YasBaslangic = 40,YasBitis = 49 ,Cinsiyet = "KADIN",CiftTercih = false,KarisikTercih = false},
        new YasKategori(){YasBaslangic = 50,YasBitis = 59,Cinsiyet = "KADIN",CiftTercih = false,KarisikTercih =false },
        new YasKategori(){YasBaslangic = 60,YasBitis = 999 ,Cinsiyet = "KADIN",CiftTercih = false,KarisikTercih =false },
        //Çift Erkek
        new YasKategori(){YasBaslangic = 30,YasBitis = 39,Cinsiyet = "ERKEK",CiftTercih = true,KarisikTercih = false},
        new YasKategori(){YasBaslangic = 40,YasBitis = 49,Cinsiyet = "ERKEK",CiftTercih = true ,KarisikTercih = false},
        new YasKategori(){YasBaslangic = 50,YasBitis = 59,Cinsiyet = "ERKEK",CiftTercih = true,KarisikTercih = false},
        new YasKategori(){YasBaslangic = 60,YasBitis = 64,Cinsiyet = "ERKEK",CiftTercih = true,KarisikTercih =false },
        new YasKategori(){YasBaslangic = 65,YasBitis = 69,Cinsiyet = "ERKEK",CiftTercih = true,KarisikTercih =false},
        new YasKategori(){YasBaslangic = 70,YasBitis = 999,Cinsiyet = "ERKEK",CiftTercih = true,KarisikTercih =false },
        //Çift Kadın
        new YasKategori(){YasBaslangic = 30,YasBitis = 49,Cinsiyet = "KADIN",CiftTercih = true,KarisikTercih = false},
        new YasKategori(){YasBaslangic = 50,YasBitis = 59,Cinsiyet = "KADIN",CiftTercih = true,KarisikTercih = false},
        new YasKategori(){YasBaslangic = 60,YasBitis = 999,Cinsiyet = "KADIN",CiftTercih = true,KarisikTercih = false},

        //Karışık
        new YasKategori(){YasBaslangic = 30 ,YasBitis = 49,Cinsiyet = "ERKEK",CiftTercih = false,KarisikTercih = true},
        new YasKategori(){YasBaslangic = 30,YasBitis = 49,Cinsiyet = "KADIN",CiftTercih = false,KarisikTercih = true },
        new YasKategori(){YasBaslangic = 50,YasBitis = 999,Cinsiyet = "ERKEK",CiftTercih = false,KarisikTercih =true },
        new YasKategori(){YasBaslangic = 50,YasBitis = 999,Cinsiyet = "KADIN",CiftTercih = false,KarisikTercih =true },
    };
    private YasKategori? YasKategoriIdKodla(TemelKayitEkleRequest temelKayitEkleRequest)
    {
        int oyuncuYas = yasHesapla(temelKayitEkleRequest.OyuncuTemelBilgiler.DogumYili);
        //linq sorgusuna çevirilebilir
        foreach (YasKategori kategori in yasKategorileri)
        {
            if ((kategori.YasBaslangic <= oyuncuYas) && (oyuncuYas <= kategori.YasBitis) && (kategori.Cinsiyet == temelKayitEkleRequest.OyuncuTemelBilgiler.Cinsiyet) && (kategori.CiftTercih == temelKayitEkleRequest.MacEs.CiftMacTercihi) && (kategori.KarisikTercih == temelKayitEkleRequest.MacEs.KarisikMacTercihi))
            {
                return kategori;
            }
        }
        return null;
    }

    private int yasHesapla(int dogumYili)
    {
        int guncelYil = DateTime.Now.Year;
        return guncelYil - dogumYili;
    }

}
