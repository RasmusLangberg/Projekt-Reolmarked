using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Reolmarked.Model
{
    public class Shelf
    {

       
        public int Id { get; set; }

        public string Description { get; set; }

        public ShelfType ShelfType { get; set; }

        public ShelfPrice ShelfPrice { get; set; }

        public ShelfStatus ShelfStatus { get; set; }



        public Shelf(int id, string description, ShelfType shelfType, ShelfPrice shelfPrice, ShelfStatus shelfStatus)
        {
            Id = id;
            Description = description;
            ShelfType = shelfType;
            ShelfPrice = shelfPrice;
            ShelfStatus = shelfStatus;
        }





    }
}
