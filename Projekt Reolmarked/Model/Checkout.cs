using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Reolmarked.Model
{
    public class Checkout
    {

        public List<Item> Indkøbskurv {  get; set; }

        public List<Item> SolgteVare { get; set; }

        public int TotalPrice { get; set; }

        public DateOnly SalesDate { get; set; } 


        public Checkout(List<Item> kurv, List<Item> solgtevare,int totalprice)
        {
            Indkøbskurv = kurv;
            SolgteVare = solgtevare;
            TotalPrice = totalprice;
            SalesDate = new DateOnly();

        }
    }
}
