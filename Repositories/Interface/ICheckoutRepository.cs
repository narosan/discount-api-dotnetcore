using System.Threading.Tasks;
using ingressocom_promocodeAPI.Domain;

namespace ingressocom_promocodeAPI.Repositories.Interface
{
    public interface ICheckoutRepository
    {
        Task<Checkout[]> GetCheckoutExample();
        Task<Promocode[]> GetPromocodes();
        Task<Promocode> GetPromocodeById(string id);
        Task<Event> GetEventById(int id);
        Task<Theatre> GetTheatreById(int id);
    }
}