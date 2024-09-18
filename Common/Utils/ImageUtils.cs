using Common.Extensions;
using Common.Vnc;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static Common.WinAPI;

namespace Common.Utils
{
	public static class ImageUtils
	{
		public static Image ByteArrayToImage(byte[] imageArray)
		{
			return imageArray == null ? null : Image.FromStream(new MemoryStream(imageArray));
		}

		public static byte[] GetScreenAreaInByteArray(Rectangle rectangle, Encoding encoding)
		{
			var bitmap = GetScreenAreaBitmap(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, PixelFormat.Format16bppRgb565);
			return ImageToByteArrayWithSizeInfo(bitmap, ImageFormat.Jpeg, encoding);
		}

		public static Bitmap GetScreenAreaBitmap(int x, int y, int width, int height, PixelFormat pixelFormat)
		{
			var bmp = new Bitmap(width, height);
			using (var graphics = Graphics.FromImage(bmp))
			{
#if USE_WINAPI

				IntPtr hdc_source = IntPtr.Zero;
				IntPtr hdc_destination = IntPtr.Zero;
#if USE_WINAPI_METHOD_I
						try
						{
							hdc_source = WinAPI.GetDC(WinAPI.GetDesktopWindow()); // hdc_source = WinAPI.GetDC(IntPtr.Zero);
							hdc_destination = graphics.GetHdc();
							WinAPI.BitBlt(hdc_destination, 0, 0, width, height, hdc_source, x, y, TernaryRasterOperations.SRCCOPY);
						}
						catch
						{
							throw;
						}
						finally
						{
							WinAPI.ReleaseDC(IntPtr.Zero, hdc_source);
							WinAPI.ReleaseDC(IntPtr.Zero, hdc_destination);
							WinAPI.DeleteDC(hdc_source);
							WinAPI.DeleteDC(hdc_destination);							graphics.ReleaseHdc();
						}
#else
						IntPtr compatible_bitmap_handle = IntPtr.Zero;
						try
						{
							hdc_source = WinAPI.GetDC(WinAPI.GetDesktopWindow());
							hdc_destination = WinAPI.CreateCompatibleDC(hdc_source);
							compatible_bitmap_handle = WinAPI.CreateCompatibleBitmap(hdc_source, width, height);
							WinAPI.SelectObject(hdc_destination, compatible_bitmap_handle);
							WinAPI.BitBlt(hdc_destination, 0, 0, width, height, hdc_source, x, y, TernaryRasterOperations.SRCCOPY);
						}
						catch
						{
							throw;
						}
						finally
						{
							WinAPI.ReleaseDC(IntPtr.Zero, hdc_source);
							WinAPI.ReleaseDC(IntPtr.Zero, hdc_destination);
							WinAPI.DeleteDC(hdc_source);
							WinAPI.DeleteDC(hdc_destination);
							WinAPI.DeleteObject(compatible_bitmap_handle);
						}
#endif
#else
				graphics.CopyFromScreen(x, y, 0, 0, bmp.Size);
#endif

				var cursorInfo = new CURSORINFO();
				cursorInfo.Initialize();
				WinAPI.GetCursorInfo(ref cursorInfo);
				if (cursorInfo.hCursor != IntPtr.Zero)
				{
					var cursor = new Cursor(cursorInfo.hCursor);
					//IntPtr hdc_source_2 = WinAPI.GetDC(cursor.Handle);
					//WinAPI.BitBlt(hdc_destination, cursor.HotSpot.X, cursor.HotSpot.Y, cursor.Size.Width, cursor.Size.Height, hdc_source_2, 0, 0, TernaryRasterOperations.SRCPAINT);
					//WinAPI.ReleaseDC(cursor.Handle, hdc_source_2); //WinAPI.ReleaseDC(IntPtr.Zero, hdc_source_2);
					//WinAPI.DeleteDC(hdc_source_2);

					// FIXME - Cursors.IBeam is white
					var cursorPosition = new Point(Cursor.Position.X - x, Cursor.Position.Y - y);
					cursor.Draw(graphics, new Rectangle(cursorPosition, new Size(cursor.Size.Width, cursor.Size.Height)));
				}
			}
			return bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), pixelFormat);
		}

		public static byte[] ImageToByteArray(Image image)
		{
			return ImageToByteArray(image, ImageFormat.Jpeg);
		}

		public static byte[] ImageToByteArray(Image image, ImageFormat format)
		{
			if (image == null)
			{
				return null;
			}

			var memoryStream = new MemoryStream();
			image.Save(memoryStream, format);
			return memoryStream.ToArray();
		}

		public static byte[] ImageToByteArrayWithSizeInfo(Image image, ImageFormat format, Encoding encoding)
		{
			var imageArray = ImageToByteArray(image, format);
			var imageSizeInfo = encoding.GetBytes($"{VncCommand.ImageSize}{VncCommand.Separator}{imageArray.Length}{VncCommand.Separator}");
			return imageSizeInfo.AppendArrays(imageArray);
		}
	}
}
