namespace Tests;

public static class StringCalculator
{
	public static int Add(string numbers)
	{
		if (string.IsNullOrWhiteSpace(numbers))
			return 0;

		var customSeparator = '\0';
		if (numbers.Contains('\n'))
			customSeparator = GetSeparator(numbers[..(numbers.IndexOf('\n') + 1)]);

		var separators = new List<char> { ',', '\n', customSeparator };

		if (customSeparator != '\0')
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
