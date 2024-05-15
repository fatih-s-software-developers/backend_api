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
			Console.WriteLine($"kullanıcının({temelKayitEkleRequest.OyuncuTemelBilgiler.Adi} {temelKayitEkleRequest.OyuncuTemelBilgiler.Soyadi}) tercihine uygun kategori bulundu");
			//kategori bulundu
			temelKayitEkleRequest.OyuncuTemelBilgiler.YasKategoriId = yasKategori.YasKategoriIdOlustur();
		}
		else
		{
			//kategori bulunamadı
			//burada hata da fırlatabilir iz ama şuanlık temelKayitEkleRequest.OyuncuTemelBilgiler.YasKategoriId değerine "0000000000" değerini atıyoruz
			Console.WriteLine($"geliştiriciye not :kullanıcının({temelKayitEkleRequest.OyuncuTemelBilgiler.Adi} {temelKayitEkleRequest.OyuncuTemelBilgiler.Soyadi}) tercihine uygun kategori bulunamadı bu yüzden temelKayitEkleRequest.OyuncuTemelBilgiler.YasKategoriId değeri 0000000000 olarak ayarlandı ");
			temelKayitEkleRequest.OyuncuTemelBilgiler.YasKategoriId = "0000000000";
		}
		//temel kayıt ekleme
		Console.WriteLine($" {temelKayitEkleRequest.OyuncuTemelBilgiler.Adi} {temelKayitEkleRequest.OyuncuTemelBilgiler.Soyadi} adlı kişinin kaydı business katmanına geldi \ndataacess katmanına transferi başlatılıyor");
		IOyuncuKayitTemelBilgiler.temelkayitekle(temelKayitEkleRequest.OyuncuTemelBilgiler, temelKayitEkleRequest.MacEs, temelKayitEkleRequest.Ucret, temelKayitEkleRequest.DahaOnceKatildigiLig);
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
	public YasKategori? YasKategoriIdKodla(TemelKayitEkleRequest temelKayitEkleRequest)
	{
		YasKategori resultYasKategori = new YasKategori();
		//continue from here
		int oyuncuYas = yasHesapla(temelKayitEkleRequest.OyuncuTemelBilgiler.DogumYili);
		//linq sorgusuna çevirilebilir
		//şuan aklıma şöyle bir çözüm geldi kategorideki  değerlere uyan kategorileri bir listeye ekle
		List<int> yasBaslangicDegerleri = new List<int>();
		List<int> yasBitisDegerleri = new List<int>();
		foreach (YasKategori kategori in yasKategorileri)
		{

			//&& (kategori.CiftTercih == temelKayitEkleRequest.MacEs.CiftMacTercihi) && (kategori.KarisikTercih == temelKayitEkleRequest.MacEs.KarisikMacTercihi)
			//&& ((kategori.CiftTercih == temelKayitEkleRequest.MacEs.CiftMacTercihi) || (kategori.KarisikTercih == temelKayitEkleRequest.MacEs.KarisikMacTercihi))
			if ((kategori.YasBaslangic <= oyuncuYas) && (oyuncuYas <= kategori.YasBitis) && (kategori.Cinsiyet == temelKayitEkleRequest.OyuncuTemelBilgiler.Cinsiyet))
			{
				yasBaslangicDegerleri.Add(kategori.YasBaslangic);
				yasBitisDegerleri.Add(kategori.YasBitis);
			}
		}
		//yukarıdaki satırda yapılan iş şu:yarışmacının bilgilerine göre hangi kategorilere girebileceğini buluyoruz.daha sonra buradaki kategorileri bir listeye ekliyoruz
		// listeye eklememizdek  amaç yaş değerlerinin başlangıç ve bitiş değerini belirlemek
		if (yasBaslangicDegerleri.Count > 0 || yasBitisDegerleri.Count > 0 )
		{
			Console.WriteLine($"=====================================================================================================");
			Console.WriteLine("şarta uyan değer bulundu");
			Console.WriteLine($"{yasBaslangicDegerleri.Count} tane şarta uyan kategori var");

		}
		/*
		 * ÇÖZÜLDÜ
		 * KATEGORİDEKİ Yaş Değerlerinin uyuşmaması
		 * şimdi elimizde şarta uyan kategoriler var
		   bu kategorileri konsola bastırdığımızda şöyle bir sıkıntı farkettim
		   küçük yaş kategorilerinde(ör:doğum yılı 1990 olanlar)(30 39 yaş grubu) bastırdığımızda şöyle bir çıktı elde ediyoruz.
		   yaş başlangıç 30 | yaş bitiş 39 | cinsiyet ERKEK | Çift Maç True | Karışık Maç False
		   yaş başlangıç 30 | yaş bitiş 49 | cinsiyet ERKEK | Çift Maç False | Karışık Maç True
		   çıktıdaki yaş değerleri uyuşuyor.
		   
		   ancak büyük yaş kategorilerinde(ör:doğum yılı 1958 olanlar)(65 69 yaş grubu) bastırdığımızda şöyle bir çıktı elde ediyoruz.
		   yaş başlangıç 65 | yaş bitiş 69 | cinsiyet ERKEK | Çift Maç True | Karışık Maç False
		   yaş başlangıç 50 | yaş bitiş 999 | cinsiyet ERKEK | Çift Maç False | Karışık Maç True
		   ve görüldüğü üzere bir kategorinin yaş başlangıç ile diğer kategorinin yaş başlangıç değeri uyuşmuyor
	       * burada ne yapmam gerekiyor?
	       (aklıma gelen çözüm 
			bir kategorinin yaş değerlerini kullanmak 
			ama öyle olduğu zaman ileride kategorilere göre gruplandırıken sıkıntı yaşayacağız)(küçük değerleri al hoca öyle dedi)
		 */
		resultYasKategori.YasBaslangic = yasBaslangicDegerleri.Min();
		resultYasKategori.YasBitis = yasBitisDegerleri.Min();
		//Console.WriteLine($"yaş başlangıç değeri {resultYasKategori.YasBaslangic} | yaş bitiş değeri {resultYasKategori.YasBitis} olarak belirlendi");
		resultYasKategori.Cinsiyet = temelKayitEkleRequest.OyuncuTemelBilgiler.Cinsiyet;
		//Console.WriteLine($"Cinsiyet {resultYasKategori.Cinsiyet} olarak belirlendi");
		
		resultYasKategori.CiftTercih = temelKayitEkleRequest.MacEs.CiftMacTercihi;
		resultYasKategori.KarisikTercih = temelKayitEkleRequest.MacEs.KarisikMacTercihi;
		Console.WriteLine($"Çift Maç tercihi {resultYasKategori.CiftTercih} | Karışık Maç Tercihi {resultYasKategori.KarisikTercih}  olarak belirlendi");
		Console.WriteLine("=====================================================================================================");
		return resultYasKategori;
	}

	private int yasHesapla(int dogumYili)
	{
		int guncelYil = DateTime.Now.Year;
		return guncelYil - dogumYili;
	}

	public void TopluTemelKayitEkle(List<TemelKayitEkleRequest> kayitlar)
	{
		Console.WriteLine("toplu kayıt ekleme fonksiyonu çalıştırıldı");
		Console.WriteLine("güvenlik sebebi ile veritabanı kaydı kapatıldı");
		foreach (TemelKayitEkleRequest kayit in kayitlar)
		{
			this.temelkayitekle(kayit);
		}
	}

}
