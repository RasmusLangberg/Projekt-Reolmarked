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
        public ObservableCollection<Item> SoldItems { get; } 
        public ObservableCollection<Item> ShoppingBasket { get; } 
        public ItemViewModel ItemViewModel { get; set; }

        public RelayCommand AddItemToBasketCommand { get; }

        public CheckOutViewModel(ItemViewModel itemViewModel)
        {
           
            
            ItemViewModel = itemViewModel;
            
            SoldItems = new ObservableCollection<Item>();

            ShoppingBasket = new ObservableCollection<Item>();

            AddItemToBasketCommand = new RelayCommand(Relay => AddItemToBasket());
            AddItemToBasketCommand = new RelayCommand(Relay => Checkout());

        }

        private void Checkout()
        {
            // her der skal vi implementere checkout logikken. når vi trykker på knappen køb, så skal vi;  fjerne varende fra Items listen i itemviewmodel ( logik herinde). rykke alle item fra shoppign basket over i en liste der hedder solgte varer. 
        }

        public void AddItemToBasket()
        {
            
            if (ItemViewModel.SelectedItem != null)
            {
                ShoppingBasket.Add(ItemViewModel.SelectedItem);
            }
            else
            {
                System.Windows.MessageBox.Show("Vælg venligst et item, før du tilføjer det til indkøbskurven.");
            }
        }

        





    }
}

