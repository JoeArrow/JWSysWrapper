using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Serialization;
using static System.Drawing.Image;

namespace JWWrap.Interface.Drawing
{
    public interface IImage : ISerializable, ICloneable, IDisposable
    {
        float VerticalResolution { get; }
        object Tag { get; set; }
        SizeF PhysicalDimension { get; }
        PropertyItem[] PropertyItems { get; }
        Size Size { get; }
        int Width { get; }
        int Height { get; }
        int[] PropertyIdList { get; }
        float HorizontalResolution { get; }
        Guid[] FrameDimensionsList { get; }
        ColorPalette Palette { get; set; }
        PixelFormat PixelFormat { get; }
        ImageFormat RawFormat { get; }
        int Flags { get; }

        // static

        IImage FromFile(string filename);
        IImage FromFile(string filename, bool useEmbeddedColorManagement);
        Bitmap FromHbitmap(IntPtr hbitmap);
        Bitmap FromHbitmap(IntPtr hbitmap, IntPtr hpalette);
        IImage FromStream(Stream stream, bool useEmbeddedColorManagement, bool validateImageData);
        IImage FromStream(Stream stream, bool useEmbeddedColorManagement);
        IImage FromStream(Stream stream);
        int GetPixelFormatSize(PixelFormat pixfmt);
        bool IsAlphaPixelFormat(PixelFormat pixfmt);
        bool IsCanonicalPixelFormat(PixelFormat pixfmt);
        bool IsExtendedPixelFormat(PixelFormat pixfmt);

        // end static

        RectangleF GetBounds(ref GraphicsUnit pageUnit);
        EncoderParameters GetEncoderParameterList(Guid encoder);
        int GetFrameCount(FrameDimension dimension);
        PropertyItem GetPropertyItem(int propid);
        IImage GetThumbnailImage(int thumbWidth, int thumbHeight, GetThumbnailImageAbort callback, IntPtr callbackData);
        void RemovePropertyItem(int propid);
        void RotateFlip(RotateFlipType rotateFlipType);
        void Save(Stream stream, ImageCodecInfo encoder, EncoderParameters encoderParams);
        void Save(Stream stream, ImageFormat format);
        void Save(string filename, ImageCodecInfo encoder, EncoderParameters encoderParams);
        void Save(string filename, ImageFormat format);
        void Save(string filename);
        void SaveAdd(Image image, EncoderParameters encoderParams);
        void SaveAdd(EncoderParameters encoderParams);
        int SelectActiveFrame(FrameDimension dimension, int frameIndex);
        void SetPropertyItem(PropertyItem propitem);
    }
}
