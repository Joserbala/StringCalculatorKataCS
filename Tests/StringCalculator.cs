namespace Tests;

public static class StringCalculator
{
	public static int Add(string numbers)
	{
		if (string.IsNullOrWhiteSpace(numbers))
			return 0;

		var addends = numbers.Split([',', '\n'],
			StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

		if (addends.Length == 1)
			return int.Parse(addends[0]);

		var sum = 0;
		foreach (var addend in addends)
		{
			sum += int.Parse(addend);
		}

		return sum;
	}

	public static char GetSeparator(string toParse)
	{
		if (toParse.StartsWith("//") && toParse.EndsWith('\n'))
		{
			return toParse.Split(["//", "\n"],
				StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)[0][0];
		}

		return '\0';
	}
}
