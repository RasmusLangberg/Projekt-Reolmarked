using Projekt_Reolmarked.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Projekt_Reolmarked.ViewModel
{
    public class ItemListViewModel
    {
        public ObservableCollection<Item> Items { get; }

        public ItemListViewModel()
        {
            Items = new ObservableCollection<Item>();                   
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }
    }
}
