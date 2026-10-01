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
        
        MainViewModel MainViewModel { get; }

        public RelayCommand AddItemToBasketCommand { get; }

        public RelayCommand SellItemCommand { get; }



        public CheckOutViewModel(MainViewModel mainViewModel)
        {
           
            SoldItems = new ObservableCollection<Item>();

            ShoppingBasket = new ObservableCollection<Item>();

            MainViewModel = mainViewModel;

            AddItemToBasketCommand = new RelayCommand(_ => AddItemToBasket());

            SellItemCommand = new RelayCommand(parameter => Checkout());

        }

        private void Checkout()
        {
            // her der skal vi implementere checkout logikken. når vi trykker på knappen køb, så skal vi;  fjerne varende fra Items listen i itemviewmodel ( logik herinde). rykke alle item fra shoppign basket over i en liste der hedder solgte varer. 
        }

        public void AddItemToBasket()
        {
            var item = MainViewModel.ItemViewModel.SelectedItem;
            
            if (item!= null)
                ShoppingBasket.Add(item);
            MessageBox.Show("vare tilføjet");

        }

        





    }
}

