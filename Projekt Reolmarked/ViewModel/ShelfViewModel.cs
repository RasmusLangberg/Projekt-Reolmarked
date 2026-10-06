using Microsoft.Identity.Client;
using Projekt_Reolmarked.Data;
using Projekt_Reolmarked.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Projekt_Reolmarked.ViewModel
{
    public class ShelfManagerViewModel : INotifyBase
    {
        private readonly IShelfRepository _shelfRepository = new ShelfRepository();
        // i stedet for at ObservableCollection<Shelf>, så bruger vi nu ShelfObjectViewModel, som er en wrapper omkring Shelf, der gør det muligt at binde til UI'et. unden at skulle implementere INotifyPropertyChanged i Shelf-klassen. som virker forkert i forhold til MVVM-principperne.?!? kan en lære uddybe hvordan man på en smart måde ændre en objekt i wpfs imens programmet kører
        public ObservableCollection<ShelfObjectViewModel> Shelves { get; }
        private readonly SellerViewModel _userViewModel;


        public ICommand ShowShelfInfoCommand { get; }
        public ICommand AddUserToShelfCommand { get; }
        public ICommand RemoveUserFromShelfCommand { get; }
        public ICommand CancelShelfCommand { get; }


        public EnumShelfType SelectedShelfType => SelectedShelf?.ShelfType ?? default;
        public string SelectedShelfOwnerName => SelectedShelf?.OwnerName;
        public EnumShelfStatus SelectedShelfStatus => SelectedShelf?.ShelfStatus ?? default;

        public DateTime? SelectedShelfCancellationDate =>
        SelectedShelf?.Model.CancellationDate;

        public DateTime? SelectedShelfCancellationEffectiveDate =>
            SelectedShelf?.Model.CancellationEffectiveDate;

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
                OnPropertyChanged(nameof(SelectedShelfCancellationDate));
                OnPropertyChanged(nameof(SelectedShelfCancellationEffectiveDate));
            }
        }

        public ShelfManagerViewModel(SellerViewModel userViewModel)
        {
            Shelves = new ObservableCollection<ShelfObjectViewModel>();

            _userViewModel = userViewModel;

            ShowShelfInfoCommand = new RelayCommand(ShowShelfInfo);

            AddUserToShelfCommand = new RelayCommand(parameter => AddUserToShelf(_userViewModel.SelectedSeller, SelectedShelf));

            RemoveUserFromShelfCommand = new RelayCommand(parameter => RemoveUserFromShelf(SelectedShelf));

            CancelShelfCommand = new RelayCommand(parameter => CancelShelf(SelectedShelf));

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



        public void AddUserToShelf(Seller seller, ShelfObjectViewModel shelfVm)
        {
            if (SelectedShelf != null && _userViewModel.SelectedSeller != null && shelfVm.ShelfStatus == EnumShelfStatus.Ledig)
            {
              
                    _shelfRepository.UpdateOwner(shelfVm.Id, seller.Id);

                    shelfVm.Owner = seller;

                    shelfVm.ShelfStatus = EnumShelfStatus.Optaget;

                    seller.OwnedShelves.Add(shelfVm.Model);

                    ShowShelfInfo(shelfVm);

            } 
            else if (shelfVm.ShelfStatus == EnumShelfStatus.Optaget)
            {
                MessageBox.Show("Hylden er allerede optaget.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Ingen ejer valgt.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void RemoveUserFromShelf(ShelfObjectViewModel shelfVm)
        {
            if (SelectedShelf != null && shelfVm.Owner != null)
            {

                _shelfRepository.UpdateOwner(shelfVm.Id, null);

                shelfVm.Owner.OwnedShelves.Remove(shelfVm.Model);

                shelfVm.Owner = null;

                shelfVm.ShelfStatus = EnumShelfStatus.Ledig;

            }
            else
            {
                MessageBox.Show("Ingen ejer tilknyttet hylden.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


           public void CancelShelf(ShelfObjectViewModel shelfVm)
        {
            if (SelectedShelf != null && shelfVm.Owner != null)
            {
                DateTime cancellationDate = DateTime.Now;
                shelfVm.Model.CancellationDate = DateTime.Now;
                shelfVm.UpdateCancellationStatus();
               
                if (cancellationDate.Day < 20)
                {
                    shelfVm.Model.CancellationEffectiveDate = new DateTime(
                        cancellationDate.Year, 
                        cancellationDate.Month,
                        1).AddMonths(1);
                }
                _shelfRepository.UpdateCancellation(
                    shelfVm.Id,
                    shelfVm.Model.CancellationDate,
                    shelfVm.Model.CancellationEffectiveDate);
                MessageBox.Show(
                    $"Reolen er opsagt. Den bliver ledig fra {shelfVm.Model.CancellationEffectiveDate:dd-MM-yyyy}.",
                    "Reol opsagt",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);


            }
            else
            {
                MessageBox.Show("Ingen ejer tilknyttet reolen.", 
                    "Fejl",
                    MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        
        
    }
}

    