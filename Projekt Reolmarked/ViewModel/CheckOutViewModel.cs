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
        
        public ItemViewModel ItemViewModel { get; }



        public RelayCommand AddItemToBasketCommand { get; }

        public RelayCommand SellItemCommand { get; }

        public CheckOutViewModel(ItemViewModel itemvietmodel)
        {
           
            ItemViewModel = itemvietmodel;
            AddItemToBasketCommand = new RelayCommand(_ => AddItemToBasket());
            SellItemCommand = new RelayCommand(parameter => Checkout());
        }

        private void Checkout()
        {
            // her der skal vi implementere checkout logikken. når vi trykker på knappen køb, så skal vi;  fjerne varende fra Items listen i itemviewmodel ( logik herinde). rykke alle item fra shoppign basket over i en liste der hedder solgte varer. 
        }

        public void AddItemToBasket()
        {
            //implementer at checkout logikken her.du skal bruge selecteditem fra itemviewmodel og tilføje den til shoppingbasket. listboxen i checkout skal være binded til Selecteditemn fra itemviewmode. ( binding ItemViewModel.SelectedItem).
            if (ItemViewModel.SelectedItem!= null)
                ShoppingBasket.Add(ItemViewModel.SelectedItem);
        }

        





    }
}

