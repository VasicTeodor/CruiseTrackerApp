using System.Collections.Generic;
using CruiseTracker.Model;

namespace CruiseTracker.Service.Interfaces
{
    public interface ICruiseTrackerService
    {
        //Cruises
        IEnumerable<Plovidba> GetAllCruises();
        Plovidba GetPCruise(int cruiseId);
        void RemoveCruise(int cruiseId);
        void UpdateCruise(Plovidba cruise);
        void CreateCruise(Plovidba cruise);
        //Destinations
        IEnumerable<Destinacija> GetAllDestinations();
        Destinacija GetDestination(int destinationId);
        void CreateNewDestination(string destinationName);
        void UpdateDestination(Destinacija destination);
        bool RemoveDestination(int destinationId);
        //Cargo Ship
        IEnumerable<Teretni> GetAllCargoShips();
        Teretni GetCargoShip(int cargoShipId);
        void CreateCargoShip(string name, string loadCapacity, string containerCapacity);
        void UpdateCargoShip(Teretni cargoShip);
        bool RemoveCargoShip(int id);
        //Passenger Ship
        IEnumerable<Putnicki> GetAllPassengerShips();
        Putnicki GetPassengerShip(int passengerShipId);
        void CreatePassengerShip(string name, string cabinCount, string passengerCount);
        bool RemovePassengerShip(int passengerShipId);
        void UpdatePassengerShip(Putnicki passengerShip);
        //Harbor
        IEnumerable<Luka> GetAllHarbors();
        Luka GetHarbor(int harborId);
        void UpdateHarbor(Luka harbor);
        void CreateHarbor(string dockNum, string name, string location, string country);
        bool RemoveHarbor(int harborId);
        //Captains
        IEnumerable<Kapetan> GetAllCaptains();
        //Functions
        int GetCruisesCountForDestIdAndCapName(string destId, string capName);
        int GetCruisesCountForDestNameAndCapName(string destName, string capName);
    }
}