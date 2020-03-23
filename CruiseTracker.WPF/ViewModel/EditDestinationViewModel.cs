using CruiseTracker.Model;
using CruiseTracker.Service.Services;
using CruiseTracker.WPF.Helpers;

namespace CruiseTracker.WPF.ViewModel
{
    public class EditDestinationViewModel : BindableBase
    {
        private string _destinationName;
        private string _error;
        private Destinacija _selectedDestination;
        private readonly CruiseTrackerService _cruiseTrackerService = new CruiseTrackerService();
        public MyICommand EditDestination { get; set; }
        public MyICommand CancelCommand { get; set; }
        public EditDestinationViewModel()
        {
            if (DestinationsViewModel.destination != null)
            {
                SelectedDestination = DestinationsViewModel.destination;

                DestinationName = SelectedDestination.nazivDestinacije;
            }

            CancelCommand = new MyICommand(CancelEditingDestination);
            EditDestination = new MyICommand(EditDestinationFromData);
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

        private void CancelEditingDestination()
        {
            Error = "";
            MainViewModel.Instance.OnNav("Destinations");
        }

        private bool ValidateData()
        {
            if (string.IsNullOrWhiteSpace(DestinationName) || string.IsNullOrEmpty(DestinationName))
            {
                Error = "You must enter destination name!";
                return false;
            }
            return true;
        }
        private void EditDestinationFromData()
        {
            if (ValidateData())
            {
                SelectedDestination.nazivDestinacije = DestinationName;
                _cruiseTrackerService.UpdateDestination(SelectedDestination);
                Error = "";
                MainViewModel.Instance.OnNav("Destinations");

            }
        }
    }
}