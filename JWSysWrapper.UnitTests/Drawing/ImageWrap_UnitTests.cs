#region © 2026 Joe Arrowood (JoeWare)
//
// All rights reserved. Reproduction or transmission in whole or in part, in
// any form or by any means, electronic, mechanical, or otherwise, is prohibited
// without the prior written consent of the copyright owner.
//
#endregion

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using JWWrap.Impl.Drawing;

namespace JWWrap.UnitTests.Drawing
{
    // ----------------------------------------------------
    /// <summary>
    ///     ImageWrap_UnitTests tests
    /// </summary>

    [TestClass]
    public class ImageWrap_UnitTests
    {
        private string _tempDir;

        // ----------------------------------------------------

        [TestInitialize]
        public void Setup()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), "JWWrapUT_" + Guid.NewGuid().ToString("N"));

            Directory.CreateDirectory(_tempDir);
        }

        // ----------------------------------------------------

        [TestCleanup]
        public void Cleanup()
        {
            if(Directory.Exists(_tempDir))
            {
                Directory.Delete(_tempDir, true);
            }
        }

        // ----------------------------------------------------

        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Default_LeavesInstanceNull()
        {
            // ---
            // Act

            var sut = new ImageWrap();

            // ------
            // Assert

            Assert.IsNull(sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Construction_Image_WrapsInstance()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(1, 1);

            // ---
            // Act

            var sut = new ImageWrap(bitmap);

            // ------
            // Assert

            Assert.AreSame(bitmap, sut.Instance);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Size_Bitmap_ReturnsSize()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);

            // ---
            // Act

            var result = sut.Size;

            // ------
            // Assert

            Assert.AreEqual(new Size(10, 20), result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Width_Bitmap_ReturnsWidth()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);

            // ---
            // Act

            var result = sut.Width;

            // ------
            // Assert

            Assert.AreEqual(10, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Height_Bitmap_ReturnsHeight()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);

            // ---
            // Act

            var result = sut.Height;

            // ------
            // Assert

            Assert.AreEqual(20, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PhysicalDimension_Bitmap_MatchesInstance()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);

            // ---
            // Act

            var result = sut.PhysicalDimension;

            // ------
            // Assert

            Assert.AreEqual(bitmap.PhysicalDimension, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void HorizontalResolution_Bitmap_MatchesInstance()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);

            bitmap.SetResolution(72, 96);

            // ---
            // Act

            var result = sut.HorizontalResolution;

            // ------
            // Assert

            Assert.AreEqual(72f, result, 0.01f);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void VerticalResolution_Bitmap_MatchesInstance()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);

            bitmap.SetResolution(72, 96);

            // ---
            // Act

            var result = sut.VerticalResolution;

            // ------
            // Assert

            Assert.AreEqual(96f, result, 0.01f);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PropertyIdList_NewBitmap_MatchesInstance()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);

            // ---
            // Act

            var result = sut.PropertyIdList;

            // ------
            // Assert

            Assert.AreEqual(bitmap.PropertyIdList.Length, result.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void PropertyItems_NewBitmap_MatchesInstance()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);

            // ---
            // Act

            var result = sut.PropertyItems;

            // ------
            // Assert

            Assert.AreEqual(bitmap.PropertyItems.Length, result.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Tag_Set_UpdatesInstance()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);

            // ---
            // Act

            sut.Tag = "tag";

            // ------
            // Assert

            Assert.AreEqual("tag", sut.Tag);
            Assert.AreEqual("tag", bitmap.Tag);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetBounds_Bitmap_ReturnsPixelBounds()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);
            var unit = GraphicsUnit.World;

            // ---
            // Act

            var result = sut.GetBounds(ref unit);

            // ------
            // Assert

            Assert.AreEqual(new RectangleF(0, 0, 10, 20), result);
            Assert.AreEqual(GraphicsUnit.Pixel, unit);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FromFile_Path_ReturnsImage()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "image.png");

            using(var source = new Bitmap(10, 20))
            {
                source.Save(path, ImageFormat.Png);
            }
            var sut = new ImageWrap();

            // ---
            // Act

            var result = sut.FromFile(path);

            // ------
            // Assert

            Assert.AreEqual(10, result.Width);
            Assert.AreEqual(20, result.Height);

            ((ImageWrap) result).Instance.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FromFile_PathColorManagement_ReturnsImage()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "image.png");

            using(var source = new Bitmap(10, 20))
            {
                source.Save(path, ImageFormat.Png);
            }
            var sut = new ImageWrap();

            // ---
            // Act

            var result = sut.FromFile(path, true);

            // ------
            // Assert

            Assert.AreEqual(10, result.Width);

            ((ImageWrap) result).Instance.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FromFile_MissingFile_Throws()
        {
            // -------
            // Arrange

            var path = Path.Combine(_tempDir, "missing.png");
            var sut = new ImageWrap();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<FileNotFoundException>(() => sut.FromFile(path));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FromStream_Stream_ReturnsImage()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var stream = new MemoryStream();
            var sut = new ImageWrap();

            bitmap.Save(stream, ImageFormat.Png);

            stream.Position = 0;

            // ---
            // Act

            var result = sut.FromStream(stream);

            // ------
            // Assert

            Assert.AreEqual(10, result.Width);
            Assert.AreEqual(20, result.Height);

            ((ImageWrap) result).Instance.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FromStream_StreamColorManagement_ReturnsImage()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var stream = new MemoryStream();
            var sut = new ImageWrap();

            bitmap.Save(stream, ImageFormat.Png);

            stream.Position = 0;

            // ---
            // Act

            var result = sut.FromStream(stream, true);

            // ------
            // Assert

            Assert.AreEqual(10, result.Width);

            ((ImageWrap) result).Instance.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FromStream_StreamValidate_ReturnsImage()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var stream = new MemoryStream();
            var sut = new ImageWrap();

            bitmap.Save(stream, ImageFormat.Png);

            stream.Position = 0;

            // ---
            // Act

            var result = sut.FromStream(stream, true, true);

            // ------
            // Assert

            Assert.AreEqual(10, result.Width);

            ((ImageWrap) result).Instance.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FromStream_InvalidData_Throws()
        {
            // -------
            // Arrange

            var stream = new MemoryStream(new byte[] { 1, 2, 3 });
            var sut = new ImageWrap();

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.FromStream(stream));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FromHbitmap_Handle_ReturnsBitmap()
        {
            // -------
            // Arrange

            var source = new Bitmap(10, 20);
            var handle = source.GetHbitmap();
            var sut = new ImageWrap();

            // ---
            // Act

            var result = sut.FromHbitmap(handle);

            // ------
            // Assert

            Assert.AreEqual(10, result.Width);
            Assert.AreEqual(20, result.Height);

            result.Dispose();
            DeleteObject(handle);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void FromHbitmap_HandleAndPalette_ReturnsBitmap()
        {
            // -------
            // Arrange

            var source = new Bitmap(10, 20);
            var handle = source.GetHbitmap();
            var sut = new ImageWrap();

            // ---
            // Act

            var result = sut.FromHbitmap(handle, IntPtr.Zero);

            // ------
            // Assert

            Assert.AreEqual(10, result.Width);

            result.Dispose();
            DeleteObject(handle);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetPixelFormatSize_Argb32_Is32()
        {
            // -------
            // Arrange

            var sut = new ImageWrap();

            // ---
            // Act

            var result = sut.GetPixelFormatSize(PixelFormat.Format32bppArgb);

            // ------
            // Assert

            Assert.AreEqual(32, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetPixelFormatSize_Rgb24_Is24()
        {
            // -------
            // Arrange

            var sut = new ImageWrap();

            // ---
            // Act

            var result = sut.GetPixelFormatSize(PixelFormat.Format24bppRgb);

            // ------
            // Assert

            Assert.AreEqual(24, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsAlphaPixelFormat_Argb32_IsTrue()
        {
            // -------
            // Arrange

            var sut = new ImageWrap();

            // ---
            // Act

            var result = sut.IsAlphaPixelFormat(PixelFormat.Format32bppArgb);

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsAlphaPixelFormat_Rgb24_IsFalse()
        {
            // -------
            // Arrange

            var sut = new ImageWrap();

            // ---
            // Act

            var result = sut.IsAlphaPixelFormat(PixelFormat.Format24bppRgb);

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsCanonicalPixelFormat_Argb32_IsTrue()
        {
            // -------
            // Arrange

            var sut = new ImageWrap();

            // ---
            // Act

            var result = sut.IsCanonicalPixelFormat(PixelFormat.Format32bppArgb);

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsCanonicalPixelFormat_Rgb24_IsFalse()
        {
            // -------
            // Arrange

            var sut = new ImageWrap();

            // ---
            // Act

            var result = sut.IsCanonicalPixelFormat(PixelFormat.Format24bppRgb);

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsExtendedPixelFormat_Argb64_IsTrue()
        {
            // -------
            // Arrange

            var sut = new ImageWrap();

            // ---
            // Act

            var result = sut.IsExtendedPixelFormat(PixelFormat.Format64bppArgb);

            // ------
            // Assert

            Assert.IsTrue(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void IsExtendedPixelFormat_Argb32_IsFalse()
        {
            // -------
            // Arrange

            var sut = new ImageWrap();

            // ---
            // Act

            var result = sut.IsExtendedPixelFormat(PixelFormat.Format32bppArgb);

            // ------
            // Assert

            Assert.IsFalse(result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetFrameCount_Bitmap_IsOne()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);

            // ---
            // Act

            var result = sut.GetFrameCount(FrameDimension.Page);

            // ------
            // Assert

            Assert.AreEqual(1, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SelectActiveFrame_FirstFrame_ReturnsZero()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);

            // ---
            // Act

            var result = sut.SelectActiveFrame(FrameDimension.Page, 0);

            // ------
            // Assert

            Assert.AreEqual(0, result);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetPropertyItem_Missing_Throws()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);

            // ------------
            // Act & Assert

            Assert.ThrowsExactly<ArgumentException>(() => sut.GetPropertyItem(0x0131));
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SetPropertyItem_Item_CanBeReadBack()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);
            var item = (PropertyItem) Activator.CreateInstance(typeof(PropertyItem), true);

            item.Id = 0x0131;
            item.Type = 2;
            item.Value = new byte[] { 74, 87, 0 };
            item.Len = 3;

            // ---
            // Act

            sut.SetPropertyItem(item);

            var result = sut.GetPropertyItem(0x0131);

            // ------
            // Assert

            CollectionAssert.AreEqual(new byte[] { 74, 87, 0 }, result.Value);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RemovePropertyItem_Existing_RemovesItem()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);
            var item = (PropertyItem) Activator.CreateInstance(typeof(PropertyItem), true);

            item.Id = 0x0131;
            item.Type = 2;
            item.Value = new byte[] { 74, 87, 0 };
            item.Len = 3;

            sut.SetPropertyItem(item);

            // ---
            // Act

            sut.RemovePropertyItem(0x0131);

            // ------
            // Assert

            Assert.AreEqual(0, bitmap.PropertyIdList.Length);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetThumbnailImage_Size_ReturnsScaledImage()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);

            // ---
            // Act

            var result = sut.GetThumbnailImage(5, 5, () => false, IntPtr.Zero);

            // ------
            // Assert

            Assert.AreEqual(5, result.Width);
            Assert.AreEqual(5, result.Height);

            ((ImageWrap) result).Instance.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void RotateFlip_Rotate90_SwapsDimensions()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);

            // ---
            // Act

            sut.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // ------
            // Assert

            Assert.AreEqual(20, sut.Width);
            Assert.AreEqual(10, sut.Height);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Save_Filename_WritesFile()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);
            var path = Path.Combine(_tempDir, "saved.png");

            // ---
            // Act

            sut.Save(path);

            // ------
            // Assert

            Assert.IsTrue(new FileInfo(path).Length > 0);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Save_StreamFormat_WritesStream()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);
            var stream = new MemoryStream();

            // ---
            // Act

            sut.Save(stream, ImageFormat.Png);

            // ------
            // Assert

            Assert.IsTrue(stream.Length > 0);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Save_FilenameFormat_WritesFile()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);
            var path = Path.Combine(_tempDir, "saved.bmp");

            // ---
            // Act

            sut.Save(path, ImageFormat.Bmp);

            // ------
            // Assert

            Assert.IsTrue(new FileInfo(path).Length > 0);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Save_StreamEncoderParams_WritesStream()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);
            var encoder = ImageCodecInfo.GetImageEncoders().First(e => e.FormatID == ImageFormat.Jpeg.Guid);
            var stream = new MemoryStream();
            var parameters = new EncoderParameters(1);

            parameters.Param[0] = new EncoderParameter(Encoder.Quality, 50L);

            // ---
            // Act

            sut.Save(stream, encoder, parameters);

            // ------
            // Assert

            Assert.IsTrue(stream.Length > 0);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Save_FilenameEncoderParams_WritesFile()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);
            var encoder = ImageCodecInfo.GetImageEncoders().First(e => e.FormatID == ImageFormat.Jpeg.Guid);
            var path = Path.Combine(_tempDir, "saved.jpg");
            var parameters = new EncoderParameters(1);

            parameters.Param[0] = new EncoderParameter(Encoder.Quality, 50L);

            // ---
            // Act

            sut.Save(path, encoder, parameters);

            // ------
            // Assert

            Assert.IsTrue(new FileInfo(path).Length > 0);
        }

        // ----------------------------------------------------

        [TestMethod]
        public void SaveAdd_SecondImage_WritesTwoFrames()
        {
            // -------
            // Arrange

            var first = new Bitmap(8, 8);
            var second = new Bitmap(8, 8);
            var sut = new ImageWrap(first);
            var encoder = ImageCodecInfo.GetImageEncoders().First(e => e.FormatID == ImageFormat.Tiff.Guid);
            var path = Path.Combine(_tempDir, "multi.tif");
            var multiFrame = new EncoderParameters(1);
            var nextPage = new EncoderParameters(1);
            var flush = new EncoderParameters(1);

            multiFrame.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long) EncoderValue.MultiFrame);
            nextPage.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long) EncoderValue.FrameDimensionPage);
            flush.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long) EncoderValue.Flush);

            // ---
            // Act

            sut.Save(path, encoder, multiFrame);
            sut.SaveAdd(second, nextPage);
            sut.SaveAdd(flush);

            // ------
            // Assert

            using(var loaded = Image.FromFile(path))
            {
                Assert.AreEqual(2, loaded.GetFrameCount(FrameDimension.Page));
            }

            first.Dispose();
            second.Dispose();
        }

        // ----------------------------------------------------

        [TestMethod]
        public void GetObjectData_Info_DoesNotThrow()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(10, 20);
            var sut = new ImageWrap(bitmap);
            var info = new SerializationInfo(typeof(ImageWrap), new FormatterConverter());

            // ------------
            // Act & Assert

            sut.GetObjectData(info, new StreamingContext());
        }

        // ----------------------------------------------------

        [TestMethod]
        public void Dispose_Image_LeavesImageUsable()
        {
            // -------
            // Arrange

            var bitmap = new Bitmap(2, 3);
            var sut = new ImageWrap(bitmap);

            // ---
            // Act

            sut.Dispose();

            // ------
            // Assert

            Assert.AreEqual(2, bitmap.Width);
            Assert.AreEqual(3, bitmap.Height);

            bitmap.Dispose();
        }
    }
}
