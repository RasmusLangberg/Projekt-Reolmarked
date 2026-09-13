using Projekt_Reolmarked.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Reolmarked.Model
{
    public class Shelf : INotifyBase
    {

       
        public int Id { get; set; }

        public User? Owner { get; set; }

        public EnumShelfType ShelfType { get; set; }

        public int ShelfPrice { get; set; }

        public EnumShelfStatus ShelfStatus { get; set; }



        public Shelf(int id, User? owner, EnumShelfType shelfType, int shelfPrice, EnumShelfStatus shelfStatus)
        {
            Id = id;
            Owner = new User(owner?.Id ?? 0, owner?.FirstName ?? "Ingen ejer", owner?.LastName ?? "", owner?.Email ?? "", owner?.PhoneNumber ?? 0);
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
