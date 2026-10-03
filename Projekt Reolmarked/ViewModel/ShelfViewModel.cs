using Projekt_Reolmarked.Data;
using Projekt_Reolmarked.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Projekt_Reolmarked.ViewModel
{
    public class ShelfManagerViewModel : INotifyBase
    {
        private readonly IShelfRepository _shelfRepository = new ShelfRepository();
        // i stedet for at ObservableCollection<Shelf>, så bruger vi nu ShelfObjectViewModel, som er en wrapper omkring Shelf, der gør det muligt at binde til UI'et. unden at skulle implementere INotifyPropertyChanged i Shelf-klassen. som virker forkert i forhold til MVVM-principperne.?!?
        public ObservableCollection<ShelfObjectViewModel> Shelves { get; }
        private readonly SellerViewModel _userViewModel;


        public ICommand ShowShelfInfoCommand { get; }
        public ICommand AddUserToShelfCommand { get; }
        public ICommand RemoveUserFromShelfCommand { get; }


        public EnumShelfType SelectedShelfType => SelectedShelf?.ShelfType ?? default;
        public string SelectedShelfOwnerName => SelectedShelf?.OwnerName;
        public EnumShelfStatus SelectedShelfStatus => SelectedShelf?.ShelfStatus ?? default;

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

        public ShelfManagerViewModel(SellerViewModel userViewModel)
        {
            Shelves = new ObservableCollection<ShelfObjectViewModel>();

            _userViewModel = userViewModel;

            ShowShelfInfoCommand = new RelayCommand(ShowShelfInfo);

            AddUserToShelfCommand = new RelayCommand(parameter =>
            {
                if (SelectedShelf != null && _userViewModel.SelectedSeller != null)
                {
                    AddUserToShelf(_userViewModel.SelectedSeller, SelectedShelf);
                }
            });

            RemoveUserFromShelfCommand = new RelayCommand(parameter =>
            {
                if (SelectedShelf != null)
                {
                    RemoveUserFromShelf(SelectedShelf);
                }
            });
            
            LoadShelvesFromDatabase();
        }

        private void LoadShelvesFromDatabase()
        {
            var shelves = _shelfRepository.GetAll(_userViewModel.Sellers);

            foreach (var shelf in shelves)
            {
                Shelves.Add(new ShelfObjectViewModel(shelf));

                if (shelf.Owner != null)
                {
                    shelf.Owner.OwnedShelves.Add(shelf);
                }
            }
        }

        public void ShowShelfInfo(object parameter)
        {
            if (parameter is ShelfObjectViewModel SpecificShelfObject)
            {
                SelectedShelf = SpecificShelfObject;
            }
        }

// Generateshelf erstattet med loadfromdatabase, kaldes ikkke kan slettes
        public void GenerateShelfs()
        {
            for (int i = 1; i <= 80; i++)
            {
                if (i % 3 == 0)
                {
                    var shelfModel = new Shelf(i, null, EnumShelfType.HylderOgBøjleStang, 0, EnumShelfStatus.Ledig);
                    Shelves.Add(new ShelfObjectViewModel(shelfModel));
                }
                else
                {
                    var shelfModel = new Shelf(i, null, EnumShelfType.Hylder, 0, EnumShelfStatus.Ledig);
                    Shelves.Add(new ShelfObjectViewModel(shelfModel));
                }
            }
        }

        public static int Bergnpris(int antal)
        {
            if (antal == 1) return 850;
            if (antal == 2 || antal == 3) return 825 * antal;
            return 800 * antal;
        }


        public void AddUserToShelf(Seller seller, ShelfObjectViewModel shelfVm)
        {
            if (shelfVm.ShelfStatus == EnumShelfStatus.Ledig)
            {
                _shelfRepository.UpdateOwner(shelfVm.Id, seller.Id);

                shelfVm.Owner = seller;
                shelfVm.ShelfStatus = EnumShelfStatus.Optaget;

                seller.OwnedShelves.Add(shelfVm.Model);

                ShowShelfInfo(shelfVm);
            }
        }

        public void RemoveUserFromShelf(ShelfObjectViewModel shelfVm)
        {
            _shelfRepository.UpdateOwner(shelfVm.Id, null);
            if (shelfVm.Owner != null)
            {
                shelfVm.Owner.OwnedShelves.Remove(shelfVm.Model);
            }

            shelfVm.Owner = null;
            shelfVm.ShelfStatus = EnumShelfStatus.Ledig;
        }

    }
}

