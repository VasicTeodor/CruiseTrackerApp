using System.Collections.Generic;
using CruiseTracker.Model;

namespace CruiseTracker.Service.Interfaces
{
    public interface IHarborService
    {
        IEnumerable<Luka> GetAllHarbors();
        Luka GetHarbor(int harborId);
        void UpdateHarbor(Luka harbor);
        void CreateHarbor(Luka harbor);
        void RemoveHarbor(int harborId);
    }
}