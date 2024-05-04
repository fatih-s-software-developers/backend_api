namespace backend_api.Entities;

public class YasKategori
{
    public int YasBaslangic { get; set; }

    public int YasBitis { get; set; }

    public string Cinsiyet { get; set; }

    public bool CiftTercih { get; set; }

    public bool KarisikTercih { get; set; } 


    public string YasKategoriOlustur()
    {

        //yasBaslangicHanesi

        string yasBaslangicHanesi = yasHaneOlustur(YasBaslangic);

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

        //tercihHanesi

        /*
         01=>tek,
         02=> çift
         03 => karışık
         */
        string tercihHanesi = "";
        // karışık,çift,tek maç hanesi belirleme
        if (CiftTercih || KarisikTercih)
        {
            //burada kullanıcı bize hem çift hem karışık tercih ederek gelebilir bu ihtimali daha sonra düşün
            //karışık veya çift maç seçilmiş
            if (CiftTercih)
            {
                //çift seçilmiş
                tercihHanesi = "02";
            }
            else if (KarisikTercih)
            {
                //karışık seçilmiş
                tercihHanesi = "03";
            }
        }
        else
        {
            //karışık veya çift maç seçilmemiş (tek maç seçilmiş)
            tercihHanesi = "01";
        }

        //cinsiyetHanesi
        /*
         01=> erkek
         02 => kadın
         */
        string cinsiyetHanesi = "";
        //cinsiyet hanesi belirleme
        if (Cinsiyet == "ERKEK")
        {
            //cinsiyet erkek
            cinsiyetHanesi = "01";
        }
        else if (Cinsiyet == "KADIN")
        {
            //cinsiyet kadın
            cinsiyetHanesi = "02";
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
        return $"{yasBaslangicHanesi} {tercihHanesi} {cinsiyetHanesi} {yasBitisHanesi}";
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
