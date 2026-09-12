using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Reolmarked.Model
{
    public class User
    {

        public int Id = 1;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public List<Shelf> OwnedShelves { get; set; } = new List<Shelf>();


        public User(int id, string firstName, string lastName, string email, int phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            
       }

    }
}
