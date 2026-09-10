using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Printing;
using System.Text;

namespace Projekt_Reolmarked.ViewModel
{
    public class MainViewModel 
    {
        public ShelfViewModel ShelfViewModel { get; }

        public UserViewModel UserViewModel { get; }


        public MainViewModel(ShelfViewModel shelfViewModel, UserViewModel userViewModel)
        {
            ShelfViewModel = shelfViewModel;
            UserViewModel = userViewModel;
        }

    }
}
