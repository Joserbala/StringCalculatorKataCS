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

	[Test]
	public void ReturnsTheSumOfTwoNumbersWhenProvidingTwoNumbers()
	{
		StringCalculator.Add("2,1").Should().Be(3);
	}
}

public static class StringCalculator
{
	public static int Add(string numbers)
	{
		if (string.IsNullOrWhiteSpace(numbers))
			return 0;

		var addends = numbers.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

		if (addends.Length == 1)
			return int.Parse(addends[0]);

		var sum = 0;
		foreach (var addend in addends)
		{
			sum += int.Parse(addend);
		}

		return sum;
	}
}
