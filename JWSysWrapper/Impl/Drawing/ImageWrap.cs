#region © 2023 Aflac.
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Serialization;

using JWWrap.Interface.Drawing;

namespace JWWrap.Impl.Drawing
{
    public class ImageWrap : IImage
    {
        public Image Instance { get; private set; }

        public ImageWrap() { }
        
        public Size Size => Instance.Size;
        public int Width => Instance.Width;
        public int Height => Instance.Height;
        public void Dispose() => new NotImplementedException();
        public int[] PropertyIdList => Instance.PropertyIdList;
        public int Flags => throw new NotImplementedException();
        public ImageWrap(Image instance) { Instance = instance; }
        public object Clone() => throw new NotImplementedException();
        public SizeF PhysicalDimension => Instance.PhysicalDimension;
        public PropertyItem[] PropertyItems => Instance.PropertyItems;
        public float VerticalResolution => Instance.VerticalResolution;
        public float HorizontalResolution => Instance.HorizontalResolution;
        public ImageFormat RawFormat => throw new NotImplementedException();
        public PixelFormat PixelFormat => throw new NotImplementedException();
        public object Tag { get => Instance.Tag; set => Instance.Tag = value; }
        public Guid[] FrameDimensionsList => throw new NotImplementedException();
        public RectangleF GetBounds(ref GraphicsUnit pageUnit) => Instance.GetBounds(ref pageUnit);
        public ColorPalette Palette { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        // ------------
        // Begin Static

        public IImage FromFile(string filename) => new ImageWrap(Image.FromFile(filename));
        public IImage FromFile(string filename, bool useEmbeddedColorManagement) => new ImageWrap(Image.FromFile(filename, useEmbeddedColorManagement));
        public Bitmap FromHbitmap(IntPtr hbitmap) => Image.FromHbitmap(hbitmap);
        public Bitmap FromHbitmap(IntPtr hbitmap, IntPtr hpalette) => Image.FromHbitmap(hbitmap, hpalette);
        public IImage FromStream(Stream stream) => new ImageWrap(Image.FromStream(stream));
        public IImage FromStream(Stream stream, bool useEmbeddedColorManagement) => new ImageWrap(Image.FromStream(stream, useEmbeddedColorManagement));
        public IImage FromStream(Stream stream, bool useEmbeddedColorManagement, bool validateImageData)
            => new ImageWrap(Image.FromStream(stream, useEmbeddedColorManagement, validateImageData));

        public int GetPixelFormatSize(PixelFormat pixfmt) => Image.GetPixelFormatSize(pixfmt);
        public bool IsAlphaPixelFormat(PixelFormat pixfmt) => Image.IsAlphaPixelFormat(pixfmt);
        public bool IsCanonicalPixelFormat(PixelFormat pixfmt) => Image.IsCanonicalPixelFormat(pixfmt);
        public bool IsExtendedPixelFormat(PixelFormat pixfmt) => Image.IsExtendedPixelFormat(pixfmt);

        // ----------
        // End Static

        public EncoderParameters GetEncoderParameterList(Guid encoder) => Instance.GetEncoderParameterList(encoder);
        public int GetFrameCount(FrameDimension dimension) => Instance.GetFrameCount(dimension);
        public PropertyItem GetPropertyItem(int propid) => Instance.GetPropertyItem(propid);
        public IImage GetThumbnailImage(int thumbWidth, int thumbHeight, Image.GetThumbnailImageAbort callback, IntPtr callbackData)
            => new ImageWrap(Instance.GetThumbnailImage(thumbWidth, thumbHeight, callback, callbackData));

        public void RemovePropertyItem(int propid) => Instance.RemovePropertyItem(propid);
        public void RotateFlip(RotateFlipType rotateFlipType) => Instance.RotateFlip(rotateFlipType);
        public void Save(string filename) => Instance.Save(filename);
        public void Save(Stream stream, ImageFormat format) => Instance.Save(stream, format);
        public void Save(string filename, ImageFormat format) => Instance.Save(filename, format);
        public void Save(Stream stream, ImageCodecInfo encoder, EncoderParameters encoderParams) => Instance.Save(stream, encoder, encoderParams);
        public void Save(string filename, ImageCodecInfo encoder, EncoderParameters encoderParams) => Instance.Save(filename, encoder, encoderParams);
        public void SaveAdd(EncoderParameters encoderParams) => Instance.SaveAdd(encoderParams);
        public void SaveAdd(Image image, EncoderParameters encoderParams) => Instance.SaveAdd(image, encoderParams);
        public int SelectActiveFrame(FrameDimension dimension, int frameIndex) => Instance.SelectActiveFrame(dimension, frameIndex);
        public void SetPropertyItem(PropertyItem propitem) => Instance.SetPropertyItem(propitem);
        public void GetObjectData(SerializationInfo info, StreamingContext context) { /* Not Implemented */ }
    }
}
