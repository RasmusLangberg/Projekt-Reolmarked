namespace Projekt_Reolmarked.ViewModel
{
    public class MainViewModel
    {
        public ShelfManagerViewModel ShelfManagerViewModel { get; }

        public UserViewModel UserViewModel { get; }


        public MainViewModel()
        {
            UserViewModel = new UserViewModel();
            ShelfManagerViewModel = new ShelfManagerViewModel(UserViewModel);
        }

    }
}
