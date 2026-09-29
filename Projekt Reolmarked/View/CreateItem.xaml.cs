using Projekt_Reolmarked.Model;
using Projekt_Reolmarked.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekt_Reolmarked.View
{
    /// <summary>
    /// Interaction logic for CreateItem.xaml
    /// </summary>
    public partial class CreateItem : Window
    {
     
        public CreateItem(MainViewModel mainViewModel)
        {
            InitializeComponent();
           
            DataContext = mainViewModel;
        }
    }
}
