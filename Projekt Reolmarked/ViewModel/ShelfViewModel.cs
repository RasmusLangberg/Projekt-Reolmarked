using Projekt_Reolmarked.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Projekt_Reolmarked.ViewModel
{
   public class ShelfViewModel : INotifyBase
    {

        public ObservableCollection<Shelf> Shelves { get; } = new ObservableCollection<Shelf>();


        





        public int Bergnpris(int antal)
        {

            if(antal == 1)
            {
                return 850;
            }
            else if(antal == 2 || antal == 3)
            {
                return 825*antal;
            }
            else
            {
                return 800*antal;
            }

        }
    }
}
