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
    public class ShelfManagerViewModel : INotifyBase
    {
        // ÆNDRET: Samlingen indeholder nu ShelfItemViewModel
        public ObservableCollection<ShelfObjectViewModel> Shelves { get; }

        private readonly UserViewModel _userViewModel;

        public ICommand ShowShelfInfoCommand { get; }
        public ICommand AddUserToShelfCommand { get; }
        public ICommand RemoveUserFromShelfCommand { get; }

        public EnumShelfType SelectedShelfType => SelectedShelf?.ShelfType ?? default;
        public string SelectedShelfOwnerName => SelectedShelf?.OwnerName;
        public EnumShelfStatus SelectedShelfStatus => SelectedShelf?.ShelfStatus ?? default;

        // ÆNDRET: Type ændret fra Shelf til ShelfItemViewModel
        private ShelfObjectViewModel _selectedShelf;

        public ShelfObjectViewModel SelectedShelf
        {
            get { return _selectedShelf; }
            set
            {
                _selectedShelf = value;
                OnPropertyChanged(nameof(SelectedShelf));
                OnPropertyChanged(nameof(SelectedShelfType));
                OnPropertyChanged(nameof(SelectedShelfOwnerName));
                OnPropertyChanged(nameof(SelectedShelfStatus));
            }
        }

        public ShelfManagerViewModel(UserViewModel userViewModel)
        {
            Shelves = new ObservableCollection<ShelfObjectViewModel>();
            
            _userViewModel = userViewModel;

            ShowShelfInfoCommand = new RelayCommand(ShowShelfInfo);

            AddUserToShelfCommand = new RelayCommand(parameter =>
            {
                if (SelectedShelf != null && _userViewModel.SelectedUser != null)
                {
                    AddUserToShelf(_userViewModel.SelectedUser, SelectedShelf);
                }
            });

            RemoveUserFromShelfCommand = new RelayCommand(parameter =>
            {
                if (SelectedShelf != null)
                {
                    RemoveUserFromShelf(SelectedShelf);
                }
            });

            GenerateShelfs();
        }

       
        public void ShowShelfInfo(object parameter)
        {
            if (parameter is ShelfObjectViewModel shelfVm)
            {
                SelectedShelf = shelfVm;
            }
        }

       
        public void GenerateShelfs()
        {
            for (int i = 1; i <= 80; i++)
            {
                var type = (i % 3 == 0) ? EnumShelfType.HylderOgBøjleStang : EnumShelfType.Hylder;
                var shelfModel = new Shelf(i, null, type, 0, EnumShelfStatus.Ledig);

                Shelves.Add(new ShelfObjectViewModel(shelfModel));
            }
        }

        public static int Bergnpris(int antal)
        {
            if (antal == 1) return 850;
            if (antal == 2 || antal == 3) return 825 * antal;
            return 800 * antal;
        }

        
        public void AddUserToShelf(User user, ShelfObjectViewModel shelfVm)
        {
            if (shelfVm.ShelfStatus == EnumShelfStatus.Ledig)
            {
                shelfVm.Owner = user;
                shelfVm.ShelfStatus = EnumShelfStatus.Optaget;
                user.OwnedShelves.Add(shelfVm.Model);

                ShowShelfInfo(shelfVm);
            }
        }

        
        public void RemoveUserFromShelf(ShelfObjectViewModel shelfVm)
        {
            if (shelfVm.ShelfStatus == EnumShelfStatus.Optaget)
            {
                shelfVm.Owner?.OwnedShelves.Remove(shelfVm.Model);
                shelfVm.Owner = null;
                shelfVm.ShelfStatus = EnumShelfStatus.Ledig;

                ShowShelfInfo(shelfVm);
            }
        }
    }
}

