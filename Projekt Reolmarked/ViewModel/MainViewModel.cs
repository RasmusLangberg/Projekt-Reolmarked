using System.Windows.Input;

namespace Projekt_Reolmarked.ViewModel
{
    public class MainViewModel
    {
        public ShelfManagerViewModel ShelfManagerViewModel { get; }

        public SellerViewModel SellerViewModel { get; }

        public ItemListViewModel ItemListViewModel { get; }

        public ICommand OpenCheckoutCommand { get; }


        public MainViewModel()
        {
            SellerViewModel = new SellerViewModel();
            ItemListViewModel = new ItemListViewModel();
            ShelfManagerViewModel = new ShelfManagerViewModel(SellerViewModel);

            OpenCheckoutCommand = new RelayCommand(_ => OpenCheckout());
        }

        public void OpenCheckout()
        {
            CheckOut checkout = new CheckOut();
            checkout.Show();
        }


    }
}
