using Common.Extensions;
using NUnit.Framework;

namespace Tests.Common.Extensions
{
	[TestFixture]
	public class StringExtensionsTests
	{
		[TestCase("cmd", new[] { "cmd" })]
		[TestCase("\"paint\"", new[] { "paint" })]
		[TestCase(@"""C:\Program Files\Git\bin\bash.exe""", new[] { @"C:\Program Files\Git\bin\bash.exe" })]
		[TestCase("mkdir \"Three Kings\"", new[] { "mkdir", "Three Kings" })]
		[TestCase("mkdir \"Three Kings\" and \"the\" Frog", new[] { "mkdir", "Three Kings", "and", "the", "Frog" })]
		public void TestGetProgramAndParameters(string command, string[] result)
		{
			var parameters = command.GetProgramAndParameters();
			Assert.AreEqual(result, parameters);
		}
	}
}
