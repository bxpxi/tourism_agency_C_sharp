using System.Collections.Generic;
using Domain;

namespace Repository.interfaces
{
    public interface ITicketRepository : IRepository<int, Ticket>
    {
        IEnumerable<Ticket> FindByFlight(Flight flight);
    }
}