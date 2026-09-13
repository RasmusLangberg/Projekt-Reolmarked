using Projekt_Reolmarked.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt_Reolmarked.Model
{

    public class Shelf : INotifyBase
    {
        public int Id { get; set; }

        private User? _owner;

        public User? Owner
        {
            get { return _owner; }
            set
            {
                _owner = value;
                OnPropertyChanged(nameof(Owner));
            }
        }

        public EnumShelfType ShelfType { get; set; }

        public int ShelfPrice { get; set; }

        private EnumShelfStatus _shelfStatus;

        public EnumShelfStatus ShelfStatus
        {
            get { return _shelfStatus; }
            set
            {
                _shelfStatus = value;
                OnPropertyChanged(nameof(ShelfStatus));
            }
        }



        public Shelf(int id, User? owner, EnumShelfType shelfType, int shelfPrice, EnumShelfStatus shelfStatus)
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

