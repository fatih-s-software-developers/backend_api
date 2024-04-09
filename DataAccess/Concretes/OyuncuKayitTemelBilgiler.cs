using backend_api.Business.Dto.Requests;
using backend_api.DataAccess.Abstracts;
using backend_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend_api.DataAccess.Concretes;



//Database Model Class
public class OyuncuTemelBilgilerTablo
{
    public int Id { get; set; }
    public string Adi { get; set; }

    public string Soyadi { get; set; }

    public string Ulke { get; set; }

    public string Il { get; set; }

    public string TelefonNumarasi { get; set; }

    public string EpostaAdresi { get; set; }

    public string Cinsiyet { get; set; }

    public int DogumYili { get; set; }
    public string BedenOlcusu { get; set; }

    public int OyunSeviye { get; set; }

    public bool DahaOnceKatildiMi { get; set; }
    // ilişki tanımlamaları yapılacak

    //MacEsTablo ilişki tanımlaması
    public MacEsTablo MacEsTablo { get; set; }

    //UcretTablo ilişki tanımlaması
    public UcretTablo UcretTablo { get; set; }


    //DahaOnceKatildigiLigTablo ilişki tanımlaması
    public DahaOnceKatildigiLigTablo DahaOnceKatildigiLigTablo { get; set; }


    //özel unic id tanımlaması
    public int Oyuncu_Unic_Id { get; set; }

}

//Database Model Class
public class MacEsTablo
{

    public OyuncuTemelBilgilerTablo oyuncuTemelBilgilerTablo { get; set; }

    public int oyuncuTemelBilgilerTabloId { get; set; }
    public int Id { get; set; }
    public bool CiftMacTercihi { get; set; }

    public string CiftEsAdi { get; set; }

    public bool KarisikMacTercihi { get; set; }

    public string KarisikEsAdi { get; set; }

}

//Database Model Class
public class UcretTablo
{
    public OyuncuTemelBilgilerTablo oyuncuTemelBilgilerTablo { get; set; }

    public int oyuncuTemelBilgilerTabloId { get; set; }

    public int Id { get; set; }

    public bool UcretOdemesiYapildiMi { get; set; }

    public string OdemeYapanKisininAdiSoyadi { get; set; }
    public DateTime OdemeYapilmasiPlanlananTarih { get; set; }


}
//Database Model Class
public class DahaOnceKatildigiLigTablo
{
    public OyuncuTemelBilgilerTablo oyuncuTemelBilgilerTablo { get; set; }

    public int oyuncuTemelBilgilerTabloId { get; set; }

    public int Id { get; set; }

    public bool UlusalLiglerdeOynadiMi { get; set; }

    public string LigAdi { get; set; }
}



//DbContext Class

public class OyuncuKayitDbContext:DbContext
{
    public DbSet<OyuncuTemelBilgilerTablo> OyuncuTemelBilgiler { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        IConfigurationRoot Configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        options.UseNpgsql(Configuration.GetConnectionString("PostgreDbConnection"));
    }
}


public class OyuncuKayitTemelBilgiler : IOyuncuKayitTemelBilgiler
{

    public void temelkayitekle(OyuncuTemelBilgilerTemelKayitEkleRequest oyuncuTemelBilgiler, MacEsTemelKayitEkleRequest macEs, UcretTemelKayitEkleRequest ucret, DahaOnceKatildigiLigUcretTemelKayitEkleRequest dahaOnceKatildigiLig)
    {
        //mapping işlemleri
        //MacEs object mapping
        Console.WriteLine("mapping işlemi başladı");
        MacEsTablo macEsTablo = new MacEsTablo()
        {
          CiftMacTercihi = macEs.CiftMacTercihi,
          CiftEsAdi = macEs.CiftEsAdi,
          KarisikMacTercihi = macEs.KarisikMacTercihi,
          KarisikEsAdi = macEs.KarisikEsAdi,
        };
        // Ucret Object mapping
        UcretTablo ucretTablo = new UcretTablo() {
            UcretOdemesiYapildiMi = ucret.UcretOdemesiYapildiMi,
            OdemeYapanKisininAdiSoyadi = ucret.OdemeYapanKisininAdiSoyadi,
            OdemeYapilmasiPlanlananTarih = ucret.OdemeYapilmasiPlanlananTarih,
        };

        //DahaOnceKatildigiLig Object mapping
        DahaOnceKatildigiLigTablo dahaOnceKatildigiLigTablo = new DahaOnceKatildigiLigTablo()
        {
            UlusalLiglerdeOynadiMi = dahaOnceKatildigiLig.UlusalLiglerdeOynadiMi,
            LigAdi = dahaOnceKatildigiLig.LigAdi,
        };
        //OyuncuTemelBilgiler Object mapping
        OyuncuTemelBilgilerTablo oyuncuTemelBilgilerTablo = new OyuncuTemelBilgilerTablo() 
        {
            //temel bilgiler
            Adi = oyuncuTemelBilgiler.Adi,
            Soyadi = oyuncuTemelBilgiler.Soyadi,
            Ulke = oyuncuTemelBilgiler.Ulke,
            Il = oyuncuTemelBilgiler.Il,
            TelefonNumarasi = oyuncuTemelBilgiler.TelefonNumarasi,
            EpostaAdresi = oyuncuTemelBilgiler.EpostaAdresi,
            Cinsiyet = oyuncuTemelBilgiler.Cinsiyet,
            DogumYili = oyuncuTemelBilgiler.DogumYili,
            BedenOlcusu = oyuncuTemelBilgiler.BedenOlcusu,
            OyunSeviye = oyuncuTemelBilgiler.OyunSeviye,
            DahaOnceKatildiMi = oyuncuTemelBilgiler.DahaOnceKatildiMi,
            //ilişkiler
            MacEsTablo = macEsTablo,
            UcretTablo = ucretTablo,
            DahaOnceKatildigiLigTablo = dahaOnceKatildigiLigTablo
        };
        Console.WriteLine("mapping işlemi bitti");
        //veritabanı kayıt işlemleri
        Console.WriteLine("veritabanı kayıt işlemi başladı");
        Console.WriteLine("sorun bulunamadı");
        OyuncuKayitDbContext oyuncuKayitDbContext = new OyuncuKayitDbContext();
        oyuncuKayitDbContext.OyuncuTemelBilgiler.Add(oyuncuTemelBilgilerTablo);
        oyuncuKayitDbContext.SaveChanges();
        Console.WriteLine("veritabanı kayıt işlemi bitti");
    }
}
