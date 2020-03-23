using System;
using CruiseTracker.Model;
using CruiseTracker.Service.Services;
using CruiseTracker.WPF.Helpers;

namespace CruiseTracker.WPF.ViewModel
{
    public class EditPassengerShipViewModel : BindableBase
    {
        private string _shipName;
        private string _cabinCount;
        private string _error;
        private string _passengerCapacity;
        private Putnicki _selectedPassengerShip;

        private readonly CruiseTrackerService _cruiseTrackerService = new CruiseTrackerService();
        public MyICommand EditPassengerShip { get; set; }
        public MyICommand CancelCommand { get; set; }

        public EditPassengerShipViewModel()
        {
            if (BoatsViewModel.passengerShip != null)
            {
                SelectedPassengerShip = BoatsViewModel.passengerShip;

                ShipName = SelectedPassengerShip.Brod.naziv;
                CabinCount = SelectedPassengerShip.brKabina.ToString();
                PassengerCapacity = SelectedPassengerShip.brPutnika.ToString();
            }

            EditPassengerShip = new MyICommand(EditPassengerShipFromData);
            CancelCommand = new MyICommand(CancelAddingPassengerShip);
        }

        public Putnicki SelectedPassengerShip
        {
            get { return _selectedPassengerShip; }
            set
            {
                if (_selectedPassengerShip != value)
                {
                    _selectedPassengerShip = value;
                }
            }
        }

        public string PassengerCapacity
        {
            get { return _passengerCapacity; }
            set
            {
                if (_passengerCapacity != value)
                {
                    _passengerCapacity = value;
                    OnPropertyChanged("PassengerCapacity");
                }
            }
        }

        public string Error
        {
            get { return _error; }
            set
            {
                if (_error != value)
                {
                    _error = value;
                    OnPropertyChanged("Error");
                }
            }
        }


        public string CabinCount
        {
            get { return _cabinCount; }
            set
            {
                if (_cabinCount != value)
                {
                    _cabinCount = value;
                    OnPropertyChanged("CabinCount");
                }
            }
        }

        public string ShipName
        {
            get { return _shipName; }
            set
            {
                if (_shipName != value)
                {
                    _shipName = value;
                    OnPropertyChanged("ShipName");
                }
            }
        }

        private bool ValidateData()
        {
            var isInt = int.TryParse(PassengerCapacity, out int n);
            var isInt2 = int.TryParse(CabinCount, out int c);
            if (String.IsNullOrWhiteSpace(ShipName) || String.IsNullOrEmpty(ShipName))
            {
                Error = "You must enter name for ship!";
                return false;
            }
            else if (String.IsNullOrWhiteSpace(PassengerCapacity) || String.IsNullOrEmpty(PassengerCapacity))
            {
                Error = "You must enter passenger capacity for ship!";
                return false;
            }
            else if (String.IsNullOrWhiteSpace(CabinCount) || String.IsNullOrEmpty(CabinCount))
            {
                Error = "You must enter cabin count for ship!";
                return false;
            }
            else if (!isInt)
            {
                Error = "Passenger capacity must be number!";
                return false;
            }
            else if (!isInt2)
            {
                Error = "Cabin count must be number!";
                return false;
            }
            return true;
        }

        private void EditPassengerShipFromData()
        {
            if (ValidateData())
            {
                SelectedPassengerShip.Brod.naziv = ShipName;
                SelectedPassengerShip.brKabina = Convert.ToInt32(CabinCount);
                SelectedPassengerShip.brPutnika = Convert.ToInt32(PassengerCapacity);
                _cruiseTrackerService.UpdatePassengerShip(SelectedPassengerShip);
                Error = "";
                MainViewModel.Instance.OnNav("Boats");
            }
        }

        private void CancelAddingPassengerShip()
        {
                Error = "";
            MainViewModel.Instance.OnNav("Boats");
        }
    }
}