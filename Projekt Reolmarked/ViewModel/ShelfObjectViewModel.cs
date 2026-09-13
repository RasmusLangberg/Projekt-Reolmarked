using Projekt_Reolmarked.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Projekt_Reolmarked.ViewModel
{
    public class ShelfObjectViewModel : INotifyBase
    {
        public Shelf Model { get; }

        public ShelfObjectViewModel(Shelf shelf)
        {
            Model = shelf;
        }

        public int Id => Model.Id;
        public EnumShelfType ShelfType => Model.ShelfType;

        public EnumShelfStatus ShelfStatus
        {
            get => Model.ShelfStatus;
            set
            {
                if (Model.ShelfStatus != value)
                {
                    Model.ShelfStatus = value;
                    OnPropertyChanged(nameof(ShelfStatus));
                }
            }
        }

        public User? Owner
        {
            get => Model.Owner;
            set
            {
                if (Model.Owner != value)
                {
                    Model.Owner = value;
                    OnPropertyChanged(nameof(Owner));
                    OnPropertyChanged(nameof(OwnerName));
                }
            }
        }

        public string OwnerName => Owner?.FirstName ?? "Ingen ejer";
    }

    
    
}
