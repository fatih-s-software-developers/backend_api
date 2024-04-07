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

        public ValuesController(IStudentManager studentManager)
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
        public IActionResult AddStudent(AddStudentRequest addStudentRequest) {
            _studentManager.add(addStudentRequest);
            return Ok();
        }
        [HttpGet("KayitTest")]
        public IActionResult Ekle() {
            //Console.WriteLine("objeler oluşturuluyor");
            //MacEs macEs = new MacEs()
            //{
            //    CiftMacTercihi = true,
            //    CiftEsAdi = "Samet",
            //    KarisikMacTercihi = true,
            //    KarisikEsAdi = "Asiye",
            //};
            //Ucret ucret = new Ucret()
            //{
            //    OdemeYapanKisininAdiSoyadi = "Fatih KILINÇ",
            //    UcretOdemesiYapildiMi = true,
            //    OdemeYapilmasiPlanlananTarih = DateTime.Now.ToUniversalTime(),
            //};
            //DahaOnceKatildigiLig dahaOnceKatildigiLig = new DahaOnceKatildigiLig()
            //{
            //    UlusalLiglerdeOynadiMi = true,
            //    LigAdi = "Süper Lig",
            //};
            //OyuncuTemelBilgiler oyuncuTemelBilgiler = new OyuncuTemelBilgiler
            //{
            //    Adi = "Fatih",
            //    Soyadi = "KILINÇ",
            //    Ulke = "Türkiye",
            //    Il = "Adana",
            //    TelefonNumarasi = "05054657858",
            //    EpostaAdresi = "fatihemre.1111@gmail.com",
            //    Cinsiyet = "Erkek",
            //    DogumYili = 2003,
            //    BedenOlcusu = "L",
            //    OyunSeviye = 5,
            //    DahaOnceKatildiMi = false,
            //};
            //Console.WriteLine("objeler oluşturuldu");
            //Console.WriteLine("kayıt işlemi başlatılıyor");
            //OyuncuKayitTemelBilgiler oyuncuKayitTemelBilgiler = new OyuncuKayitTemelBilgiler();
            //oyuncuKayitTemelBilgiler.temelkayitekle(oyuncuTemelBilgiler,macEs,ucret,dahaOnceKatildigiLig);
            //Console.WriteLine("Kayıt işlemi  bitirildi");
            return Ok();
        
        }



    }
}
