using Projekt_Reolmarked.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Projekt_Reolmarked
{
    public class CheckOutViewModel
    {
        

        public ObservableCollection<Item> Items { get; set; }

        public CheckOutViewModel(ObservableCollection<Item> items)
        {
            Items = items;
        }
    }
}
