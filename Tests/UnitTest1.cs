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

	[Test]
	public void AddingNineNumbersReturnsTheSumOfNineNumbers()
	{
		StringCalculator.Add("1,2,3,4,5,6,7,8,9").Should().Be(45);
	}
}
