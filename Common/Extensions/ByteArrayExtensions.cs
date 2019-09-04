using System;
using System.Linq;

namespace Common.Extensions
{
	public static class ByteArrayExtensions
	{
		public static byte[] AppendArrays(this byte[] value, params byte[][] arrays)
		{
			var newLength = value.Length + arrays.Sum(t => t.Length);
			var result = new byte[newLength];
			Array.Copy(value, 0, result, 0, value.Length);
			newLength = value.Length;
			for (var i = 0; i < arrays.Length; i++)
			{
				Array.Copy(arrays[i], 0, result, newLength, arrays[i].Length);
				newLength += arrays[i].Length;
			}
			return result;
		}
	}
}
