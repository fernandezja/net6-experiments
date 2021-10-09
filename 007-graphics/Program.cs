// See https://aka.ms/new-console-template for more information
using System.Drawing;
using System.Drawing.Imaging;

Console.WriteLine("Create PNG!");

var bmp = new Bitmap(50, 50);

using (Graphics graph = Graphics.FromImage(bmp))
{
    Rectangle imageSize = new Rectangle(0, 0, 50, 50);
    graph.FillRectangle(Brushes.White, imageSize);
}

bmp.Save("demo.png", ImageFormat.Png);