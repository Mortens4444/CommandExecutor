using System.Windows.Forms;

namespace Common.Mouse
{
	public static class ClickButtonProvider
	{
		public static int Get(string clickType)
		{
			if (clickType.StartsWith("down "))
			{
				return 0;
			}
			else if (clickType.StartsWith("up "))
			{
				return 1;
			}
			else if (clickType.StartsWith("click "))
			{
				return 2;
			}
			else if (clickType.StartsWith("doubleclick "))
			{
				return 3;
			}
			return -1;
		}

		public static int Get(MouseButtons mouseButton)
		{
			switch (mouseButton)
			{
				case MouseButtons.Left:
					return 0;
				case MouseButtons.Middle:
					return 1;
				case MouseButtons.Right:
					return 2;
			}
			return -1;
		}
	}
}
