using Projekt_Reolmarked.Model;
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
using System.Windows.Shapes;

namespace Projekt_Reolmarked
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CheckOut : Window
    {
        public CheckOut()
        {
            InitializeComponent();
            DataContext = new ViewModel.MainViewModel();


            Seller seller = new Seller(2, "John", "Doe", "john.doe@example.com", 12345678);
            Item item = new Item("Glas vase", seller, 1, 19.99);
            
        }

       
    }
}
