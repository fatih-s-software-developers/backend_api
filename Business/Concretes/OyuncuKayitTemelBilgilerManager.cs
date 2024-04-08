using backend_api.Business.Abstracts;
using backend_api.Business.Dto.Requests;
using backend_api.DataAccess.Abstracts;

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
        //temel kayıt ekleme
        IOyuncuKayitTemelBilgiler.temelkayitekle(temelKayitEkleRequest.OyuncuTemelBilgiler,temelKayitEkleRequest.MacEs,temelKayitEkleRequest.Ucret,temelKayitEkleRequest.DahaOnceKatildigiLig);
    }
}
