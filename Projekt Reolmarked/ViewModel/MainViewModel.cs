using Projekt_Reolmarked.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Projekt_Reolmarked.ViewModel
{
    public class MainViewModel
    {

        public ShelfManagerViewModel ShelfManagerViewModel { get; }

        public SellerViewModel SellerViewModel { get; }

        public ItemViewModel ItemViewModel { get; }

        public ICommand OpenCheckoutCommand { get; }
        public ICommand OpenCreateItemCommand { get; }


        public MainViewModel()
        {

            SellerViewModel = new SellerViewModel();
            Items = [];
            ItemViewModel = new ItemViewModel(SellerViewModel, Items);
            ShelfManagerViewModel = new ShelfManagerViewModel(SellerViewModel);



            OpenCheckoutCommand = new RelayCommand(OpenCheckOut);
            OpenCreateItemCommand = new RelayCommand(OpenCreateItem);
        }

        private void OpenCheckOut(object parameter)
        {
            var checkOutWindow = new CheckOut(SellerViewModel, Items);
            checkOutWindow.Show();
        }

        private void OpenCreateItem(object parameter)
        {
            var createItem = new View.CreateItem(SellerViewModel, Items);
            createItem.DataContext = ItemViewModel;
            createItem.Show();
        }

        public ObservableCollection<Item> Items { get; set; }


    }
}
