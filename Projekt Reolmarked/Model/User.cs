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

        public int MonthlyPayment { get; set; }


        public User(int id, string firstName, string lastName, string email, int phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            MonthlyPayment = 0;
        }


        public override string ToString()
        {
            return $"User ID: {Id}, Name: {FirstName} {LastName}, Email: {Email}, Phone: {PhoneNumber}, Monthly Payment: {MonthlyPayment}";
        }

   
        public void CalculateMonthlyPayment() // lav bergning på bergning af månedlig betaling 
        {
            int numberOfShelves = OwnedShelves.Count;

            if (numberOfShelves == 1)
            {
                MonthlyPayment = 850;
            }

            else if (numberOfShelves >= 2 && numberOfShelves <= 3)
            {
                MonthlyPayment = numberOfShelves * 825;
            }

            else if (numberOfShelves >= 4)
            {
                MonthlyPayment = numberOfShelves * 800;
            }
            else MonthlyPayment = 0;
        }


    }
}
