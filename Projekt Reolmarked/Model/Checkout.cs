using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Reolmarked.Model
{
    public class Checkout
    {

        public List<Item> ShoppingCart {  get; set; }

        public List<Item> SoldItems { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return ShoppingCart.Sum(i => i.Price); 
            }
           
        }

        public DateOnly SalesDate { get; set; } 


        public Checkout(List<Item> kurv, List<Item> solgtevare)
        {
            ShoppingCart = kurv;
            SoldItems = solgtevare;
            SalesDate = new DateOnly();

        }
    }
}
