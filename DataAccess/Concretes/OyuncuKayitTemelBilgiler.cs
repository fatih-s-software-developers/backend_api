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
    public int MacEsTabloId { get; set; }

    //UcretTablo ilişki tanımlaması
    public UcretTablo UcretTablo { get; set; }
    public int UcretTabloId { get; set; }


    //DahaOnceKatildigiLigTablo ilişki tanımlaması
    public DahaOnceKatildigiLigTablo DahaOnceKatildigiLigTablo { get; set; }

    public int DahaOnceKatildigiLigTabloId { get; set; }

    //özel unic id tanımlaması
    public int Oyuncu_Unic_Id { get; set; }

}

//Database Model Class
public class MacEsTablo
{

    public OyuncuTemelBilgilerTablo oyuncuTemelBilgilerTablo { get; set; }
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

    public int Id { get; set; }

    public bool UcretOdemesiYapildiMi { get; set; }

    public string OdemeYapanKisininAdiSoyadi { get; set; }
    public DateTime OdemeYapilmasiPlanlananTarih { get; set; }


}
//Database Model Class
public class DahaOnceKatildigiLigTablo
{
    public OyuncuTemelBilgilerTablo oyuncuTemelBilgilerTablo { get; set; }

    public int Id { get; set; }

    public bool UlusalLiglerdeOynadiMi { get; set; }

    public string LigAdi { get; set; }
}





//DbContext Class

public class OyuncuKayitTemelBilgilerDbContext:DbContext
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
    public void DahaOnceKatildigiLigEkle(DahaOnceKatildigiLig dahaOnceKatildigiLig)
    {

    }

    public void macEsEkle(MacEs macEs)
    {

    }

    public void temelkayitekle(OyuncuTemelBilgiler oyuncuTemelBilgiler)
    {

    }

    public void ucretEkle(Ucret ucret)
    {

    }
}
