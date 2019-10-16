using System;
using System.Linq;
using System.Threading.Tasks;
using ingressocom_promocodeAPI.Domain;
using ingressocom_promocodeAPI.Repositories.Interface;
using ingressocom_promocodeAPI.Services.Interface;

namespace ingressocom_promocodeAPI.Services
{
    public class CheckoutService : ICheckoutService
    {
        private ICheckoutRepository _checkoutRepository;
        private UtilService _utilService;

        public CheckoutService(ICheckoutRepository checkoutRepository) {
            _checkoutRepository = checkoutRepository;    
            _utilService = new UtilService(checkoutRepository);
        }

        public async Task<decimal> StartProcess(Checkout checkout)
        {
            Promocode promocode = await _checkoutRepository.GetPromocodeById(checkout.Promocode);
            if (_utilService.checkPromocodeIsValid(promocode))
            {
                switch (promocode.Type)
                {
                    case PromocodeTypes.HIGHER_PROMOCODE_DISCOUNT:
                        return HighestPromocodeValue(checkout);
                        
                    case PromocodeTypes.LOWER_PROMOCODE_DISCOUNT:
                        return LowestPromocodeValue(checkout);

                    case PromocodeTypes.FIXED_PROMOCODE_DISCOUNT:
                        return FixedPromocodeValue(checkout);

                    default:
                        return 0;        
                }   
            }
            throw new ArgumentException("Cupom não está válido");
        }

        // Restrição para um filme e um cinema
        public decimal FixedPromocodeValue(Checkout checkout)
        {
            if (_utilService.checkMovieIsContemplated(checkout) 
                && _utilService.checkTheatreIsContemplated(checkout))
            {
                decimal totalValue = checkout.Sessions.Tickets.Select(ticket => ticket.Price).Sum();
                return totalValue - 20;    
            }
            return 0;
        }

        // Restrição para finais de semana
        public decimal HighestPromocodeValue(Checkout checkout)
        {
            if (_utilService.checkDateIsWeekend(checkout.Sessions.Date))
            {
                return checkout.Sessions.Tickets
                        .OrderByDescending(ticket => ticket.Price)
                        .LastOrDefault().Price - (decimal)12.5;
            }
            return 0;
        }

        // Sem restrição
        public decimal LowestPromocodeValue(Checkout checkout)
        {
            return checkout.Sessions.Tickets
                    .OrderByDescending(ticket => ticket.Price)
                    .LastOrDefault().Price - (decimal)9.99;
        }
    }
}