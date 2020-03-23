using System.Collections.Generic;
using CruiseTracker.Model;

namespace CruiseTracker.Service.Interfaces
{
    public interface ICaptainService
    {
        IEnumerable<Kapetan> GetAllCaptains();
        Kapetan GetCaptain(int captainId);
        void AddCaptain(Kapetan captain);
        void UpdateCaptain(Kapetan captain);
        void RemoveCaptain(int captainId);
    }
}