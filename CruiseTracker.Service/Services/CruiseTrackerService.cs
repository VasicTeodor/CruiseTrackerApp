using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using CruiseTracker.Model;
using CruiseTracker.Service.Interfaces;

namespace CruiseTracker.Service.Services
{
    public class CruiseTrackerService : ICruiseTrackerService
    {
        private readonly CruiseService _cruiseService = new CruiseService();
        private readonly HarborService _harborService = new HarborService();
        private readonly CargoShipService _cargoShipService = new CargoShipService();
        private readonly PassengerShipServices _passengerShipServices = new PassengerShipServices();
        private readonly DestinationService _destinationService = new DestinationService();
        private readonly BoatService _boatService = new BoatService();
        private readonly CaptainService _captainService = new CaptainService();
        private readonly Operations _operations = new Operations();

        public void CreateCargoShip(string name, string loadCapacity, string containerCapacity)
        {
            Brod cargoShip = new Brod()
            {
                naziv = name,
                Teretni = new Teretni
                {
                    brKontejnera = Convert.ToInt32(containerCapacity),
                    nosivost = Convert.ToDouble(loadCapacity,CultureInfo.InvariantCulture)
                }
            };

            _boatService.CreateBoat(cargoShip);
        }

        public void CreateCruise(Plovidba cruise)
        {
            _cruiseService.CreateCruise(cruise);
        }

        public void CreateHarbor(string dockNum, string name, string location, string country)
        {
            Luka harbor = new Luka
            {
                naziv = name,
                mesto = location,
                brDokova = Convert.ToInt32(dockNum),
                drzava = country
            };

            _harborService.CreateHarbor(harbor);
        }

        public void CreateNewDestination(string destinationName)
        {
            Destinacija destination = new Destinacija
            {
                nazivDestinacije = destinationName
            };
            _destinationService.CreateNewDestination(destination);
        }

        public void CreatePassengerShip(string name, string cabinCount, string passengerCount)
        {
            Brod passengerShip = new Brod()
            {
                naziv = name,
                Putnicki = new Putnicki
                {
                    brKabina = Convert.ToInt32(cabinCount),
                    brPutnika = Convert.ToInt32(passengerCount)
                }
            };
            _boatService.CreateBoat(passengerShip);
        }

        public IEnumerable<Kapetan> GetAllCaptains()
        {
            return _captainService.GetAllCaptains().ToList();
        }

        public IEnumerable<Teretni> GetAllCargoShips()
        {
            return _cargoShipService.GetAllCargoShips().ToList();
        }

        public IEnumerable<Plovidba> GetAllCruises()
        {
            return _cruiseService.GetAllCruises();
        }

        public IEnumerable<Destinacija> GetAllDestinations()
        {
            return _destinationService.GetAllDestinations().ToList();
        }
        
        public IEnumerable<Luka> GetAllHarbors()
        {
            return _harborService.GetAllHarbors().ToList();
        }

        public IEnumerable<Putnicki> GetAllPassengerShips()
        {
            return _passengerShipServices.GetAllPassengerShips().ToList();
        }

        public Teretni GetCargoShip(int cargoShipId)
        {
            return _cargoShipService.GetCargoShip(cargoShipId);
        }

        public int GetCruisesCountForDestIdAndCapName(string destId, string capName)
        {
            return _operations.GetCruisesCountForDestIdAndCapName(destId, capName);
        }

        public int GetCruisesCountForDestNameAndCapName(string destName, string capName)
        {
            return _operations.GetCruisesCountForDestNameAndCapName(destName, capName);
        }

        public Destinacija GetDestination(int destinationId)
        {
            return _destinationService.GetDestination(destinationId);
        }

        public Luka GetHarbor(int harborId)
        {
            return _harborService.GetHarbor(harborId);
        }

        public Putnicki GetPassengerShip(int passengerShipId)
        {
            return _passengerShipServices.GetPassengerShip(passengerShipId);
        }

        public Plovidba GetPCruise(int cruiseId)
        {
            return _cruiseService.GetCruise(cruiseId);
        }

        public bool RemoveCargoShip(int id)
        {
            try
            {
                _cargoShipService.RemoveCargoShip(id);
                _boatService.RemoveBoat(id);
                return true;
            }
            catch (Exception e)
            {
                Trace.WriteLine($"Error: {e.Message}");
                return true;
            }
        }

        public void RemoveCruise(int cruiseId)
        {
            _cruiseService.RemoveCruise(cruiseId);
        }

        public bool RemoveDestination(int destinationId)
        {
            try
            {
                _destinationService.RemoveDestination(destinationId);
                return true;
            }
            catch (Exception e)
            {
                Trace.WriteLine($"Error: {e.Message}");
                return false;
            }
        }

        public bool RemoveHarbor(int harborId)
        {
            try
            {
                _harborService.RemoveHarbor(harborId);
                return true;
            }
            catch (Exception e)
            {
                Trace.WriteLine($"Error: {e.Message}");
                return false;
            }
        }

        public bool RemovePassengerShip(int passengerShipId)
        {
            try
            {
                _passengerShipServices.RemovePassengerShip(passengerShipId);
                _boatService.RemoveBoat(passengerShipId);
                return true;
            }
            catch (Exception e)
            {
                Trace.WriteLine($"Error: {e.Message}");
                return true;
            }
        }

        public void UpdateCargoShip(Teretni cargoShip)
        {
            _cargoShipService.UpdateCargoShip(cargoShip);

            Brod boat = new Brod
            {
                idBroda = cargoShip.idBroda,
                naziv = cargoShip.Brod.naziv
            };

            _boatService.UpdateBoat(boat);
        }

        public void UpdateCruise(Plovidba cruise)
        {
            _cruiseService.UpdateCruise(cruise);
        }

        public void UpdateDestination(Destinacija destination)
        {
            _destinationService.UpdateDestination(destination);
        }
        
        public void UpdateHarbor(Luka harbor)
        {
            _harborService.UpdateHarbor(harbor);
        }

        public void UpdatePassengerShip(Putnicki passengerShip)
        {
            _passengerShipServices.UpdatePassengerShip(passengerShip);

            Brod boat = new Brod
            {
                idBroda = passengerShip.idBroda,
                naziv = passengerShip.Brod.naziv
            };

            _boatService.UpdateBoat(boat);
        }
    }
}