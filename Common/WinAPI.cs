using System;
using System.Runtime.InteropServices;

namespace Common
{
	public static class WinAPI
	{
		public const int MOUSEEVENTF_LEFTDOWN = 0x02;
		public const int MOUSEEVENTF_LEFTUP = 0x04;
		public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
		public const int MOUSEEVENTF_RIGHTUP = 0x10;
		public const int MOUSEEVENTF_MIDDLEDOWN = 0x20;
		public const int MOUSEEVENTF_MIDDLEUP = 0x40;
		public const int MOUSEEVENTF_WHEEL = 0x800;

		[StructLayout(LayoutKind.Sequential)]
		public struct POINT
		{
			public int X;
			public int Y;

			public POINT(int x, int y)
			{
				X = x;
				Y = y;
			}
		}

		public struct CURSORINFO
		{
			public uint cbSize;
			public uint flags;
			public IntPtr hCursor;
			public POINT ptScreenPos;

			public void Initialize()
			{
				cbSize = (uint)Marshal.SizeOf(typeof(CURSORINFO));
			}
		}

		[DllImport("User32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetCursorPos(out POINT lpPoint);

		[DllImport("User32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

		[DllImport("User32.dll")]
		public static extern bool SetCursorPos(int x, int y);

		[DllImport("User32.dll")]
		public static extern bool GetCursorInfo(ref CURSORINFO pci);
	}
}
