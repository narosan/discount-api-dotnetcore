using System.Linq;
using System.Threading.Tasks;
using ingressocom_promocodeAPI.Domain;
using Microsoft.EntityFrameworkCore;
using ingressocom_promocodeAPI.Repositories.Interface;

namespace ingressocom_promocodeAPI.Repositories
{
    public class CheckoutRepository : ICheckoutRepository
    {
        private readonly CheckoutContext _context;
        public CheckoutRepository(CheckoutContext context)
        {
            _context = context;
        }

        public async Task<Checkout[]> GetCheckoutExample()
        {
            IQueryable<Checkout> query = _context.Checkouts
                .Include(c => c.Sessions);
            return await query
                .OrderByDescending(q => q.Date)
                .ToArrayAsync();
        }

        public async Task<Event> GetEventById(int id)
        {
            return await _context.Events.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Promocode> GetPromocodeById(string id)
        {
            IQueryable<Promocode> query = _context.Promocodes
                .Where(p => p.Id.Equals(id));
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Promocode[]> GetPromocodes()
        {
            return await _context.Promocodes.ToArrayAsync();
        }

        public async Task<Theatre> GetTheatreById(int id)
        {
            return await _context.Theatres.Where(t => t.Id == id).FirstOrDefaultAsync();
        }
    }
}