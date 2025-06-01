using System.Collections.Generic;
using Domain;

namespace Service.interfaces
{
    public interface ITicketService : IService<int, Ticket>
    {
        IEnumerable<Ticket> FindByFlight(Flight flight);
    }
}