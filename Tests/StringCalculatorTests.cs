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

	[Test]
	public void Newline_separator_works_as_separator()
	{
		StringCalculator.Add("0\n2").Should().Be(2);
	}

	[Test]
	public void Combining_comma_and_newline_separators()
	{
		StringCalculator.Add("1,\n2,5").Should().Be(8);
	}

	[Test]
	public void Custom_separator_works_as_separator()
	{
		StringCalculator.Add("//;\n1;2").Should().Be(3);
	}

	[Test]
	public void Custom_separator_and_default_separators()
	{
		StringCalculator.Add("//;\n1;2,9").Should().Be(12);
		StringCalculator.Add("//;\n1;2,9\n45").Should().Be(57);
	}

	[Test]
	public void Disallow_negatives()
	{
		((Func<int>?)(() => StringCalculator.Add("1,-2,-3"))).Should().Throw<ArgumentException>();
	}

	[Test]
	public void Ignore_numbers_bigger_than_1000()
	{
		StringCalculator.Add("1001, 2").Should().Be(2);
		StringCalculator.Add("1000, 2").Should().Be(1002);
	}

	[Test]
	public void Add_with_arbitrary_length_separator()
	{
		StringCalculator.Add("//[***]\n1***2***3").Should().Be(6);
		StringCalculator.Add("//[foo]\n1foo2foo3").Should().Be(6);
	}

	[Test]
	public void Multiple_single_length_separators()
	{
		StringCalculator.Add("//[*][%]\n1*2%3").Should().Be(6);
	}

	[Test]
	public void Multiple_longer_length_methods()
	{
		StringCalculator.Add("//[foo][bar]\n1foo2bar3").Should().Be(6);
	}
}
