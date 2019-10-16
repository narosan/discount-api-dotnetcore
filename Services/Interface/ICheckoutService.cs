using System.Collections.Generic;
using System.Threading.Tasks;
using ingressocom_promocodeAPI.Domain;

namespace ingressocom_promocodeAPI.Services.Interface
{
    public interface ICheckoutService
    {
        Task<decimal> StartProcess(Checkout checkout);
        decimal FixedPromocodeValue(Checkout checkout);
        decimal HighestPromocodeValue(Checkout checkout);
        decimal LowestPromocodeValue(Checkout checkout);
    }
}