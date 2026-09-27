using System.Windows.Input;

namespace Projekt_Reolmarked.ViewModel
{
    public class MainViewModel
    {
        public ShelfManagerViewModel ShelfManagerViewModel { get; }

        public SellerViewModel UserViewModel { get; }

        public ItemListViewModel ItemListViewModel { get; }

        public ICommand OpenCheckoutCommand { get; }


        public MainViewModel()
        {
            UserViewModel = new SellerViewModel();
            ItemListViewModel = new ItemListViewModel();
            ShelfManagerViewModel = new ShelfManagerViewModel(UserViewModel);

            OpenCheckoutCommand = new RelayCommand(_ => OpenCheckout());
        }

        public void OpenCheckout()
        {
            CheckOut checkout = new CheckOut();
            checkout.Show();
        }


    }
}
