using Projekt_Reolmarked.ViewModel;
using System;
using System.Collections.Generic;
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

namespace Projekt_Reolmarked.View
{
    /// <summary>
    /// Interaction logic for SellerOverview.xaml
    /// </summary>
    public partial class SellerOverview : Page
    {
        public SellerOverview(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
