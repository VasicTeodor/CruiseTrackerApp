using System;
using CruiseTracker.Model;
using CruiseTracker.Service.Services;
using CruiseTracker.WPF.Helpers;

namespace CruiseTracker.WPF.ViewModel
{
    public class EditHarborViewModel : BindableBase
    {
        private string _harborName;
        private string _harborLocation;
        private string _harborCountry;
        private string _dockNumber;
        private string _error;
        private Luka _selectedHarbor;

        private readonly CruiseTrackerService _cruiseTrackerService = new CruiseTrackerService();
        public MyICommand EditHarbor { get; set; }
        public MyICommand CancelCommand { get; set; }
        public EditHarborViewModel()
        {
            if (HarborsViewModel.harbor != null)
            {
                SelectedHarbor = HarborsViewModel.harbor;
                HarborName = SelectedHarbor.naziv;
                HarborCountry = SelectedHarbor.drzava;
                HarborLocation = SelectedHarbor.mesto;
                DockNumber = SelectedHarbor.brDokova.ToString();
            }

            CancelCommand = new MyICommand(CancelAddingHarbor);
            EditHarbor = new MyICommand(EditHarborFromData);
        }
        public Luka SelectedHarbor
        {
            get { return _selectedHarbor; }
            set
            {
                if (_selectedHarbor != value)
                {
                    _selectedHarbor = value;
                }
            }
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
        private void EditHarborFromData()
        {
            if (ValidateData())
            {
                SelectedHarbor.brDokova = Convert.ToInt32(DockNumber);
                SelectedHarbor.drzava = HarborCountry;
                SelectedHarbor.mesto = HarborLocation;
                SelectedHarbor.naziv = HarborName;

                _cruiseTrackerService.UpdateHarbor(SelectedHarbor);
                Error = "";
                MainViewModel.Instance.OnNav("Harbors");
            }
        }
    }
}