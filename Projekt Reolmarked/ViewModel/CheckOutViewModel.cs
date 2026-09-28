using Projekt_Reolmarked.Model;
using Projekt_Reolmarked.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Projekt_Reolmarked
{
    public class CheckOutViewModel 
    {
        public ObservableCollection<Item> SoldItems { get; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> ShoppingBasket { get; } = new ObservableCollection<Item>();
        public Item SelectedItem { get; set; }

        public RelayCommand AddItemToBasketCommand { get; }

        public CheckOutViewModel(ObservableCollection<Item> items)
        {
            Items = items;

            AddItemToBasketCommand = new RelayCommand(_ => AddItemToBasket());
        }

        private void Checkout()
        {
            // her der skal vi implementere checkout logikken. når vi trykker på knappen køb, så skal vi;  fjerne varende fra Items listen i itemviewmodel ( logik herinde). rykke alle item fra shoppign basket over i en liste der hedder solgte varer. 
        }

        public void AddItemToBasket()
        {
            //implementer at checkout logikken her.du skal bruge selecteditem fra itemviewmodel og tilføje den til shoppingbasket. listboxen i checkout skal være binded til Selecteditemn fra itemviewmode. ( binding ItemViewModel.SelectedItem).
            if (SelectedItem != null)
                ShoppingBasket.Add(SelectedItem);
        }

        





    }
}

