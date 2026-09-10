using Projekt_Reolmarked.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Projekt_Reolmarked.ViewModel
{
   public class ShelfViewModel
    {

        public ObservableCollection<Shelf> Shelves { get; } = new ObservableCollection<Shelf>();


        Shelf shelf = new Shelf();

    }
}
