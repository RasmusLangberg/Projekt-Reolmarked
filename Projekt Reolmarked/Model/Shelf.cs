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

        public int ShelfPrice { get; set; } = 150;

        public ShelfStatus ShelfStatus { get; set; }



        public Shelf(int id, string description, ShelfType shelfType, int shelfPrice, ShelfStatus shelfStatus)
        {
            Id = id;
            Description = description;
            ShelfType = shelfType;
            ShelfPrice = shelfPrice;
            ShelfStatus = shelfStatus;
        }





    }
}
