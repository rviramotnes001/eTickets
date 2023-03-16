using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class ProducersServices: EntityBaseRepository<Producer>, IProducersService
    {
        private readonly AppDbContext _context;
        public ProducersServices(AppDbContext context) : base(context) { }
    }
}
