/*
 * regex-tester - A small application to test and learn regular expressions
 * Copyright (c) 2017 Dorian Stoll
 * Licensed under the terms of the MIT license
 */
 
using System;
using System.Text.RegularExpressions;

namespace TMSP
{
	/// <summary>
	/// The main class of the application
	/// </summary>
	public class Program
	{
		/// <summary>
		/// The entrypoint of the application. 
		/// (the first function that gets executed)
		/// </summary>
		public static void Main(string[] args)
		{
			// Say hello
			ConsoleUtils.WriteColored(ConsoleColor.Cyan, () => Console.WriteLine("-- Regex Tester --"));
			Console.WriteLine();
			
			// Store the pattern
			String pattern = "";
			
			// Loop
			while (true) 
			{
				if (String.IsNullOrEmpty(pattern)) 
				{
					pattern = ConsoleUtils.Read<String>("Please enter a regular expression:", "");
				}
				String text = ConsoleUtils.Read<String>("Please enter a string:", "");
				
				// Search for matches
				try
				{
					Boolean isMatch = Regex.IsMatch(text, pattern);
					Console.Write("Match: ");
					ConsoleUtils.WriteColored(isMatch ? ConsoleColor.Green : ConsoleColor.Red, () => Console.WriteLine(isMatch));
					if (isMatch)
						Console.WriteLine();
				}
				catch 
				{
					ConsoleUtils.WriteColored(ConsoleColor.Red, () => Console.WriteLine("[ERROR] You did not enter a valid regular expression!"));
					continue;
				}
				
				// Display the matches. We dont need the try - catch here anymore, because we validated that the pattern works
				MatchCollection matches = Regex.Matches(text, pattern);
				for (Int32 i = 0; i < matches.Count; i++)
				{
					Match match = matches[i];
					Console.Write("[" + i + "]: ");
					ConsoleUtils.WriteColored(match.Success ? ConsoleColor.Green : ConsoleColor.Red, () => Console.WriteLine(match.Success));
					String indent = new String(' ', ("[" + i + "]: ").Length);
					for (Int32 j = 0; j < match.Groups.Count; j++)
					{						
						Console.WriteLine(indent + "[" + j + "]: " + match.Groups[j].Value);
					}
				}
				Console.WriteLine();
				
				// Ask if the user wants to reset the text
				String answer = ConsoleUtils.Read<String>("Do you want to reset the regex? (y/n)", "That was no valid option", s => s.ToLower() == "y" || s.ToLower() == "n").ToLower();
				if (answer == "y")
				{
					pattern = "";
				}
				Console.WriteLine();
			}
		}
	}
}