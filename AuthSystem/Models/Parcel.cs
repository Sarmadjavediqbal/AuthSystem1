using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using BarcodeLib;
using System.Configuration;

namespace AuthSystem.Models
{
    public class Parcel
    {
        public int Id { get; set; }
        private string UniqueID;
        public void NewGuid(object sender, EventArgs e)
        {
            string UniqueID = Guid.NewGuid().ToString().Replace("-","").ToUpper();
        }

        public string parType { get; set; }
        public string parCategory { get; set; }
        public string ItemType { get; set; }
        public string parDesc { get; set; }
        public DateTime GetDateTime { get; set; }
        public string BarcodeImage { get; set; }

        private string barcode;

        public string GetBarcode()
        {
            return barcode;
        }

        public void SetBarcode(string value)
        {
            Barcode barcode = new Barcode();
            Bitmap bitmap = new Bitmap(barcode.GenerateBarcode("Guid"));
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Font font = new System.Drawing.Font("IDAutomationHC39", 20);
                PointF point = new PointF(2f, 2f);
                SolidBrush black = new SolidBrush(Color.Black);
                SolidBrush white = new SolidBrush(Color.White);
                graphics.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
                graphics.DrawString("" + BarcodeImage + "", font, black, point);
            }
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, ImageFormat.Png);
            }
        }

        public string ImageUrl { get; set; }
    }
}
