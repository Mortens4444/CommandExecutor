namespace Common.Mouse
{
	public static class ClickFlagsProvider
	{
		public static int Get(string clickButton, int clickType)
		{
			switch (clickButton)
			{
				case "0":
					switch (clickType)
					{
						case 0:
							return WinAPI.MOUSEEVENTF_LEFTDOWN;
						case 1:
							return WinAPI.MOUSEEVENTF_LEFTUP;
						case 2:
							return WinAPI.MOUSEEVENTF_LEFTDOWN | WinAPI.MOUSEEVENTF_LEFTUP;
					}
					break;
				case "1":
					switch (clickType)
					{
						case 0:
							return WinAPI.MOUSEEVENTF_MIDDLEDOWN;
						case 1:
							return WinAPI.MOUSEEVENTF_MIDDLEUP;
						case 2:
							return WinAPI.MOUSEEVENTF_MIDDLEDOWN | WinAPI.MOUSEEVENTF_MIDDLEUP;
					}
					break;
				case "2":
					switch (clickType)
					{
						case 0:
							return WinAPI.MOUSEEVENTF_RIGHTDOWN;
						case 1:
							return WinAPI.MOUSEEVENTF_RIGHTUP;
						case 2:
							return WinAPI.MOUSEEVENTF_RIGHTDOWN | WinAPI.MOUSEEVENTF_RIGHTUP;
					}
					break;
			}

			return -1;
		}
	}
}
