using Projekt_Reolmarked.Model;
using Projekt_Reolmarked.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace Projekt_Reolmarked
{
    public class CheckOutViewModel
    {
        public ObservableCollection<Item> SoldItems { get; }

        public ObservableCollection<Item> ShoppingBasket { get; }

        public ItemViewModel ItemViewModel { get; }

        public RelayCommand AddItemToBasketCommand { get; }

        public RelayCommand SellItemCommand { get; }

        public RelayCommand ClearBasketCommand { get; } 

        public CheckOutViewModel(ItemViewModel itemViewModel)
        {
            SoldItems = new ObservableCollection<Item>();

            ShoppingBasket = new ObservableCollection<Item>();

            ItemViewModel = itemViewModel;

            AddItemToBasketCommand = new RelayCommand(_ => AddItemToBasket());

            SellItemCommand = new RelayCommand(parameter => Checkout());

            ClearBasketCommand = new RelayCommand(_ => ClearBasket());

        }

        


        private void Checkout()
        {
            // Her skal vi senere implementere checkout-logikken.
        }

        public void ClearBasket()
        {

            if (ShoppingBasket.Count > 0)
            {
                ShoppingBasket.Clear();
                MessageBox.Show("Kurven er blevet ryddet.");
            }
            else 
            { 
                MessageBox.Show("Kurven er allerede tom.");
            }
        
        }

        public void AddItemToBasket()
        {
            var item = ItemViewModel.SelectedItem;

            if (item != null)
            {
                ShoppingBasket.Add(item);
                MessageBox.Show("Vare tilføjet");
            }
            else
            {
                MessageBox.Show("Ingen vare valgt");
            }
        
        
        }
    }
}
