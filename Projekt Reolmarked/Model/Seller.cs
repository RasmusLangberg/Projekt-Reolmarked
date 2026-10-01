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

        public int MonthlyPayment
        {
            get
            {
                int numberOfShelves = OwnedShelves.Count;

                if (numberOfShelves == 0)
                {
                    return 0;
                }
                else if (numberOfShelves == 1)
                {
                    return 850;
                }
                else if (numberOfShelves <= 3)
                {
                    return 825 * numberOfShelves;
                }
                else
                {
                    return 800 * numberOfShelves;
                }
            }
        }


        public Seller(int id, string firstName, string lastName, string email, int phoneNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            
        }


        public override string ToString()
        {
            return $"Seller ID: {Id}, Name: {FirstName} {LastName}, Email: {Email}, Phone: {PhoneNumber}, Monthly Payment: {MonthlyPayment}";
        }


    

        

    }
}
