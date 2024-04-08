using backend_api.Business.Dto.Requests;
using backend_api.Entities;

namespace backend_api.Business.Abstracts;

public interface IOyuncuKayitTemelBilgilerManager
{
    void temelkayitekle(TemelKayitEkleRequest temelKayitEkleRequest);

}
