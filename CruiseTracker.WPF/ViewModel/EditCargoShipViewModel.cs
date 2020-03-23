using CruiseTracker.Model;
using CruiseTracker.Service.Services;
using CruiseTracker.WPF.Helpers;
using System;
using System.Globalization;

namespace CruiseTracker.WPF.ViewModel
{
    public class EditCargoShipViewModel : BindableBase
    {
        private string _shipName;
        private string _loadCapacity;
        private string _error;
        private string _containerCapacity;
        private Teretni _selectedCargoShip;

        private readonly CruiseTrackerService _cruiseTrackerService = new CruiseTrackerService();
        public MyICommand EditCargoShip { get; set; }
        public MyICommand CancelCommand { get; set; }

        public EditCargoShipViewModel()
        {
            if (BoatsViewModel.cargoShip != null)
            {
                SelectedCargoShip = BoatsViewModel.cargoShip;
                ShipName = SelectedCargoShip.Brod.naziv;
                LoadCapacity = SelectedCargoShip.nosivost.ToString();
                ContainerCapacity = SelectedCargoShip.brKontejnera.ToString();
            }

            EditCargoShip = new MyICommand(EditCargoShipFromData);
            CancelCommand = new MyICommand(CancelEditingCargoShip);
        }

        public Teretni SelectedCargoShip
        {
            get { return _selectedCargoShip; }
            set
            {
                if (_selectedCargoShip != value)
                {
                    _selectedCargoShip = value;
                }
            }
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
            else if (String.IsNullOrWhiteSpace(ContainerCapacity) || String.IsNullOrEmpty(ContainerCapacity))
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

        private void EditCargoShipFromData()
        {
            if (ValidateData())
            {
                SelectedCargoShip.Brod.naziv = ShipName;
                SelectedCargoShip.brKontejnera = Convert.ToInt32(ContainerCapacity);
                SelectedCargoShip.nosivost = Convert.ToDouble(LoadCapacity, CultureInfo.InvariantCulture);
                _cruiseTrackerService.CreateCargoShip(ShipName, LoadCapacity, ContainerCapacity);
                Error = "";
                MainViewModel.Instance.OnNav("Boats");
            }
        }

        private void CancelEditingCargoShip()
        {
                Error = "";
            MainViewModel.Instance.OnNav("Boats");
        }
    }
}