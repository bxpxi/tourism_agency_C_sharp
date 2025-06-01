using System.Collections.Generic;
using Domain;
using Repository.interfaces;
using Service.interfaces;

namespace Service.services
{
    public class TicketService : AbstractService<int, Ticket, ITicketRepository>, ITicketService
    {
        public TicketService(ITicketRepository repository) : base(repository)
        {
        
        }

        public IEnumerable<Ticket> FindByFlight(Flight flight)
        {
            return Repository.FindByFlight(flight);
        }
    }
}