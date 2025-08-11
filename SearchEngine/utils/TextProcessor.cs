using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MyApp.Utils
{
    public static class TextProcessor
    {
        public static List<string> ExtractWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new List<string>();

            // Lowercase and remove punctuation
            var cleanText = Regex.Replace(text.ToLower(), @"[^\w\s]", "");
            return cleanText.Split(' ', StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
        }
    }
}
