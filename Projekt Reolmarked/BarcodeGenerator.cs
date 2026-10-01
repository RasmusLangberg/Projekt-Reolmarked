using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ZXing;
using ZXing.Common;
using ZXing.Windows.Compatibility;

namespace Projekt_Reolmarked
{
    public class BarcodeGenerator
    {
        public static Bitmap GenerateBarcode(string barcode)
        {
            var writer = new BarcodeWriter<Bitmap>
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    Width = 300,
                    Height = 100,
                    Margin = 10

                },

                Renderer = new BitmapRenderer()

            };

            return writer.Write(barcode);

        }
    }
}
