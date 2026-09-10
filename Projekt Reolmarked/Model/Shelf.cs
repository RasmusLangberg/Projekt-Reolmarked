using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Reolmarked.Model
{
    public class Shelf
    {

       
        public int Id { get; set; }

        public string Description { get; set; }

        public EnumShelfType ShelfType { get; set; }

        public int ShelfPrice { get; set; }

        public EnumShelfStatus ShelfStatus { get; set; }



        public Shelf(int id, string description, EnumShelfType shelfType, int shelfPrice, EnumShelfStatus shelfStatus)
        {
            Id = id;
            Description = description;
            ShelfType = shelfType;
            ShelfPrice = shelfPrice;
            ShelfStatus = shelfStatus;
        }





    }
}
