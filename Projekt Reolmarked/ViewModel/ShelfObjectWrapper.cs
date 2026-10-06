using Projekt_Reolmarked.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Projekt_Reolmarked.ViewModel
{
    public class ShelfObjectViewModel : INotifyBase
    {

        // denne klasse er en wrapper omkring Shelf-klassen. ligsom gavepapir om en gave, der gør det muligt at binde Shelf-objekter til UI-komponenter i WPF.
        // man gør det for at implementere INotifyPropertyChanged, som Shelf-klassen ikke gør efter MVVM?!? her må lære gerne uddybe, jeg har ikke helt forstået hvorfor,
     


        public Shelf Model { get; }

        public ShelfObjectViewModel(Shelf shelf)
        {
            Model = shelf;
        }
        public void UpdateCancellationStatus()
        {
            OnPropertyChanged(nameof(IsCancelled));
        }

        public int Id => Model.Id;
        public EnumShelfType ShelfType => Model.ShelfType;

        public bool IsCancelled
        {
            get
            {
                return Model.CancellationDate != null;  
            }
        }


        

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

        public Seller? Owner
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
        public string OwnerName => Owner != null ? $"{Owner.FirstName} {Owner.LastName}" : "Ingen ejer";
    }



    
}
