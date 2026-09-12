using Projekt_Reolmarked.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Input;

namespace Projekt_Reolmarked.ViewModel
{
   public class ShelfViewModel : INotifyBase
    {

    
        public ObservableCollection<Shelf> Shelves { get; } 

        public ICommand ShowShelfInfoCommand { get; }


        private Shelf _selectedShelf;

        public Shelf SelectedShelf
        {
            get { return _selectedShelf; }
            set 
            { 
                _selectedShelf = value; 
                OnPropertyChanged(nameof(SelectedShelf));
            }
        }





        public ShelfViewModel()
        {
            Shelves = new ObservableCollection<Shelf>();

            ShowShelfInfoCommand = new RelayCommand(ShowShelfInfo);

            GenerateShelfs();
    

        }

        public void ShowShelfInfo(object parameter)
        {
            if (parameter is Shelf shelf)
            {
                SelectedShelf = shelf;
            }
        }



        public void GenerateShelfs()
        {
            for (int i = 1; i <= 80; i++)
            {
                if (i % 3 == 0) // hver 3. hylde har en bøjle stang
                {
                    var shelf = new Shelf(i, null, EnumShelfType.HylderOgBøjleStang, 0, EnumShelfStatus.Ledig);
                    Shelves.Add(shelf);
                }
                else
                {
                    var shelf = new Shelf(i, null, EnumShelfType.Hylder, 0, EnumShelfStatus.Ledig);
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
