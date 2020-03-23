using CruiseTracker.WPF.Helpers;

namespace CruiseTracker.WPF.ViewModel
{
    public class MenuViewModel : BindableBase
    {
        public MyICommand Cruises { get; set; }
        public MyICommand Destinations { get; set; }
        public MyICommand Boats { get; set; }
        public MyICommand Harbors { get; set; }
        public MenuViewModel()
        {
            Cruises = new MyICommand(ShowCruises);
            Destinations = new MyICommand(ShowDestinations);
            Boats = new MyICommand(ShowBoats);
            Harbors = new MyICommand(ShowHarbors);
        }

        public void ShowCruises()
        {
            MainViewModel.Instance.OnNav("Cruises");
        }

        public void ShowDestinations()
        {
            MainViewModel.Instance.OnNav("Destinations");
        }

        public void ShowBoats()
        {
            MainViewModel.Instance.OnNav("Boats");
        }

        public void ShowHarbors()
        {
            MainViewModel.Instance.OnNav("Harbors");
        }

    }
}