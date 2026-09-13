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

        private readonly UserViewModel _userViewModel;

        public ICommand ShowShelfInfoCommand { get; }

        public ICommand AddUserToShelfCommand { get; }

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

        private User _Owner;

        public User Owner
        {
            get { return _Owner; }
            set 
            { _Owner = value; 
                OnPropertyChanged(nameof(Owner));
            }
        }





        public ShelfViewModel(UserViewModel userViewModel)
        {
            Shelves = new ObservableCollection<Shelf>();

            _userViewModel = userViewModel;

            ShowShelfInfoCommand = new RelayCommand(ShowShelfInfo);

            AddUserToShelfCommand = new RelayCommand(parameter =>
            {
                if (SelectedShelf != null &&
                    _userViewModel.SelectedUser != null)
                {
                    AddUserToShelf(
                        _userViewModel.SelectedUser,
                        SelectedShelf);
                }
            });

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
    
      
    
        public void AddUserToShelf(User user, Shelf shelf)
        {
            if (shelf.ShelfStatus == EnumShelfStatus.Ledig)
            {
                shelf.Owner = user;
                shelf.ShelfStatus = EnumShelfStatus.Optaget;
                user.OwnedShelves.Add(shelf);

                OnPropertyChanged(nameof(SelectedShelf));


            }
        }

    }
}
