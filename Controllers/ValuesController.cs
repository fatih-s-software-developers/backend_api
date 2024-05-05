using backend_api.Business.Abstracts;
using backend_api.Business.Dto.Requests;
using backend_api.DataAccess.Concretes;
using backend_api.Entities;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_api.Properties
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IStudentManager _studentManager;

        public ValuesController(IStudentManager studentManager, IOyuncuKayitTemelBilgilerManager oyuncuKayitTemelBilgilerManager)
        {
            _studentManager = studentManager;
        }

        string dataone = "Veri";

        string[] datatwo = new string[] {
            "data1",
            "data2",
            "data3",
            "data4",
            "data5",
            "data6",
            "data7"
        };

        //List<string> datatwo = new List<string>()
        //{
        //    "data1",
        //    "data2",
        //    "data3"
        //};

        [HttpGet("dataone")]
        public IActionResult GetDataOne()
        {
            return Ok(dataone);
        }

        [HttpGet("datatwo")]
        public IActionResult GetDataTwo()
        {
            return Ok(datatwo);
        }
        [HttpGet("getstudents")]
        public IActionResult GetStudents()
        {
            return Ok(_studentManager.getAll());
        }
        [HttpPost("addstudent")]
        public IActionResult AddStudent(AddStudentRequest addStudentRequest)
        {
            _studentManager.add(addStudentRequest);
            return Ok();
        }
        [HttpPost("KayitTest")]
        public IActionResult Ekle(TemelKayitEkleRequest temelKayitEkleRequest)
        {
            /*
            Console.WriteLine("objeler oluşturuluyor");
            MacEs macEs = new MacEs()
            {
                CiftMacTercihi = true,
                CiftEsAdi = "Samet",
                KarisikMacTercihi = true,
                KarisikEsAdi = "Asiye",
            };
            Ucret ucret = new Ucret()
            {
                OdemeYapanKisininAdiSoyadi = "Fatih KILINÇ",
                UcretOdemesiYapildiMi = true,
                OdemeYapilmasiPlanlananTarih = DateTime.Now.ToUniversalTime(),
            };
            DahaOnceKatildigiLig dahaOnceKatildigiLig = new DahaOnceKatildigiLig()
            {
                UlusalLiglerdeOynadiMi = true,
                LigAdi = "Süper Lig",
            };
            OyuncuTemelBilgiler oyuncuTemelBilgiler = new OyuncuTemelBilgiler
            {
                Adi = "Fatih",
                Soyadi = "KILINÇ",
                Ulke = "Türkiye",
                Il = "Adana",
                TelefonNumarasi = "05054657858",
                EpostaAdresi = "fatihemre.1111@gmail.com",
                Cinsiyet = "Erkek",
                DogumYili = 2003,
                BedenOlcusu = "L",
                OyunSeviye = 5,
                DahaOnceKatildiMi = false,
            };
            Console.WriteLine("objeler oluşturuldu");
            Console.WriteLine("kayıt işlemi başlatılıyor");
            OyuncuKayitTemelBilgiler oyuncuKayitTemelBilgiler = new OyuncuKayitTemelBilgiler();
            oyuncuKayitTemelBilgiler.temelkayitekle(oyuncuTemelBilgiler,macEs,ucret,dahaOnceKatildigiLig);
            Console.WriteLine("Kayıt işlemi  bitirildi");
            */
            //_oyuncuKayitTemelBilgilerManager.temelkayitekle(temelKayitEkleRequest);
            return Ok();
        }


        private List<YasKategori> yasKategorileri = new List<YasKategori>()
        {
            //Tek Erkekler
            new YasKategori(){YasBaslangic =20,YasBitis = 29,Cinsiyet = "ERKEK" ,CiftTercih = false,KarisikTercih = false },//geçiçi (sonra sil)

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


        [HttpPost("yasHesapTest")]
        public IActionResult TestEt(/*int YasBaslangic, int YasBitis,*/int dogumYili ,string Cinsiyet, bool CiftTercih, bool KarisikTercih)
        {
            int oyuncuYas = yasHesapla(dogumYili);
            Console.WriteLine("oyuncu yaşı " + oyuncuYas);
            //linq sorgusuna çevirilebilir
            foreach (YasKategori kategori in yasKategorileri)
            {
                if ((kategori.YasBaslangic <= oyuncuYas) && (oyuncuYas <= kategori.YasBitis) &&  (kategori.Cinsiyet == Cinsiyet) && (kategori.CiftTercih == CiftTercih) && (kategori.KarisikTercih == KarisikTercih ))
                {
                    Console.WriteLine(kategori.YasKategoriIdOlustur());
                    return Ok();
                }
            }
            return Ok();
        }
        private int yasHesapla(int dogumYili)
        {
            int guncelYil = DateTime.Now.Year;
            return guncelYil - dogumYili;
        }
        [HttpPost("TopluKayitTest")]
		public IActionResult TopluTest(List<TemelKayitEkleRequest> kayitlar)
        {
            return Ok();
        }

	}



}
