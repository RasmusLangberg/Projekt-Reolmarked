using Projekt_Reolmarked.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Projekt_Reolmarked.ViewModel
{
    public class MainViewModel
    {

        public ShelfManagerViewModel ShelfManagerViewModel { get; }

        public SellerViewModel SellerViewModel { get; }

        public CheckOutViewModel CheckOutViewModel { get; }

        public ItemViewModel ItemViewModel { get; }

        

        public ICommand OpenCheckoutCommand { get; }
        public ICommand OpenCreateItemCommand { get; }


        public MainViewModel()
        {

            SellerViewModel = new SellerViewModel();
            ItemViewModel = new ItemViewModel(SellerViewModel);
            CheckOutViewModel = new CheckOutViewModel(ItemViewModel);
            ShelfManagerViewModel = new ShelfManagerViewModel(SellerViewModel);



            
        }

       
        


    }
}
