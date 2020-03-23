using System.Collections.Generic;
using CruiseTracker.Model;

namespace CruiseTracker.Service.Interfaces
{
    public interface ICargoShipService
    {
        IEnumerable<Teretni> GetAllCargoShips();
        Teretni GetCargoShip(int cargoShipId);
        void CreateCargoShip(Teretni cargoShip);
        void UpdateCargoShip(Teretni cargoShip);
        void RemoveCargoShip(int id);
    }
}