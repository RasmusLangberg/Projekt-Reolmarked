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
    public class CheckOutViewModel : INotifyBase
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

        public decimal TotalPrice => ShoppingBasket.Sum(item => item.Price);


        private void Checkout()
        {
           
            if (ShoppingBasket.Count != 0)
            {
                
                ShoppingBasket.ToList().ForEach(item => item.Seller.MonthlyEarnings.Add(item.Price));
                
                

                foreach (var item in ShoppingBasket)
                {
                    ItemViewModel.MarkAsSold(item);
                    SoldItems.Add(item);
                }

                ShoppingBasket.Clear();
                OnPropertyChanged(nameof(TotalPrice));
           
            }
            else
            {
                MessageBox.Show("Kurven er tom. Tilføj venligst varer til kurven, før du gennemfører købet.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
       
        }

        public void ClearBasket()
        {

            if (ShoppingBasket.Count > 0)
            {
                ShoppingBasket.Clear();
                OnPropertyChanged(nameof(TotalPrice));
                MessageBox.Show("Kurven er blevet ryddet", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else  
            { 
                MessageBox.Show("Kurven er allerede tom.", "Information", MessageBoxButton.OK );
                
            }
        
        }

        public void AddItemToBasket()
        {
            var item = ItemViewModel.SelectedItem;

            if (item != null)
            {
                ShoppingBasket.Add(item);
                OnPropertyChanged(nameof(TotalPrice));
                
            }
            else
            {
                MessageBox.Show("Ingen vare valgt", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        
        
        }
    }
}
