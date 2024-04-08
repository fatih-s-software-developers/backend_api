using backend_api.Entities;

namespace backend_api.Business.Dto.Requests;

public class TemelKayitEkleRequest
{
    public OyuncuTemelBilgiler OyuncuTemelBilgiler { get; set; }

    public MacEs MacEs { get; set; }

    public Ucret Ucret { get; set; }

    public DahaOnceKatildigiLig DahaOnceKatildigiLig { get; set; }

}
