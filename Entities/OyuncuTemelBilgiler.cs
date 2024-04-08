namespace backend_api.Entities;

public class OyuncuTemelBilgiler
{

    //public int Id { get; set; }
    public string Adi { get; set; }

    public string Soyadi { get; set; }

    public string Ulke { get; set; }

    public string Il { get; set; }


    public string TelefonNumarasi { get; set; }

    public string EpostaAdresi { get; set; }

    public string Cinsiyet { get; set; }

    public int DogumYili { get; set; }

    //bu daha sonra enum a çevirilebilir(BedenOlcusu)
    public string BedenOlcusu { get; set; }

    public int OyunSeviye { get; set; }


    public bool DahaOnceKatildiMi { get; set; }

}
