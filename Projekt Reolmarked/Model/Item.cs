using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Interop;

namespace Projekt_Reolmarked.Model
{
    public class Item
    {
        public string Name { get; set; }

        public int ItemId { get; set; }
        public Seller Seller { get; set; }

        //combines the sellers first and last name to be used, instead of using firstname, then last name
        public string SellerFullName
        {
            get
            {
                return $"{Seller.FirstName} {Seller.LastName}";
            }
        }

        public decimal Price { get; set; }
        public string Barcode { get; set; }
        
        public Item(string name, Seller seller, int itemId, decimal price)
        {
            Name = name;
            ItemId = itemId;
            Seller = seller;            
            Price = price;

            Barcode = ItemId.ToString("D8");

        }

        public BitmapSource BarcodeImage
        {
            get
            {
                var barcode = BarcodeGenerator.GenerateBarcode(Barcode);

                return Imaging.CreateBitmapSourceFromHBitmap(barcode.GetHbitmap(), IntPtr.Zero, System.Windows.Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            }
        }

        public override string ToString()
        {
            return $"Item: {Name}, Price: {Price}, Seller: {Seller.FirstName} {Seller.LastName}";
        }
    }
}
