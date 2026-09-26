using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Reolmarked.Model
{
    public class Item
    {
        public string Name { get; set; }

        public int ItemId { get; set; }
        public User Seller { get; set; }

        public double Price { get; set; }
        
        public Item(string name, User seller, int itemId, double price)
        {
            Name = name;
            ItemId = itemId;
            Seller = seller;            
            Price = price;
        }

        public override string ToString()
        {
            return $"Item: {Name}, Price: {Price}, Seller: {Seller.FirstName} {Seller.LastName}";
        }
    }
}
