using FluentAssertions;

namespace Tests;

public class Tests
{
	[Test]
	public void CalculatorReturnsZeroWhenEmptyParameters()
	{
		StringCalculator.Add("").Should().Be(0);
	}
}

public class StringCalculator
{
	public static int Add(string numbers)
	{
		return 0;
	}
}
