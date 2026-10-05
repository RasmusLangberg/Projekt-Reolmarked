using Projekt_Reolmarked.View;
using Projekt_Reolmarked.ViewModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt_Reolmarked
{
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            viewModel = new MainViewModel();
            DataContext = viewModel;

            viewModel.OpenSellerOverview += OpenSellerOverview;
            viewModel.OpenHomePage += OpenHomePage;
            viewModel.OpenShelfOverview += OpenShelfOverview;
            viewModel.OpenMonthlySettlement += OpenMonthlySettlement;
        }

        private void OpenSellerOverview()
        {
            HomePageGrid.Visibility = Visibility.Collapsed;
            MainFrame.Visibility = Visibility.Visible;

            MainFrame.Navigate(new SellerOverview(viewModel));
        }

        private void OpenHomePage()
        {
            MainFrame.Visibility = Visibility.Collapsed;
            HomePageGrid.Visibility = Visibility.Visible;
        }

        private void OpenShelfOverview()
        {
            HomePageGrid.Visibility = Visibility.Collapsed;
            MainFrame.Visibility = Visibility.Visible;

            MainFrame.Navigate(new ShelfOverview(viewModel));
        }

        private void OpenMonthlySettlement()
        {
            HomePageGrid.Visibility = Visibility.Collapsed;
            MainFrame.Visibility = Visibility.Visible;

            MainFrame.Navigate(new MonthlySettlement(viewModel));
        }
    }
}