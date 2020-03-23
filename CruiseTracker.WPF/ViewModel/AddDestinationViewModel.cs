using CruiseTracker.Model;
using CruiseTracker.Service.Services;
using CruiseTracker.WPF.Helpers;

namespace CruiseTracker.WPF.ViewModel
{
    public class AddDestinationViewModel : BindableBase
    {
        private string _destinationName;
        private string _error;
        private readonly CruiseTrackerService _cruiseTrackerService = new CruiseTrackerService();
        public MyICommand AddNewDestination { get; set; }
        public MyICommand CancelCommand { get; set; }
        public AddDestinationViewModel()
        {
            CancelCommand = new MyICommand(CancelAddingDestination);
            AddNewDestination = new MyICommand(AddNewDestinationFromData);
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

        private void CancelAddingDestination()
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
        private void AddNewDestinationFromData()
        {
            if (ValidateData())
            {
                _cruiseTrackerService.CreateNewDestination(DestinationName);
                Error = "";
                MainViewModel.Instance.OnNav("Destinations");

            }
        }
    }
}