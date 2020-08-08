using Common.Messages;
using Common.Vnc;
using System;
using System.Threading;
using static Common.WinAPI;

namespace Common.Mouse
{
	public static class MouseHandler
	{
		public static void ProcessMessage(string clickControlMessage, int clickType)
		{
			var clickButton = clickControlMessage.Split(' ')[1];
			var location = new POINT();
			WinAPI.GetCursorPos(out location);

			if (clickType == 3)
			{
				var clickFlags = ClickFlagsProvider.Get(clickButton, 2);
				for (int i = 0; i < 3; i++) // Why 3?
				{
					WinAPI.MouseEvent(clickFlags, location.X, location.Y, 0, 0);
					Thread.Sleep(50);
				}
			}
			else
			{
				var clickFlags = ClickFlagsProvider.Get(clickButton, clickType);
				WinAPI.MouseEvent(clickFlags, location.X, location.Y, 0, 0);
			}
		}

		public static void ProcessMessage(string mouseControlMessage)
		{
			var mouseEvents = mouseControlMessage.Split(new string[] { VncCommand.Mouse }, StringSplitOptions.RemoveEmptyEntries);

			for (int i = 0; i < mouseEvents.Length; i++)
			{
				var clickType = ClickButtonProvider.Get(mouseEvents[i]);
				if (clickType != -1)
				{
					MouseHandler.ProcessMessage(mouseEvents[i], clickType);
					Thread.Sleep(50);
				}
				else
				{
					var mouseMoveArgs = mouseEvents[i].Split(' ');

					try
					{
						var x = Convert.ToInt32(mouseMoveArgs[1]);
						var y = Convert.ToInt32(mouseMoveArgs[2]);

						if (!WinAPI.SetCursorPos(x, y))
						{
							ErrorBox.ShowLastWin32Error("MouseHandler.ProcessMessage");
						}
					}
					catch (Exception ex)
					{
						// FIXME: mouseMoveArgs = 289getscre
						//ErrorBox.Show("Mouse control error", $"Unable to parse message: {mouseControlMessage}. Exception: {ex}");
					}
				}
			}
		}
	}
}
