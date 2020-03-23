using System.Collections.Generic;
using CruiseTracker.Model;

namespace CruiseTracker.Service.Interfaces
{
    public interface IDestinationService
    {
        IEnumerable<Destinacija> GetAllDestinations();
        Destinacija GetDestination(int destinationId);
        void CreateNewDestination(Destinacija destination);
        void UpdateDestination(Destinacija destination);
        void RemoveDestination(int destinationId);
    }
}