using Microsoft.Identity.Client;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Projekt_Reolmarked.Model
{
    public class Seller
    {

        public int Id = 1;

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public List<Shelf> OwnedShelves { get; set; } = new List<Shelf>();

        public int MonthlyPayment { get; set; }


        public Seller(int id, string firstName, string lastName, string email, int phoneNumber)
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
            return $"Seller ID: {Id}, Name: {FirstName} {LastName}, Email: {Email}, Phone: {PhoneNumber}, Monthly Payment: {MonthlyPayment}";
        }


        public void CalculateMonthlyPayment() // lav bergning på bergning af månedlig betaling 
        {
            int numberOfShelves = OwnedShelves.Count;

            if (numberOfShelves == 0)
            {
                MonthlyPayment = 0;
            }

            else if (numberOfShelves == 1)
            {
                MonthlyPayment = 850;
            }

            else if (numberOfShelves <= 3)
            {
                MonthlyPayment = 825 * numberOfShelves;
            }

            else
            {
                MonthlyPayment = 800 * numberOfShelves;

            }

         

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
