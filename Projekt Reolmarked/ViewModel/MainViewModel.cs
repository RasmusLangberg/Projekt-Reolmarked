using Projekt_Reolmarked.Model;
using Projekt_Reolmarked.View;
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

        public ObservableCollection<Item> Items { get; set; }


        public event Action OpenSellerOverview;
        public event Action OpenHomePage;
        public event Action OpenShelfOverview;


        public ICommand OpenCheckoutCommand { get; }
        public ICommand OpenCreateItemCommand { get; }
        public ICommand SellerOverviewCommand { get; }
        public ICommand ShelfOverviewCommand {  get; }
        public ICommand BackButtonCommand { get; }




        public MainViewModel()
        {
            Items = new ObservableCollection<Item>();

            SellerViewModel = new SellerViewModel();

            ItemViewModel = new ItemViewModel(SellerViewModel, Items);

            ShelfManagerViewModel = new ShelfManagerViewModel(SellerViewModel);

            CheckOutViewModel = new CheckOutViewModel(ItemViewModel);

            OpenCheckoutCommand = new RelayCommand(OpenCheckOut);
            OpenCreateItemCommand = new RelayCommand(OpenCreateItem);

            SellerOverviewCommand = new RelayCommand(OpenSellerOverviewPage);
            ShelfOverviewCommand = new RelayCommand(OpenShelfOverviewPage);

            BackButtonCommand = new RelayCommand(GoHome);
        }

        private void OpenCheckOut(object parameter)
        {
            var checkOutWindow = new CheckOut(this);
            checkOutWindow.Show();
        }

        private void OpenCreateItem(object parameter)
        {
            var createItem = new CreateItem(this);
            createItem.Show();
        }

        private void OpenSellerOverviewPage(object parameter)
        {

            OpenSellerOverview?.Invoke();
        }

        private void OpenShelfOverviewPage(object parameter)
        {

            OpenShelfOverview?.Invoke();
        }

        private void GoHome(object parameter)
        {
            OpenHomePage?.Invoke();
        }


    }
}
