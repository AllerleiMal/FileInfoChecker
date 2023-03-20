using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using Size = System.Drawing.Size;

namespace FileInfoChecker;

public class PhotoInfo
{
    private static int _compressionPropertyId = 0x0103;
    public String Filename { get; set; }
    public Size Size { get; set; }
    public int ColorDepth { get; set; }
    public int Compression { get; set; } = 0;
    public double VerticalDpi { get; set; }
    public double HorizontalDpi { get; set; }

    public PhotoInfo(string filePath)
    {
        Image image = Image.FromFile(filePath);
        var compressionProperty = image.PropertyItems.Where(p => p.Id == _compressionPropertyId).ToList();
        if (compressionProperty.Count != 0)
        {
            Compression = BitConverter.ToInt16(compressionProperty[0].Value, 0);
        }
        else
        {
            Compression = -1;
        }
        Size = image.Size;
        GetDate(new FileInfo(filePath));
    }
    
    private void GetDate(FileInfo f)
    {
        using var fs = new FileStream(f.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
        BitmapSource img = BitmapFrame.Create(fs);
        ColorDepth = img.Format.BitsPerPixel;
        VerticalDpi = img.DpiY;
        HorizontalDpi = img.DpiX;
        Filename = f.Name;
    }
}