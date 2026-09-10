using System;
using System.Collections.Generic;
using System.Printing;
using System.Text;

namespace Projekt_Reolmarked.ViewModel
{
    public class MainViewModel 
    {
        private readonly ShelfViewModel _shelfViewModel;

        private readonly UserViewModel _userViewModel;


        public MainViewModel(ShelfViewModel shelfViewModel, UserViewModel userViewModel)
        {
            _shelfViewModel = shelfViewModel;
            _userViewModel = userViewModel;
        }

    }
}
