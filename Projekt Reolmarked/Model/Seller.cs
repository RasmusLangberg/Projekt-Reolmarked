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

        }


    }
}
