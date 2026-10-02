using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Reolmarked.Model
{
    public class Checkout
    {

        public List<Item> ShoppingCart {  get; set; }

        public List<Item> SoldItems { get; set; }

        public int TotalPrice { get; set; }

        public DateOnly SalesDate { get; set; } 


        public Checkout(List<Item> kurv, List<Item> solgtevare,int totalprice)
        {
            ShoppingCart = kurv;
            SoldItems = solgtevare;
            TotalPrice = totalprice;
            SalesDate = new DateOnly();

        }
    }
}
