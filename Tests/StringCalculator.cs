namespace Tests;

public static class StringCalculator
{
	private static readonly List<string> DefaultSeparators = [",", "\n"];

	private const StringSplitOptions TrimEntriesAndRemoveEmptyOnes =
		StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;

	public static int Add(string numbers)
	{
		var customSeparators = new List<string>();
		if (numbers.Contains('\n'))
			customSeparators = [..GetCustomSeparators(numbers[..(numbers.IndexOf('\n') + 1)])];

		var separators = DefaultSeparators;
		separators.AddRange(customSeparators);

		if (customSeparators.Count != 0)
		{
			numbers = numbers[(numbers.IndexOf('\n') + 1)..];
		}

		var stringAddends = numbers.Split(separators.ToArray(), TrimEntriesAndRemoveEmptyOnes);

		var addends = stringAddends.Select(int.Parse).ToList();

		if (addends.Exists(a => a < 0))
		{
			var invalidAddends = addends.Where(a => a < 0).ToList();
			throw new ArgumentException($"Negatives not allowed: {string.Join(' ', invalidAddends)}");
		}

		return addends.Where(addend => addend <= 1000).Sum();
	}

	private static string[] GetCustomSeparators(string toParse)
	{
		if (!(toParse.StartsWith("//") && toParse.EndsWith('\n')))
			return [];

		var separator = toParse.Split(["//", "\n"], TrimEntriesAndRemoveEmptyOnes)[0];

		if (separator.StartsWith('[') && separator.EndsWith(']'))
		{
			return separator.Split(['[', ']'], TrimEntriesAndRemoveEmptyOnes);
		}

		return [separator];
	}
}
