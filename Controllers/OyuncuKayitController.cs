using backend_api.Business.Abstracts;
using backend_api.Business.Dto.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OyuncuKayitController : ControllerBase
    {
        private readonly IOyuncuKayitTemelBilgilerManager _oyuncuKayitTemelBilgilerManager;

        public OyuncuKayitController(IOyuncuKayitTemelBilgilerManager oyuncuKayitTemelBilgilerManager)
        {
            _oyuncuKayitTemelBilgilerManager = oyuncuKayitTemelBilgilerManager;
        }

        [HttpPost("KayitEkle")]
        public IActionResult OyuncuKayitEkle(TemelKayitEkleRequest temelKayitEkleRequest) {

            _oyuncuKayitTemelBilgilerManager.temelkayitekle(temelKayitEkleRequest);
            return Ok();
        }

        [HttpPost("TopluKayitEkle")]
        public IActionResult TopluOyuncuKayitEkle(List<TemelKayitEkleRequest> kayitlar)
        {
            _oyuncuKayitTemelBilgilerManager.TopluTemelKayitEkle(kayitlar);
            return Ok();
        }



    }
}
