namespace backend_api.Entities;

public class YasKategori
{

	public int YasBaslangic { get; set; }

    public int YasBitis { get; set; }

    public string Cinsiyet { get; set; }

    public bool CiftTercih { get; set; }

    public bool KarisikTercih { get; set; } 


    public string YasKategoriIdOlustur()
    {
        Console.WriteLine("id verme kısmına gelindi");

        //yasBaslangicHanesi

        string yasBaslangicHanesi = yasHaneOlustur(YasBaslangic);
        Console.WriteLine("yaş başlangıç değeri verildi");
        //string yasBaslangicHanesi = "";
        //int yasBaslangicHanesiUzunluk = YasBaslangic.ToString().Length;
        ////yaş 1 karekterli ise başına 00 konur
        //if (yasBaslangicHanesiUzunluk == 1)
        //{
        //    yasBaslangicHanesi = $"00{YasBaslangic}";
        //}

        ////yaş 2 karekterli ise başına 0 konur
        //else if (yasBaslangicHanesiUzunluk == 2)
        //{
        //    yasBaslangicHanesi = $"0{YasBaslangic}";
        //}
        ////yaş 3 karekterli ise başına birşey konmaz

        //tercihHaneleri
        //tek erkek
        string tekErkekTercihHanesi =  "00";
        //TODO hocaya sor : tek {cinsiyet} otomatik olarak seçilecek mi?
        //ternary operatöre çevirilebilir
        if ((Cinsiyet == "ERKEK"))
        {
            tekErkekTercihHanesi = "MS";
        }

		//tek kadın
		string tekKadinTercihHanesi =  "00";
        //ternary operatöre çevirilebilir
		if ((Cinsiyet == "KADIN"))
		{
			tekKadinTercihHanesi = "WS";
		}
        //daha düzgün bir kod yazılabilir(ör:cifttercih true ise ikinci karakterin "D" yapılması)
		//çift erkek
		string ciftErkekTercihHanesi = "00";
        if ((Cinsiyet == "ERKEK") && (CiftTercih))
        {
            ciftErkekTercihHanesi = "MD";
        }
		//çift kadın
		string ciftKadinTercihHanesi = "00";
        if ((Cinsiyet == "KADIN") && (CiftTercih))
        {
            ciftKadinTercihHanesi = "WD";
        }
		//karışık
		string KarisikTercihHanesi = "00";

        if (KarisikTercih)
        {
			KarisikTercihHanesi = "XD";
        }

        // yasBitisHanesi
        string yasBitisHanesi = yasHaneOlustur(YasBitis);
		//string yasBitisHanesi = "";
		//int yasBitisHanesiUzunluk = YasBitis.ToString().Length;
		////yaş 1 karekterli ise başına 00 konur
		//if (yasBitisHanesiUzunluk == 1)
		//{
		//    yasBitisHanesi = $"00{YasBitis}";
		//}

		////yaş 2 karekterli ise başına 0 konur
		//else if (yasBitisHanesiUzunluk == 2)
		//{
		//    yasBitisHanesi = $"0{YasBitis}";
		//}
		////yaş 3 karekterli ise başına birşey konmaz
		return $"{yasBaslangicHanesi} {tekErkekTercihHanesi} {tekKadinTercihHanesi} {ciftErkekTercihHanesi} {ciftKadinTercihHanesi} {KarisikTercihHanesi} {yasBitisHanesi}";
    }

    private string yasHaneOlustur(int yas){
        //yasBaslangicHanesi
        string yasHanesi = "";
        int yasHanesiUzunluk = yas.ToString().Length;
        //yaş 1 karekterli ise başına 00 konur
        if (yasHanesiUzunluk == 1)
        {
            yasHanesi = $"00{yas}";
        }

        //yaş 2 karekterli ise başına 0 konur
        else if (yasHanesiUzunluk == 2)
        {
            yasHanesi = $"0{yas}";
        }
        //yaş 3 karekterli ise başına birşey konmaz
        else if(yasHanesiUzunluk == 3)
        {
            yasHanesi = $"{yas}";
        }
        return yasHanesi;
    }


}
