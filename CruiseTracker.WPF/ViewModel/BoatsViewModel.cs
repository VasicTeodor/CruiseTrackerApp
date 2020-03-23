using CruiseTracker.Model;
using CruiseTracker.Service.Services;
using CruiseTracker.WPF.Helpers;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace CruiseTracker.WPF.ViewModel
{
    public class BoatsViewModel : BindableBase
    {
        private ObservableCollection<Teretni> _allCargoShips;
        private Teretni _selectedCargoShip;
        private ObservableCollection<Putnicki> _allPassengerShips;
        private Putnicki _selectedPassengerShip;
        private CruiseTrackerService _cruiseTrackerService = new CruiseTrackerService();

        public static Teretni cargoShip;
        public static Putnicki passengerShip;

        public MyICommand DeleteCargoShip { get; set; }
        public MyICommand AddCargoShip { get; set; }
        public MyICommand EditCargoShip { get; set; }
        public MyICommand DeletePassengerShip { get; set; }
        public MyICommand AddPassengerShip { get; set; }
        public MyICommand EditPassengerShip { get; set; }
        public BoatsViewModel()
        {
            AllCargoShips = new ObservableCollection<Teretni>(_cruiseTrackerService.GetAllCargoShips().ToList());
            AllPassengerShips = new ObservableCollection<Putnicki>(_cruiseTrackerService.GetAllPassengerShips().ToList());

            AddCargoShip = new MyICommand(AddNewCargoShip);
            AddPassengerShip = new MyICommand(AddNewPassengerShip);
            EditCargoShip = new MyICommand(EditSelectedCargoShip);
            EditPassengerShip = new MyICommand(EditSelectedPassengerShip);
            DeleteCargoShip = new MyICommand(RemoveSelectedCargoShip, CanRemoveCargoShip);
            DeletePassengerShip = new MyICommand(RemoveSelectedPassengerShip, CanRemovePassengerShip);
        }

        public Teretni SelectedCargoShip
        {
            get
            {
                return _selectedCargoShip;
            }
            set
            {
                if (_selectedCargoShip != value)
                {
                    _selectedCargoShip = value;
                }
            }
        }

        public ObservableCollection<Teretni> AllCargoShips
        {
            get
            {
                return _allCargoShips;
            }
            set
            {
                if (_allCargoShips != value)
                {
                    _allCargoShips = value;
                    OnPropertyChanged("AllCargoShips");
                }
            }
        }

        public Putnicki SelectedPassengerShip
        {
            get
            {
                return _selectedPassengerShip;
            }
            set
            {
                if (_selectedPassengerShip != value)
                {
                    _selectedPassengerShip = value;
                }
            }
        }

        public ObservableCollection<Putnicki> AllPassengerShips
        {
            get
            {
                return _allPassengerShips;
            }
            set
            {
                if (_allPassengerShips != value)
                {
                    _allPassengerShips = value;
                    OnPropertyChanged("AllPassengerShips");
                }
            }
        }

        private void AddNewCargoShip()
        {
            MainViewModel.Instance.OnNav("AddCargoShip");
        }

        private void AddNewPassengerShip()
        {
            MainViewModel.Instance.OnNav("AddPassengerShip");
        }

        private void EditSelectedCargoShip()
        {
            if (SelectedCargoShip != null)
            {
                cargoShip = SelectedCargoShip;
                MainViewModel.Instance.OnNav("EditCargoShip");
            }
        }

        private void EditSelectedPassengerShip()
        {
            if (SelectedPassengerShip != null)
            {
                passengerShip = SelectedPassengerShip;
                MainViewModel.Instance.OnNav("EditPassengerShip");
            }
        }

        private void RemoveSelectedCargoShip()
        {
            if (SelectedCargoShip != null)
            {
                if (!_cruiseTrackerService.RemoveCargoShip(SelectedCargoShip.idBroda))
                {
                    MessageBox.Show("You can't remove cargo ship wich is used for cruise.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    SelectedCargoShip = null;
                    AllCargoShips = new ObservableCollection<Teretni>(_cruiseTrackerService.GetAllCargoShips().ToList());
                }
            }
        }

        private bool CanRemoveCargoShip()
        {
            return (SelectedCargoShip != null);
        }

        private void RemoveSelectedPassengerShip()
        {
            if (SelectedPassengerShip != null)
            {
                if (!_cruiseTrackerService.RemovePassengerShip(SelectedPassengerShip.idBroda))
                {
                    MessageBox.Show("You can't remove passenger ship wich is used for cruise.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    SelectedPassengerShip = null;
                    AllPassengerShips = new ObservableCollection<Putnicki>(_cruiseTrackerService.GetAllPassengerShips().ToList());
                }
            }
        }

        private bool CanRemovePassengerShip()
        {
            return (SelectedPassengerShip != null);
        }
    }
}