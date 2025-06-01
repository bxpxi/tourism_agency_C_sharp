using Domain;

namespace Service.observer
{
    public interface IObserver
    {
        void UpdateFlight(Flight flight);
    }
}