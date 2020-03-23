using CruiseTracker.Service.Services;
using CruiseTracker.WPF.Helpers;
using System;
using System.Globalization;

namespace CruiseTracker.WPF.ViewModel
{
    public class AddCargoShipViewModel : BindableBase
    {
        private string _shipName;
        private string _loadCapacity;
        private string _error;
        private string _containerCapacity;
        private readonly CruiseTrackerService _cruiseTrackerService = new CruiseTrackerService();
        public MyICommand AddCargoShip { get; set; }
        public MyICommand CancelCommand { get; set; }

        public AddCargoShipViewModel()
        {
            AddCargoShip = new MyICommand(AddCargoShipFromData);
            CancelCommand = new MyICommand(CancelAddingCargoShip);
        }

        public string ContainerCapacity
        {
            get { return _containerCapacity; }
            set
            {
                if (_containerCapacity != value)
                {
                    _containerCapacity = value;
                    OnPropertyChanged("ContainerCapacity");
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


        public string LoadCapacity
        {
            get { return _loadCapacity; }
            set
            {
                if (_loadCapacity != value)
                {
                    _loadCapacity = value;
                    OnPropertyChanged("LoadCapacity");
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
            var isInt = int.TryParse(ContainerCapacity, out int n);
            var isFloat = double.TryParse(LoadCapacity, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture,
                out double f);
            if (String.IsNullOrWhiteSpace(ShipName) || String.IsNullOrEmpty(ShipName))
            {
                Error = "You must enter name for ship!";
                return false;
            }
            else if(String.IsNullOrWhiteSpace(ContainerCapacity) || String.IsNullOrEmpty(ContainerCapacity))
            {
                Error = "You must enter container capacity for ship!";
                return false;
            }
            else if (String.IsNullOrWhiteSpace(LoadCapacity) || String.IsNullOrEmpty(LoadCapacity))
            {
                Error = "You must enter load capacity for ship!";
                return false;
            }
            else if (!isInt)
            {
                Error = "Container capacity must be number!";
                return false;
            }
            else if (!isFloat)
            {
                Error = "Load capacity must be number!";
                return false;
            }
            return true;
        }

        private void AddCargoShipFromData()
        {
            if (ValidateData())
            {
                _cruiseTrackerService.CreateCargoShip(ShipName, LoadCapacity, ContainerCapacity);
                Error = "";
                MainViewModel.Instance.OnNav("Boats");
            }
        }

        private void CancelAddingCargoShip()
        {
            Error = "";
            MainViewModel.Instance.OnNav("Boats");
        }
    }
}