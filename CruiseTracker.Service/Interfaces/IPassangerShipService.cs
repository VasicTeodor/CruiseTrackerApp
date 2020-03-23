using System.Collections.Generic;
using CruiseTracker.Model;

namespace CruiseTracker.Service.Interfaces
{
    public interface IPassengerShipService
    {
        IEnumerable<Putnicki> GetAllPassengerShips();
        Putnicki GetPassengerShip(int passengerShipId);
        void CreatePassengerShip(Putnicki passengerShip);
        void RemovePassengerShip(int passengerShipId);
        void UpdatePassengerShip(Putnicki passengerShip);
    }
}