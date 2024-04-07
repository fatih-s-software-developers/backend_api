using backend_api.Entities;

namespace backend_api.DataAccess.Abstracts;

public interface IOyuncuKayitTemelBilgiler
{

    void temelkayitekle(OyuncuTemelBilgiler oyuncuTemelBilgiler);
    void macEsEkle(MacEs macEs);

    void ucretEkle(Ucret ucret);

    void DahaOnceKatildigiLigEkle(DahaOnceKatildigiLig dahaOnceKatildigiLig);
    
}
