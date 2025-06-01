using System;
using Network.dto;

namespace Network.objectprotocol
{
    [Serializable]
    public class BuyTicketRequest : IRequest
    {
        public TicketDTO Ticket { get; }
        
        public BuyTicketRequest(TicketDTO ticket) => Ticket = ticket;
    }
}