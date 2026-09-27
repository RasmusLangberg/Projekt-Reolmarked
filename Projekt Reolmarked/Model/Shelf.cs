namespace Projekt_Reolmarked.Model
{

    public class Shelf
    {
        public int Id { get; set; }
        public Seller? Owner { get; set; }
        public EnumShelfType ShelfType { get; set; }
        public int ShelfPrice = 850;
        public EnumShelfStatus ShelfStatus { get; set; }

        public Shelf(int id, Seller? owner, EnumShelfType shelfType, int shelfPrice, EnumShelfStatus shelfStatus)
        {
            Id = id;
            Owner = owner;
            ShelfType = shelfType;
            ShelfPrice = shelfPrice;
            ShelfStatus = shelfStatus;
        }

        public override string ToString()
        {
            return $"Shelf ID: {Id}, Type: {ShelfType}, Price: {ShelfPrice}, Status: {ShelfStatus}";
        }



    }
}

