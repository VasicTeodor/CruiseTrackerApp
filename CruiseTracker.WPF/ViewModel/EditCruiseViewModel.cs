using CruiseTracker.Model;
using CruiseTracker.Service.Services;
using CruiseTracker.WPF.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace CruiseTracker.WPF.ViewModel
{
    public class EditCruiseViewModel : BindableBase
    {
        private string _destinationName;
        private string _destinationDescription;
        private string _passengerCount;
        private string _departureDate;
        private string _error;
        private Kapetan _selectedCaptain;
        private Destinacija _selectedDestination;
        private Luka _selectedHarbor;
        private ObservableCollection<Kapetan> _avilableCaptains;
        private ObservableCollection<Luka> _avilableHarbors;
        private ObservableCollection<Destinacija> _avilableDestinations;
        private Plovidba _selectedCruise;

        private readonly CruiseTrackerService _cruiseTrackerService = new CruiseTrackerService();
        public MyICommand EditCruise { get; set; }
        public MyICommand CancelCommand { get; set; }
        public EditCruiseViewModel()
        {
            AvilableCaptains = new ObservableCollection<Kapetan>(_cruiseTrackerService.GetAllCaptains());
            AvilableDestinations = new ObservableCollection<Destinacija>(_cruiseTrackerService.GetAllDestinations());
            AvilableHarbors = new ObservableCollection<Luka>(_cruiseTrackerService.GetAllHarbors());

            if (CruisesViewModel.cruise != null)
            {
                SelectedCruise = CruisesViewModel.cruise;
                DestinationName = SelectedCruise.naziv;
                DestinationDescription = SelectedCruise.opis;
                PassengerCount = SelectedCruise.brPutnika.ToString();
                SelectedHarbor = AvilableHarbors.Where(h => h.idLuke == SelectedCruise.Luka.idLuke).FirstOrDefault();
                SelectedCaptain = AvilableCaptains.Where(c => c.idKapetana == SelectedCruise.Kapetan.idKapetana).FirstOrDefault();
                SelectedDestination = AvilableDestinations
                    .Where(d => d.brDestinacije == SelectedCruise.Destinacija.brDestinacije).FirstOrDefault();
                DepartureDate = SelectedCruise.polazak.ToString("MM/dd/yyyy");
            }

            EditCruise = new MyICommand(EditCruiseFromData);
            CancelCommand = new MyICommand(CancelAddingCruise);
        }

        public Plovidba SelectedCruise
        {
            get { return _selectedCruise; }
            set
            {
                if (_selectedCruise != value)
                {
                    _selectedCruise = value;
                }
            }
        }

        public ObservableCollection<Destinacija> AvilableDestinations
        {
            get { return _avilableDestinations; }
            set
            {
                if (_avilableDestinations != value)
                {
                    _avilableDestinations = value;
                    OnPropertyChanged("AvilableDestinations");
                }
            }
        }

        public ObservableCollection<Luka> AvilableHarbors
        {
            get { return _avilableHarbors; }
            set
            {
                if (_avilableHarbors != value)
                {
                    _avilableHarbors = value;
                    OnPropertyChanged("AvilableHarbors");
                }
            }
        }

        public ObservableCollection<Kapetan> AvilableCaptains
        {
            get { return _avilableCaptains; }
            set
            {
                if (_avilableCaptains != value)
                {
                    _avilableCaptains = value;
                    OnPropertyChanged("AvilableCaptains");
                }
            }
        }

        public Luka SelectedHarbor
        {
            get { return _selectedHarbor; }
            set
            {
                if (_selectedHarbor != value)
                {
                    _selectedHarbor = value;
                    OnPropertyChanged("SelectedHarbor");
                }
            }
        }

        public Destinacija SelectedDestination
        {
            get { return _selectedDestination; }
            set
            {
                if (_selectedDestination != value)
                {
                    _selectedDestination = value;
                    OnPropertyChanged("SelectedDestination");
                }
            }
        }

        public Kapetan SelectedCaptain
        {
            get { return _selectedCaptain; }
            set
            {
                if (_selectedCaptain != value)
                {
                    _selectedCaptain = value;
                    OnPropertyChanged("SelectedCaptain");
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

        public string DepartureDate
        {
            get { return _departureDate; }
            set
            {
                if (_departureDate != value)
                {
                    _departureDate = value;
                    OnPropertyChanged("DepartureDate");
                }
            }
        }

        public string PassengerCount
        {
            get { return _passengerCount; }
            set
            {
                if (_passengerCount != value)
                {
                    _passengerCount = value;
                    OnPropertyChanged("PassengerCount");
                }
            }
        }

        public string DestinationDescription
        {
            get { return _destinationDescription; }
            set
            {
                if (_destinationDescription != value)
                {
                    _destinationDescription = value;
                    OnPropertyChanged("DestinationDescription");
                }
            }
        }

        public string DestinationName
        {
            get { return _destinationName; }
            set
            {
                if (_destinationName != value)
                {
                    _destinationName = value;
                    OnPropertyChanged("DestinationName");
                }
            }
        }

        private void CancelAddingCruise()
        {
            Error = "";
            MainViewModel.Instance.OnNav("Cruises");
        }

        private bool Validate()
        {
            var isInt = int.TryParse(PassengerCount, out int n);

            if (String.IsNullOrWhiteSpace(DestinationName) || String.IsNullOrEmpty(DestinationName))
            {
                Error = "You must enter name for cruise!";
                return false;
            }
            else if (String.IsNullOrWhiteSpace(DepartureDate) || String.IsNullOrEmpty(DepartureDate))
            {
                Error = "You must chose departure date!";
                return false;
            }
            else if (String.IsNullOrWhiteSpace(DestinationDescription) || String.IsNullOrEmpty(DestinationDescription))
            {
                Error = "You must enter description for destination!";
                return false;
            }
            else if (String.IsNullOrWhiteSpace(PassengerCount) || String.IsNullOrEmpty(PassengerCount))
            {
                Error = "You must enter number of avilable tickets!";
                return false;
            }
            else if (!isInt)
            {
                Error = "Tickets number must be number!";
                return false;
            }

            return true;
        }

        private void EditCruiseFromData()
        {
            if (Validate())
            {
                DateTime time = DateTime.Parse(DepartureDate, CultureInfo.InvariantCulture);

                SelectedCruise.brPutnika = Convert.ToInt32(PassengerCount);
                SelectedCruise.opis = DestinationDescription;
                SelectedCruise.naziv = DestinationName;
                SelectedCruise.polazak = time;

                _cruiseTrackerService.UpdateCruise(SelectedCruise);

                Error = "";
                MainViewModel.Instance.OnNav("Cruises");
            }
        }
    }
}