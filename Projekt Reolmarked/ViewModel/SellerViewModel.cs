
using Projekt_Reolmarked.Data;
using Projekt_Reolmarked.Model;
using System;
using System.Collections.Generic;
using Projekt_Reolmarked.ViewModel;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.Windows;


namespace Projekt_Reolmarked.ViewModel
{
    public class SellerViewModel : INotifyBase
    {
        public ObservableCollection<Seller> Sellers { get; }

        public ICommand AddSellerCommand { get; }

        public ICommand RemoveSellerCommand { get; }

   
        private readonly ISellerRepository _sellerRepository = new SellerRepository();
        
        
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private int _phoneNumber;

        public int PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }





        private Seller _selectedSeller;

        public Seller SelectedSeller
        {
            get { return _selectedSeller; }
            set
            {
                _selectedSeller = value;
                OnPropertyChanged(nameof(SelectedSeller));
            }
        }


        public SellerViewModel()
        {
            Sellers = new ObservableCollection<Seller>();

            AddSellerCommand = new RelayCommand(parameter => AddSeller());

            RemoveSellerCommand = new RelayCommand(parameter => RemoveSeller());

            LoadUsersFromDatabase();
        }

        public void AddSeller()
        {
            var seller = new Seller(Sellers.Count + 1, FirstName, LastName, Email, PhoneNumber);
         
            _sellerRepository.Add(seller);
            
            Sellers.Add(seller);

        }

        public void RemoveSeller()
        {
            if (SelectedSeller != null)
            {
                _sellerRepository.Delete(SelectedSeller.Id);

                foreach (var shelf in SelectedSeller.OwnedShelves.ToList())
                {
                    shelf.Owner = null;
                    shelf.ShelfStatus = EnumShelfStatus.Ledig;
                }

                Sellers.Remove(SelectedSeller);
                SelectedSeller = null;

            }
            else 
            { 
                MessageBox.Show("Ingen sælger valgt.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }  
        }

        public void LoadUsersFromDatabase()
        {
            foreach (var user in _sellerRepository.GetAll())
            {
                Sellers.Add(user);
            }
        }

    }
}