using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZXing.QrCode;
using ZXing;
using BarcodeLib;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace AuthSystem.Tags
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [Authorize]
    [HtmlTargetElement("barcode")]
    public class BarCodeTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = context.AllAttributes["content"].Value.ToString();
            var width = int.Parse(context.AllAttributes["width"].Value.ToString());
            var height = int.Parse(context.AllAttributes["height"].Value.ToString());
            var BarcodeWriterPixelData = new BarcodeWriterPixelData
            {
                Format = ZXing.BarcodeFormat.CODE_128,
                Options = new QrCodeEncodingOptions
                {
                    Height = height,
                    Width = width,
                    Margin = 0
                }
            };
            var pixelData = BarcodeWriterPixelData.Write(content);
            using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb))
            {
                using (var memoryStream = new MemoryStream())
                {
                    var bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height),
                        ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
                    try
                    {
                        System.Runtime.InteropServices.Marshal
                            .Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                    }
                    finally
                    {
                        bitmap.UnlockBits(bitmapData);
                    }
                    bitmap.Save(memoryStream, ImageFormat.Png);
                    output.TagName = "img";
                    output.Attributes.Clear();
                    output.Attributes.Add("width", width);
                    output.Attributes.Add("height", height);
                    output.Attributes.Add("src", String.Format("data:image/png;base64,{0}",
                        Convert.ToBase64String(memoryStream.ToArray())));

                }
            }
        }
    }
}
