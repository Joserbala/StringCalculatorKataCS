using FluentAssertions;

namespace Tests;

public class Tests
{
	[Test]
	public void CalculatorReturnsZeroWhenEmptyParameters()
	{
		StringCalculator.Add("").Should().Be(0);
	}

	[Test]
	public void ReturnsTheSameNumberWhenProvidingOneNumber()
	{
		StringCalculator.Add("1").Should().Be(1);
	}
}

public class StringCalculator
{
	public static int Add(string numbers)
	{
		if (string.IsNullOrWhiteSpace(numbers))
			return 0;

		return int.Parse(numbers);
	}
}
