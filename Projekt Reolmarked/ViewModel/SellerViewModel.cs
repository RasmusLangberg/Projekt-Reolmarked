
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





        private User _selectedUser;

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }


        public UserViewModel()
        {
            Users = new ObservableCollection<User>();

            AddUserCommand = new RelayCommand(paramter => AddUser());
            RemoveUserCommand = new RelayCommand(paramter => RemoveUser());
            LoadUsersFromDatabase();
        }

        public void AddUser()
        {
            var user = new User(Users.Count + 1, FirstName, LastName, Email, PhoneNumber);
           _userRepository.Add(user);
            Users.Add(user);
        }

        public void RemoveUser()
        {
            if (SelectedUser == null)
            {
                return;
            }
            _userRepository.Delete(SelectedUser.Id);
            
            
            foreach (var shelf in SelectedUser.OwnedShelves.ToList())
            {
                shelf.Owner = null;
                shelf.ShelfStatus = EnumShelfStatus.Ledig;
            }

            Users.Remove(SelectedUser);
            SelectedUser = null;
        }


        public void FakeUsers()
        {
            var user1 = new User(1, "Marie Neega", "Langberg Zarabi", "MNLZ@Proton.com", 70241207);
            var user2 = new User(2, "John Doe", "Smith", "JOHN@Proton.com", 12345678);
            var user3 = new User(3, "Jane Doe", "Johnson", "JANE@Proton.com", 87654321);
            var user4 = new User(4, "Bob Smith", "Williams", "BOB@Proton.com", 11223344);
            Users.Add(user1);
            Users.Add(user2);
            Users.Add(user3);
            Users.Add(user4);
        }
        
       
        public void LoadUsersFromDatabase()
        {
            foreach (var user in _userRepository.GetAll())
            {
                Users.Add(user);
            }
        }

    }
}