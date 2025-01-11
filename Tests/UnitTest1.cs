using FluentAssertions;

namespace Tests;

public class StringCalculatorTests
{
	[Test]
	public void Empty_string_sums_0()
	{
		StringCalculator.Add("").Should().Be(0);
	}

	[Test]
	public void Single_number_sum()
	{
		StringCalculator.Add("1").Should().Be(1);
	}

	[Test]
	public void Two_numbers_sum()
	{
		StringCalculator.Add("2,1").Should().Be(3);
	}

	[Test]
	public void Nine_numbers_sum()
	{
		StringCalculator.Add("1,2,3,4,5,6,7,8,9").Should().Be(45);
	}
}
