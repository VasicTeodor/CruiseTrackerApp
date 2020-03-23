using System;
using System.ComponentModel;
using CruiseTracker.Model;
using CruiseTracker.Service.Services;
using CruiseTracker.WPF.Helpers;

namespace CruiseTracker.WPF.ViewModel
{
    public class AddHarborViewModel : BindableBase
    {
        private string _harborName;
        private string _harborLocation;
        private string _harborCountry;
        private string _dockNumber;
        private string _error;

        private readonly CruiseTrackerService _cruiseTrackerService = new CruiseTrackerService();
        public MyICommand AddNewHarbor { get; set; }
        public MyICommand CancelCommand { get; set; }
        public AddHarborViewModel()
        {
            CancelCommand = new MyICommand(CancelAddingHarbor);
            AddNewHarbor = new MyICommand(AddNewHarborFromData);
        }
        public string DockNumber
        {
            get { return _dockNumber; }
            set
            {
                if (_dockNumber != value)
                {
                    _dockNumber = value;
                    OnPropertyChanged("DockNumber");
                }
            }
        }

        public string HarborCountry
        {
            get { return _harborCountry; }
            set
            {
                if (_harborCountry != value)
                {
                    _harborCountry = value;
                    OnPropertyChanged("HarborCountry");
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

        public string HarborLocation
        {
            get { return _harborLocation; }
            set
            {
                if (_harborLocation != value)
                {
                    _harborLocation = value;
                    OnPropertyChanged("HarborLocation");
                }
            }
        }

        public string HarborName
        {
            get { return _harborName; }
            set
            {
                if (_harborName != value)
                {
                    _harborName = value;
                    OnPropertyChanged("HarborName");
                }
            }
        }

        private void CancelAddingHarbor()
        {
            Error = "";
            MainViewModel.Instance.OnNav("Harbors");
        }

        private bool ValidateData()
        {
            var isInt = int.TryParse(DockNumber, out int n);

            if (String.IsNullOrWhiteSpace(HarborName) || String.IsNullOrEmpty(HarborName))
            {
                Error = "You must enter name for harbor!";
                return false;
            }
            else if (String.IsNullOrWhiteSpace(HarborCountry) || String.IsNullOrEmpty(HarborCountry))
            {
                Error = "You must enter country for harbor!";
                return false;
            }
            else if (String.IsNullOrWhiteSpace(HarborLocation) || String.IsNullOrEmpty(HarborLocation))
            {
                Error = "You must enter location for harbor!";
                return false;
            }
            else if (String.IsNullOrWhiteSpace(DockNumber) || String.IsNullOrEmpty(DockNumber))
            {
                Error = "You must enter dock number for ship!";
                return false;
            }
            else if (!isInt)
            {
                Error = "Docks number must be number!";
                return false;
            }

            return true;
        }
        private void AddNewHarborFromData()
        {
            if (ValidateData())
            {
                _cruiseTrackerService.CreateHarbor(DockNumber,HarborName,HarborLocation,HarborCountry);
                Error = "";
                MainViewModel.Instance.OnNav("Harbors");
            }
        }
    }
}