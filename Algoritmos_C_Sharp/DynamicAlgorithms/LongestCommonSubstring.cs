
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
			var result = FindLargestSubstring(str1, str2);
			Console.WriteLine($"The longest substring between string 1 and string 2 is {result}");
		}


		private string FindLargestSubstring(string str1, string str2)
		{
			var result = "";
			for (var i = 0; i < str1.Length; i++)
			{
				if (str1.Length - i < result.Length)
				{
					// no need to keep searching
					// cause the longest substring was found
					break;
				}
				result = GetStringWithMaxLength(FindSubstring(str1, str2, i), result);
			}
			return result;
		}

		private string FindSubstring(string str1, string str2, int i)
		{
			var largestSubstringFound = "";
			while (i < str1.Length)
			{
				for (var j = 0; j < str2.Length; j++)
				{
					if (i >= str1.Length) break;

					if (str1[i] == str2[j])
					{
						largestSubstringFound += str1[i];
						i++;
					}
					else
					{
						if (largestSubstringFound != "")
						{
							// the largest sequence was found
							i = str1.Length;
							break;
						}
					}
				}
			}
			return largestSubstringFound;
		}

		private string GetStringWithMaxLength(string s1, string s2)
		{
			if (s1.Length > s2.Length) return s1;
			if (s1.Length < s2.Length) return s2;

			return s1;
		}

	}
}
