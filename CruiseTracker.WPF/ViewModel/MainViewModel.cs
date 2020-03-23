using CruiseTracker.Service.Services;
using CruiseTracker.WPF.Helpers;

namespace CruiseTracker.WPF.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private MenuViewModel _menuViewModel = new MenuViewModel();
        private CruisesViewModel _cruisesViewModel = new CruisesViewModel();
        private DestinationsViewModel _destinationsViewModel = new DestinationsViewModel();
        private BoatsViewModel _boatsViewModel = new BoatsViewModel();
        private HarborsViewModel _harborsViewModel = new HarborsViewModel();
        private AddCruiseViewModel _addCruiseViewModel = new AddCruiseViewModel();
        private AddHarborViewModel _addHarborViewModel = new AddHarborViewModel();
        private AddDestinationViewModel _addDestinationViewModel = new AddDestinationViewModel();
        private AddCargoShipViewModel _addCargoShipViewModel = new AddCargoShipViewModel();
        private AddPassengerShipViewModel _addPassengerShipViewModel = new AddPassengerShipViewModel();
        private EditDestinationViewModel _editDestinationViewModel = new EditDestinationViewModel();
        private EditHarborViewModel _editHarborViewModel = new EditHarborViewModel();
        private EditCargoShipViewModel _editCargoShipViewModel = new EditCargoShipViewModel();
        private EditPassengerShipViewModel _editPassengerShipViewModel = new EditPassengerShipViewModel();
        private EditCruiseViewModel _editCruiseViewModel = new EditCruiseViewModel();
        private BindableBase _currentViewModel;
        private BindableBase _menu;
        private static MainViewModel _instance;

        public static MainViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainViewModel();

                return _instance;
            }
        }
        private MainViewModel()
        {
            Menu = _menuViewModel;
            CurrentViewModel = _cruisesViewModel;
        }

        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                SetProperty(ref _currentViewModel, value);
            }
        }

        public BindableBase Menu
        {
            get { return _menu; }
            set
            {
                SetProperty(ref _menu, value);
            }
        }

        public void OnNav(string destination)
        {
            switch (destination)
            {
                case "Cruises":
                    CurrentViewModel = _cruisesViewModel;
                    break;
                case "Destinations":
                    CurrentViewModel = _destinationsViewModel;
                    break;
                case "Boats":
                    CurrentViewModel = _boatsViewModel;
                    break;
                case "Harbors":
                    CurrentViewModel = _harborsViewModel;
                    break;
                case "AddHarbor":
                    CurrentViewModel = _addHarborViewModel;
                    break;
                case "AddDestination":
                    CurrentViewModel = _addDestinationViewModel;
                    break;
                case "AddCargoShip":
                    CurrentViewModel = _addCargoShipViewModel;
                    break;
                case "AddCruise":
                    CurrentViewModel = _addCruiseViewModel;
                    break;
                case "AddPassengerShip":
                    CurrentViewModel = _addPassengerShipViewModel;
                    break;
                case "EditDestination":
                    CurrentViewModel = _editDestinationViewModel;
                    break;
                case "EditHarbor":
                    CurrentViewModel = _editHarborViewModel;
                    break;
                case "EditCargoShip":
                    CurrentViewModel = _editCargoShipViewModel;
                    break;
                case "EditPassengerShip":
                    CurrentViewModel = _editPassengerShipViewModel;
                    break;
                case "EditCruise":
                    CurrentViewModel = _editCruiseViewModel;
                    break;
            }   
        }
    }
}