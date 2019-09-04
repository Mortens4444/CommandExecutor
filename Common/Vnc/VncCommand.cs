namespace Common.Vnc
{
	public static class VncCommand
	{
		public const char Separator = ':';

		public const string GetScreen = "getscreen";

		public const string MouseMove = "mousemove";

		public const string MouseClick = "mouseclick";

		public const string MouseDoubleClick = "mousedoubleclick";
		
		public const string MouseDown = "mousedown";

		public const string MouseUp = "mouseup";

		public const string Mouse = "mouse";

		public const string ImageSize = "imagesize";

		public const string ScreenSize = "screensize";

		public const string SendScreenSize = "sendscreensize";

		public const string KillApp = "killapp";

		public const string KeyPressed = "keypress";

		public const string Scrool = "scrool";
	}
}
