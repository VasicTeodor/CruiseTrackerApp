using CruiseTracker.Model;
using CruiseTracker.Service.Interfaces;
using CruiseTracker.Service.Services;
using CruiseTracker.WPF.Helpers;
using System.Collections.ObjectModel;
using System.Linq;

namespace CruiseTracker.WPF.ViewModel
{
    public class CruisesViewModel : BindableBase
    {
        private ObservableCollection<Plovidba> _allCruises;
        private Plovidba _selectedCruise;
        private string _capName;
        private string _destName;
        private string _cruisesCount;
        private CruiseTrackerService _cruiseTrackerService = new CruiseTrackerService();
        public static Plovidba cruise;
        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddNewCruiseCommand { get; set; }
        public MyICommand EditCruise { get; set; }
        public MyICommand GetCruisesCount { get; set; }
        public CruisesViewModel()
        {
            _allCruises = new ObservableCollection<Plovidba>(_cruiseTrackerService.GetAllCruises().ToList());

            AddNewCruiseCommand = new MyICommand(AddNewCruise);
            DeleteCommand = new MyICommand(RemoveSelectedCruise, CanRemoveCruise);
            EditCruise = new MyICommand(EditSelectedCruise);
            GetCruisesCount = new MyICommand(GetCruisesCountForDestNameAndCapName);
        }

        public Plovidba SelectedCruise
        {
            get
            {
                return _selectedCruise;
            }
            set
            {
                if (_selectedCruise != value)
                {
                    _selectedCruise = value;
                    OnPropertyChanged("SelectedCruise");
                }
            }
        }

        public ObservableCollection<Plovidba> AllCruises
        {
            get
            {
                return _allCruises;
            }
            set
            {
                if (_allCruises != value)
                {
                    _allCruises = value;
                    OnPropertyChanged("AllCruises");
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
        public string DestName
        {
            get { return _destName; }
            set
            {
                if (_destName != value)
                {
                    _destName = value;
                    OnPropertyChanged("DestName");
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
                    OnPropertyChanged("CapName");
                }
            }
        }
        private bool CanRemoveCruise()
        {
            return (SelectedCruise != null);
        }

        private void AddNewCruise()
        {
            MainViewModel.Instance.OnNav("AddCruise");
        }

        private void EditSelectedCruise()
        {
            if (SelectedCruise != null)
            {
                cruise = SelectedCruise;
                MainViewModel.Instance.OnNav("EditCruise");
            }
        }

        private void RemoveSelectedCruise()
        {
            if (SelectedCruise != null)
            {
                _cruiseTrackerService.RemoveCruise(SelectedCruise.brPlovidbe);
                SelectedCruise = null;
                AllCruises = new ObservableCollection<Plovidba>(_cruiseTrackerService.GetAllCruises().ToList());
            }
        }

        private void GetCruisesCountForDestNameAndCapName()
        {
            if (!(string.IsNullOrWhiteSpace(DestName) || string.IsNullOrEmpty(DestName) ||
                 string.IsNullOrWhiteSpace(CapName) || string.IsNullOrEmpty(CapName)))
            {
                CruisesCount = _cruiseTrackerService.GetCruisesCountForDestNameAndCapName(DestName, CapName).ToString();
            }
        }
    }
}