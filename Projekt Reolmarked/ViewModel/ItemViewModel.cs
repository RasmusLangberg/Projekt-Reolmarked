using Projekt_Reolmarked.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Projekt_Reolmarked.ViewModel
{
    public class ItemViewModel : INotifyBase
    {
        public ObservableCollection<Item> Items { get; }

        public SellerViewModel SellerViewModel { get; }
        private int nextID = 1;

        public ICommand AddItemCommand { get; }

        public ItemViewModel(SellerViewModel sellerViewModel)
        {
            SellerViewModel = sellerViewModel;

            Items = new ObservableCollection<Item>();
           
            AddItemCommand = new RelayCommand(parameter => AddItem());
        }


        private void AddItem()
        {

            var ItemId = GenerateID();

            Item newItem = new Item(Name, SellerViewModel.SelectedSeller, ItemId, Price);
          
            Items.Add(newItem);

            MessageBox.Show($"Item '{newItem.Name}' added successfully with ID: {newItem.ItemId}");
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value; 
                OnPropertyChanged(nameof(Name));
            }
        }


       
        private double _price;
        public double Price
        {
            get { return _price; }
            set 
            { 
                _price = value; 
                OnPropertyChanged(nameof(Price));
            }
        }

       
       public int GenerateID()
        {
            return nextID++;
        }
        


    }
}
