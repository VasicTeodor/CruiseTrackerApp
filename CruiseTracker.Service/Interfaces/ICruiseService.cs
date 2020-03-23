using System.Collections.Generic;
using CruiseTracker.Model;

namespace CruiseTracker.Service.Interfaces
{
    public interface ICruiseService
    {
        IEnumerable<Plovidba> GetAllCruises();
        Plovidba GetCruise(int cruiseId);
        void RemoveCruise(int cruiseId);
        void UpdateCruise(Plovidba cruise);
        void CreateCruise(Plovidba cruise);
    }
}