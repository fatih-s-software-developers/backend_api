using backend_api.Business.Dto.Requests;
using backend_api.Entities;

namespace backend_api.DataAccess.Abstracts;

public interface IOyuncuKayitTemelBilgiler
{

    void temelkayitekle(OyuncuTemelBilgilerTemelKayitEkleRequest oyuncuTemelBilgiler, MacEsTemelKayitEkleRequest macEs, UcretTemelKayitEkleRequest ucret, DahaOnceKatildigiLigUcretTemelKayitEkleRequest dahaOnceKatildigiLig);
    
}
