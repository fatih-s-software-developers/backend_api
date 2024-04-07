using backend_api.Entities;

namespace backend_api.DataAccess.Abstracts;

public interface IOyuncuKayitTemelBilgiler
{

    void temelkayitekle(OyuncuTemelBilgiler oyuncuTemelBilgiler, MacEs macEs, Ucret ucret, DahaOnceKatildigiLig dahaOnceKatildigiLig);
    
}
