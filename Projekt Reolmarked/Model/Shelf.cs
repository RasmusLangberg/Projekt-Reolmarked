using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Reolmarked.Model
{
    public class Shelf
    {

       
        public int Id { get; set; }

       

        public EnumShelfType ShelfType { get; set; }

        public int ShelfPrice { get; set; }

        public EnumShelfStatus ShelfStatus { get; set; }



        public Shelf(int id,  EnumShelfType shelfType, int shelfPrice, EnumShelfStatus shelfStatus)
        {
            Id = id;
            ShelfType = shelfType;
            ShelfPrice = shelfPrice;
            ShelfStatus = shelfStatus;
        }





    }
}
