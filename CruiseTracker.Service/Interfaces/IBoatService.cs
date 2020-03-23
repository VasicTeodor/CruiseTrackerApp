using CruiseTracker.Model;
using System.Collections.Generic;

namespace CruiseTracker.Service.Interfaces
{
    public interface IBoatService
    {
        IEnumerable<Brod> GetAllBoats();
        void CreateBoat(Brod boat);
        Brod GetBoat(int boatId);
        void RemoveBoat(int Boat);
        void UpdateBoat(Brod boat);
    }
}