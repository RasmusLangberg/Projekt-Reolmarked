using System.Windows.Input;

namespace Projekt_Reolmarked.ViewModel
{
    public class MainViewModel
    {
        public ShelfManagerViewModel ShelfManagerViewModel { get; }

        public SellerViewModel SellerViewModel { get; }

       public ItemViewModel ItemViewModel { get; }

        public ICommand OpenCheckoutCommand { get; }


        public MainViewModel()
        {
            SellerViewModel = new SellerViewModel();
            ItemViewModel = new ItemViewModel(SellerViewModel);
            ShelfManagerViewModel = new ShelfManagerViewModel(SellerViewModel);
           
        }
        
       
        

    }
}
