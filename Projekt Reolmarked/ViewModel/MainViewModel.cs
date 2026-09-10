using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Reolmarked.ViewModel
{
    public class MainViewModel
    {
        private readonly ShelfViewModel _shelfViewModel;


        public MainViewModel(ShelfViewModel shelfViewModel)
        {
            _shelfViewModel = shelfViewModel;
        }

    }
}
