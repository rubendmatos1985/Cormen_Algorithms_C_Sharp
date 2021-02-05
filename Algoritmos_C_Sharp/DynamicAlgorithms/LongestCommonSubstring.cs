
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
/**
* Find the longest string (or strings ) that is a substring of two given strings
* For example: 
* Given 2 strings 'ABABC' and 'BABCA'is string BABC having length 4. Other common substrings are ABC, A, AB, B, BA, BC, C
*/
namespace Algoritmos_C_Sharp.DynamicAlgorithms
{
	class LongestCommonSubstring
	{
		Dictionary<string, string> _memo;

		public LongestCommonSubstring()
		{
			_memo = new Dictionary<string, string>();
		}
		public void Calculate(string str1, string str2)
		{
			var result = FindLargestSubstringMemoized(str1, str2);
			Console.WriteLine($"The longest substring between string 1 and string 2 is {result}");
		}

		// Naive brute force algorithm 
		private string FindLargestSubstring(string str1, string str2)
		{
			if (str1.Length == 0) return "";
			if (str1.Length == 1) return str1;
			var result = "";

			for (var i = 0; i < str1.Length; i++)
			{
				var substring = str1.Substring(i, i == 0 ? str1.Length - 1 : str1.Length - i);

				if (substring.Length < result.Length)
				{
					// no need to keep searching
					// cause next solutions length will be smaller than result
					break;
				}
				if (SubstringExists(substring, str2))
				{
					result = GetStringWithMaxLength(substring, result);
				}
				else
				{
					result = FindLargestSubstring(substring, str2);
				}
			}



			return result;
		}

		private string FindLargestSubstringMemoized(string str1, string str2)
		{
			if (str1.Length == 0) return "";
			if (str1.Length == 1) return str1;
			var result = "";

			for (var i = 0; i < str1.Length; i++)
			{
				var substring = str1.Substring(i, i == 0 ? str1.Length - 1 : str1.Length - i);
				if (substring.Length < result.Length)
				{
					// no need to keep searching
					// cause next solutions length will be smaller than result
					break;
				}
				try
				{
					result = _memo[substring];
					return result;
				}
				catch
				{
					if (SubstringExists(substring, str2))
					{
						result = GetStringWithMaxLength(substring, result);
						_memo[str1] = result;
					}
					else
					{
						result = FindLargestSubstringMemoized(substring, str2);
					}
				}

			}
			return result;
		}




		private bool SubstringExists(string str1, string str2)
		{
			var regex = new Regex(str1);
			return regex.IsMatch(str2);
		}

		private string GetStringWithMaxLength(string s1, string s2)
		{
			if (s1.Length > s2.Length) return s1;
			if (s1.Length < s2.Length) return s2;

			return s1;
		}

	}
}
