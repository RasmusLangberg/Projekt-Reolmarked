using Projekt_Reolmarked.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Projekt_Reolmarked.ViewModel
{
    public class ItemViewModel : INotifyBase
    {
        private Item _item;
        private ItemListViewModel _itemListViewModel;

        public ICommand AddItemCommand { get; }

        public ItemViewModel(Item item, ItemListViewModel itemListViewModel)
        {
            _item = item;
            _itemListViewModel = itemListViewModel;
            AddItemCommand = new RelayCommand(AddItem);
        }

        private void AddItem()
        {
            AddItem(_itemListViewModel);
        }

        private void AddItem(ItemListViewModel _itemListViewModel1)
        {

            
            Item newItem = new Item(Name, Seller, ItemId, Price);
            _itemListViewModel1.Items.Add(newItem);
        }

        public string Name
        {
            get { return _item.Name; }
            set
            {
                if (_item.Name != value)
                {
                    _item.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public int ItemId
        {
            get { return _item.ItemId; }
            set
            {
                if (_item.ItemId != value)
                {
                    _item.ItemId = value;
                    OnPropertyChanged(nameof(ItemId));
                }
            }
        }

        public double Price
        {
            get { return _item.Price; }
            set
            {
                if (_item.Price != value)
                {
                    _item.Price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        public Seller Seller
        {
            get { return _item.Seller; }
            set
            {
                if (_item.Seller != value)
                {
                    _item.Seller = value;
                    OnPropertyChanged(nameof(Seller));
                }
            }
        }

        public string SellerName
        {
            get { return $"{_item.Seller.FirstName} {_item.Seller.LastName}"; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
