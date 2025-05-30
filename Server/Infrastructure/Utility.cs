﻿namespace Infrastructure;

public static class Utility : object
{
	public static string? FixText(string? text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}

		text = text.Trim();

		while (text.Contains("  "))
		{
			text =
				text.Replace("  ", " ");
		}

		return text;
	}
}
