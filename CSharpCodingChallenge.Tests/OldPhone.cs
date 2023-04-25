using Xunit;
using CSharpCodingChallenge;
using System;

namespace CSharpCodingChallenge.Tests
{
	public class OldPhone
	{
		[Theory]
		[InlineData("A","2")]
		public void Test1(string expected, string input)
		{
			var phone = new OldPhone();
			string result = phone.Translate(input);
		}
	}
}