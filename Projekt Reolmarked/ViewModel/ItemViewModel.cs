using Projekt_Reolmarked.Model;
using Projekt_Reolmarked.data;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Projekt_Reolmarked.ViewModel
{
    public class ItemViewModel : INotifyBase
    {
        public ObservableCollection<Item> Items { get; }

        public ICommand AddItemCommand { get; }

        private readonly IItemRepository _itemRepository =
            new ItemRepository();

        public SellerViewModel SellerViewModel { get; }

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

        private Item _selectedItem;

        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ItemViewModel(SellerViewModel sellerViewModel)
        {
            SellerViewModel = sellerViewModel;

            Items = new ObservableCollection<Item>();

            AddItemCommand =
                new RelayCommand(parameter => AddItem());

            LoadItemsFromDatabase();
        }

        public void AddItem()
        {
            if (SellerViewModel.SelectedSeller == null)
            {
                MessageBox.Show("Vælg først en sælger.");
                return;
            }

            var item = new Item(
                Name,
                SellerViewModel.SelectedSeller,
                Items.Count + 1,
                Price);

            _itemRepository.add(item);

            Items.Add(item);

            MessageBox.Show(
                $"Varen '{item.Name}' blev tilføjet med ID: {item.ItemId}");
        }

        public void LoadItemsFromDatabase()
        {
            foreach (var item in _itemRepository.GetAll())
            {
                Items.Add(item);
            }
        }
            
            public void MarkAsSold(Item item)
            {
                _itemRepository.MarkAsSold(item.ItemId);
                Items.Remove(item);
            }
        
    }
}