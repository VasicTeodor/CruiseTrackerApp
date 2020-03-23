using CruiseTracker.WPF.Helpers;
using System.Collections.ObjectModel;
using System.Linq;
using CruiseTracker.Model;
using CruiseTracker.Service.Services;
using System.Windows;

namespace CruiseTracker.WPF.ViewModel
{
    public class DestinationsViewModel : BindableBase
    {
        private ObservableCollection<Destinacija> _allDestinations;
        private Destinacija _selectedDestination;
        private string _capName;
        private string _cruisesCount;

        
        private CruiseTrackerService _cruiseTrackerService = new CruiseTrackerService();
        public static Destinacija destination;
        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddDestination { get; set; }
        public MyICommand EditDestination { get; set; }
        public MyICommand GetCruisesCount { get; set; }
        public DestinationsViewModel()
        {
            _allDestinations = new ObservableCollection<Destinacija>(_cruiseTrackerService.GetAllDestinations().ToList());

            AddDestination = new MyICommand(AddNewDestination);
            DeleteCommand = new MyICommand(RemoveSelectedDestination, CanRemoveDestination);
            EditDestination = new MyICommand(EditSelectedDestination);
            GetCruisesCount = new MyICommand(GetCruisesCountProcedure);
        }

        public Destinacija SelectedDestination
        {
            get
            {
                return _selectedDestination;
            }
            set
            {
                if (_selectedDestination != value)
                {
                    _selectedDestination = value;
                    OnPropertyChanged("SelectedDestination");
                }
            }
        }

        public string CruisesCount
        {
            get { return _cruisesCount; }
            set
            {
                if (_cruisesCount != value)
                {
                    _cruisesCount = value;
                    OnPropertyChanged("CruisesCount");
                }
            }
        }

        public string CapName
        {
            get { return _capName; }
            set
            {
                if (_capName != value)
                {
                    _capName = value;
                    OnPropertyChanged("CruisesCount");
                }
            }
        }


        public ObservableCollection<Destinacija> AllDestinations
        {
            get
            {
                return _allDestinations;
            }
            set
            {
                if (_allDestinations != value)
                {
                    _allDestinations = value;
                    OnPropertyChanged("AllDestinations");
                }
            }
        }

        private void AddNewDestination()
        {
            MainViewModel.Instance.OnNav("AddDestination");
        }

        private void EditSelectedDestination()
        {
            if (SelectedDestination != null)
            {
                destination = SelectedDestination;
                MainViewModel.Instance.OnNav("EditDestination");
            }
        }

        private void RemoveSelectedDestination()
        {
            if (SelectedDestination != null)
            {
                if (!_cruiseTrackerService.RemoveDestination(SelectedDestination.brDestinacije))
                {
                    MessageBox.Show("You can't remove destination wich is used for cruise.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    SelectedDestination = null;
                    AllDestinations = new ObservableCollection<Destinacija>(_cruiseTrackerService.GetAllDestinations().ToList());
                }
            }
        }

        private void GetCruisesCountProcedure()
        {
            if (SelectedDestination != null)
            {
                CruisesCount = _cruiseTrackerService.GetCruisesCountForDestIdAndCapName(SelectedDestination.brDestinacije.ToString(),
                CapName).ToString();
            }
        }

        private bool CanRemoveDestination()
        {
            return (SelectedDestination != null);
        }
    }
}