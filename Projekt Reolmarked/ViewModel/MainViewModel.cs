using Projekt_Reolmarked.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Printing;
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

        public CheckOutViewModel CheckOutViewModel { get; }

        public ICommand OpenCheckoutCommand { get; }
        public ICommand OpenCreateItemCommand { get; }
        public ICommand SellerOverviewCommand { get; }
        public ICommand ShelfOverviewCommand {  get; }
        public ICommand BackButtonCommand { get; }


        public MainViewModel()
        {


            SellerViewModel = new SellerViewModel();
            CheckOutViewModel = new CheckOutViewModel(ItemViewModel);
            ItemViewModel = new ItemViewModel(SellerViewModel, Items);
            ShelfManagerViewModel = new ShelfManagerViewModel(SellerViewModel);


            OpenCheckoutCommand = new RelayCommand(OpenCheckOut);
            OpenCreateItemCommand = new RelayCommand(OpenCreateItem);
            ShelfOverviewCommand = new RelayCommand(OpenShelfOverview);
            SellerOverviewCommand = new RelayCommand(OpenSellerOverview);
        }

        private void OpenCheckOut(object parameter)
        {
            var checkOutWindow = new CheckOut(SellerViewModel);
            checkOutWindow.Show();
        }

        private void OpenCreateItem(object parameter)
        {
            var createItem = new View.CreateItem(SellerViewModel, Items);
            createItem.DataContext = ItemViewModel;
            createItem.Show();
        }

        private void ShelfOverview()
        {
            
        }

        private void SellerOverview()
        {

        }

        public ObservableCollection<Item> Items { get; set; }


    }
}
