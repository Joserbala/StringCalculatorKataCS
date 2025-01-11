namespace Tests;

public static class StringCalculator
{
	public static int Add(string numbers)
	{
		var customSeparators = new List<string>();
		if (numbers.Contains('\n'))
			customSeparators = [..GetSeparators(numbers[..(numbers.IndexOf('\n') + 1)])];

		var separators = new List<string> { ",", "\n" };
		separators.AddRange(customSeparators);

		if (customSeparators.Count != 0)
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

	private static string[] GetSeparators(string toParse)
	{
		if (!toParse.StartsWith("//") || !toParse.EndsWith('\n'))
			return [];

		var separator = toParse.Split(["//", "\n"],
			StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)[0];

		if (separator.StartsWith('[') && separator.EndsWith(']'))
		{
			return separator.Split(['[', ']'],
				StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
		}

		return [separator];
	}
}
