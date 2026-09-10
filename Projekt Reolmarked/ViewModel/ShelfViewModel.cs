using Projekt_Reolmarked.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Projekt_Reolmarked.ViewModel
{
   public class ShelfViewModel : INotifyBase
    {

    
        public ObservableCollection<Shelf> Shelves { get; } 



        public ShelfViewModel()
        {
            Shelves = new ObservableCollection<Shelf>();


            for(int i = 1; i <= 80; i++)
            {
                if(i % 3 == 0)
                {
                    var shelf = new Shelf(i, EnumShelfType.HylderMedBøjleStang, 0, EnumShelfStatus.Available);
                    Shelves.Add(shelf);
                }
                else
                {
                    var shelf = new Shelf(i, EnumShelfType.Hylder, 0, EnumShelfStatus.Available);
                    Shelves.Add(shelf);
                }

            }

        }





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
    
        public void AddShelves()
        {

        }
    
    
    }
}
