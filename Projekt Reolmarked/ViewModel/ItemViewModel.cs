using Projekt_Reolmarked.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Projekt_Reolmarked.data;
using System.Windows.Media.Imaging;
using System;
using System.Drawing;
using System.Windows.Interop;
using System.Windows.Media;

namespace Projekt_Reolmarked.ViewModel
{
    public class ItemViewModel : INotifyBase
    {
        private readonly IItemRepository _itemRepository = new ItemRepository();

        public ObservableCollection<Item> Items { get; }

        public SellerViewModel SellerViewModel { get; }


        private int nextID = 1;

        public ICommand AddItemCommand { get; }

        public ICommand RemoveItemCommand { get; }

        public ICommand DeleteItemCommand { get; }

        public ItemViewModel(SellerViewModel sellerViewModel)
        {
            SellerViewModel = sellerViewModel;

            Items = new ObservableCollection<Item>();

            AddItemCommand = new RelayCommand(parameter => AddItem());

            RemoveItemCommand = new RelayCommand(parameter => RemoveItem());



            LoadItems();
            
        }
        
        public void MarkAsSold(Item item)
        {
            _itemRepository.MarkAsSold(item.ItemId);
            Items.Remove(item);
        }

        private void AddItem()
        {
            var ItemId = GenerateID();

            Item newItem = new( Name, SellerViewModel.SelectedSeller, ItemId, (decimal)Price);

            _itemRepository.add(newItem);

            Items.Add(newItem);

            //barcodes

            var barcode = BarcodeGenerator.GenerateBarcode(newItem.Barcode);

            BarcodeImage = Imaging.CreateBitmapSourceFromHBitmap(barcode.GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());



            MessageBox.Show($"Item '{newItem.Name}' added successfully with ID: {newItem.ItemId}");
        }

        public void RemoveItem()
        {
            var item = SelectedItem;  

            if ( item != null)
            {
                Items.Remove(item);
            }
            else
            {
                MessageBox.Show("du skal vælge en vare og slette");
            }


        }


        private BitmapSource _barcodeImage;

        public BitmapSource BarcodeImage
        {
            get { return _barcodeImage; }
            set
            {
                _barcodeImage = value;
                OnPropertyChanged(nameof(BarcodeImage));
            }
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

        public void LoadItems()
        {
            foreach (var item in _itemRepository.GetAll())
            {
                Items.Add(item);
            }
        }
    }
}