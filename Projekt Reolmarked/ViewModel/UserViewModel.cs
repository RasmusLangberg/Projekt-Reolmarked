using Projekt_Reolmarked.Model;
using System;
using System.Collections.Generic;
using Projekt_Reolmarked.ViewModel;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Projekt_Reolmarked.ViewModel
{
    public class UserViewModel : INotifyBase
    {
        public ObservableCollection<User> Users {get;}

        public ICommand AddUserCommand { get; }

        public ICommand RemoveUserCommand { get; }


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

        }

        public void AddUser()
        {
            var user = new User(Users.Count + 1, FirstName, LastName, Email, PhoneNumber);
                   
            Users.Add(user);
        }
        
        public void RemoveUser()
        {

        }
    }
}
