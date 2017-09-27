/*
 * regex-tester - A small application to test and learn regular expressions
 * Copyright (c) 2017 Dorian Stoll
 * Licensed under the terms of the MIT license
 */
 
using System;
 
namespace TMSP 
{
	public static class ConsoleUtils
 	{
		/// <summary>
		/// Executes mutliple WriteLine functions with a different foreground color.
		/// </summary>
		public static void WriteColored(ConsoleColor color, Action callback) 
		{
			Console.ForegroundColor = color;
			callback();
			Console.ResetColor();
		}
		
		/// <summary>
        /// Reads a value from the command line without failing
        /// </summary>
        public static T Read<T>(String prompt, String error, Func<T, Boolean> check = null) where T : IConvertible
        {
            if (check == null)
                check = (s) => true;
            while (true)
            {
                Console.Write(prompt + " ");
                try
                {
                    String raw = Console.ReadLine();
                    T value = (T)Convert.ChangeType(raw, typeof(T));
                    if (!check(value))
                        throw new Exception();
                    return value;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[ERROR] " + error);
                    Console.ResetColor();
                }
            }
        }
	}
}