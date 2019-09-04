using System;
using System.Collections.Generic;

namespace Common.Extensions
{
	public static class StringExtensions
	{
		public static string Remove(this string value, string removable)
		{
			return value.Replace(removable, String.Empty);
		}

		public static string[] GetProgramAndParameters(this string command)
		{
			string parameter;
			var result = new List<string>();

			var i = 0;
			while (i < command.Length)
			{
				switch (command[i])
				{
					case '"':
						var nextQuotIndex = command.IndexOf('"', i + 1);
						if (nextQuotIndex == -1)
						{
							throw new Exception("Could not find closing quotation mark");
						}
						parameter = command.Substring(i + 1, nextQuotIndex - i - 1);
						result.Add(parameter);
						i = nextQuotIndex;
						break;
					case ' ':
						break;
					default:
						var nextParamEndIndex = command.IndexOf(' ', i + 1);
						parameter = nextParamEndIndex == -1 ? command.Substring(i) : command.Substring(i, nextParamEndIndex - i);
						result.Add(parameter);
						i = nextParamEndIndex == -1 ? command.Length : nextParamEndIndex;
						break;
				}
				i++;
			}
			return result.ToArray();
		}
	}
}
