
using Projekt_Reolmarked.Data;
using Projekt_Reolmarked.Model;
using System;
using System.Collections.Generic;
using Projekt_Reolmarked.ViewModel;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;


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
            if (SelectedSeller == null)
            {
                return;
            }
            _sellerRepository.Delete(SelectedSeller.Id);
            
            
            foreach (var shelf in SelectedSeller.OwnedShelves.ToList())
            {
                shelf.Owner = null;
                shelf.ShelfStatus = EnumShelfStatus.Ledig;
            }

            Sellers.Remove(SelectedSeller);
            SelectedSeller = null;
        }


        public void FakeUsers()
        {
            var user1 = new Seller(1, "Marie Neega", "Langberg Zarabi", "MNLZ@Proton.com", 70241207);
            var user2 = new Seller(2, "John Doe", "Smith", "JOHN@Proton.com", 12345678);
            var user3 = new Seller(3, "Jane Doe", "Johnson", "JANE@Proton.com", 87654321);
            var user4 = new Seller(4, "Bob Smith", "Williams", "BOB@Proton.com", 11223344);
            Sellers.Add(user1);
            Sellers.Add(user2);
            Sellers.Add(user3);
            Sellers.Add(user4);
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