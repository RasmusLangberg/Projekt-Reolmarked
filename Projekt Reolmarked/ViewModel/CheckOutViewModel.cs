using Projekt_Reolmarked.Model;
using Projekt_Reolmarked.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Projekt_Reolmarked
{
    public class CheckOutViewModel
    {
        

        public ObservableCollection<Item>  ShoppingBasket  { get; set; }

        public ObservableCollection<Item> SoldItems { get; set; } 
        public ItemViewModel ItemViewModel { get; set; }

        public RelayCommand CheckoutCommand { get; set; }

        public RelayCommand AddItemToBasketCommand { get; set; }

        public CheckOutViewModel(ObservableCollection<Item> shoppingBasket, RelayCommand addItemToBasket, ItemViewModel itemViewModel)
        {
            ShoppingBasket = shoppingBasket;
            SoldItems = new ObservableCollection<Item>();
            CheckoutCommand = new RelayCommand(parameter => Checkout());
            AddItemToBasketCommand = new RelayCommand(parameter => AddItemToBasket());
            ItemViewModel = itemViewModel;

        }

        private void Checkout()
        {
            // her der skal vi implementere checkout logikken. når vi trykker på knappen køb, så skal vi;  fjerne varende fra Items listen i itemviewmodel ( logik herinde). rykke alle item fra shoppign basket over i en liste der hedder solgte varer. 
        }

        public void AddItemToBasket()
        {
            //implementer at checkout logikken her.du skal bruge selecteditem fra itemviewmodel og tilføje den til shoppingbasket. listboxen i checkout skal være binded til Selecteditemn fra itemviewmode. ( binding ItemViewModel.SelectedItem).
        }







    }
}

