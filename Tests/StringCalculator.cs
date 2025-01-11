namespace Tests;

public static class StringCalculator
{
	public static int Add(string numbers)
	{
		var customSeparator = string.Empty;
		if (numbers.Contains('\n'))
			customSeparator = GetSeparator(numbers[..(numbers.IndexOf('\n') + 1)]);

		var separators = new List<string> { ",", "\n", customSeparator };

		if (!string.IsNullOrWhiteSpace(customSeparator))
		{
			numbers = numbers[(numbers.IndexOf('\n') + 1)..];
		}

		var stringAddends = numbers.Split(separators.ToArray(),
			StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

		var addends = new List<int>();
		foreach (var addend in stringAddends)
		{
			addends.Add(int.Parse(addend));
		}

		if (addends.Exists(a => a < 0))
		{
			var invalidAddends = addends.Where(a => a < 0).ToList();
			throw new ArgumentException($"Negatives not allowed: {string.Join(' ', invalidAddends)}");
		}

		var sum = 0;
		foreach (var addend in addends)
		{
			if (addend <= 1000)
				sum += addend;
		}

		return sum;
	}

	public static string GetSeparator(string toParse)
	{
		if (!toParse.StartsWith("//") || !toParse.EndsWith('\n'))
			return string.Empty;

		var separator = toParse.Split(["//", "\n"],
			StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)[0];

		if (separator.StartsWith('[') && separator.EndsWith(']'))
		{
			return separator.Split(['[', ']'],
				StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)[0];
		}

		return separator;
	}
}
