using CruiseTracker.Model;
using CruiseTracker.Service.Services;
using CruiseTracker.WPF.Helpers;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace CruiseTracker.WPF.ViewModel
{
    public class HarborsViewModel : BindableBase
    {
        private ObservableCollection<Luka> _allHarbors;
        private Luka _selectedHarbor;
        private CruiseTrackerService _cruiseTrackerService = new CruiseTrackerService();
        public static Luka harbor;
        public MyICommand DeleteCommand { get; set; }
        public MyICommand AddHarbor { get; set; }
        public MyICommand EditHarbor { get; set; }
        public HarborsViewModel()
        {
            _allHarbors = new ObservableCollection<Luka>(_cruiseTrackerService.GetAllHarbors().ToList());

            AddHarbor = new MyICommand(AddNewHarbor);
            DeleteCommand = new MyICommand(RemoveSelectedHarbor, CanRemoveHarbor);
            EditHarbor = new MyICommand(EditSelectedHarbor);
        }

        public Luka SelectedHarbor
        {
            get
            {
                return _selectedHarbor;
            }
            set
            {
                if (_selectedHarbor != value)
                {
                    _selectedHarbor = value;
                }
            }
        }

        public ObservableCollection<Luka> AllHarbors
        {
            get
            {
                return _allHarbors;
            }
            set
            {
                if (_allHarbors != value)
                {
                    _allHarbors = value;
                    OnPropertyChanged("AllHarbors");
                }
            }
        }

        private void AddNewHarbor()
        {
            MainViewModel.Instance.OnNav("AddHarbor");
        }

        private void EditSelectedHarbor()
        {
            if (SelectedHarbor != null)
            {
                harbor = SelectedHarbor;
                MainViewModel.Instance.OnNav("EditHarbor");
            }
        }

        private void RemoveSelectedHarbor()
        {
            if (SelectedHarbor != null)
            {
                if (!_cruiseTrackerService.RemoveHarbor(SelectedHarbor.idLuke))
                {
                    MessageBox.Show("You can't remove harbor wich is used for cruise.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    SelectedHarbor = null;
                    AllHarbors = new ObservableCollection<Luka>(_cruiseTrackerService.GetAllHarbors().ToList());
                }
            }
        }

        private bool CanRemoveHarbor()
        {
            return (SelectedHarbor != null);
        }
    }
}