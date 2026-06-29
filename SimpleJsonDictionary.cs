using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TRtoINA
{
    public static class SimpleJsonDictionary
    {
        public static Dictionary<string, string> Deserialize(string json)
        {
            var dict = new Dictionary<string, string>();
            if (string.IsNullOrWhiteSpace(json))
                return dict;

            // Membaca format { "Kunci": "Nilai", "Kunci 2": "Nilai 2" }
            var matches = Regex.Matches(json, @"\""((?:[^\""\\]|\\.)*)\""\s*:\s*\""((?:[^\""\\]|\\.)*)\""");
            foreach (Match match in matches)
            {
                string key = Unescape(match.Groups[1].Value);
                string val = Unescape(match.Groups[2].Value);
                dict[key] = val;
            }
            return dict;
        }

        public static string Serialize(Dictionary<string, string> dict)
        {
            var sb = new StringBuilder();
            sb.AppendLine("{");
            int count = 0;
            foreach (var kvp in dict)
            {
                string key = Escape(kvp.Key);
                string val = Escape(kvp.Value);
                
                sb.Append("  \"").Append(key).Append("\": \"").Append(val).Append("\"");
                if (count < dict.Count - 1)
                    sb.Append(",");
                sb.AppendLine();
                count++;
            }
            sb.AppendLine("}");
            return sb.ToString();
        }

        private static string Escape(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            return s.Replace("\\", "\\\\")
                    .Replace("\"", "\\\"")
                    .Replace("\n", "\\n")
                    .Replace("\r", "\\r")
                    .Replace("\t", "\\t");
        }

        private static string Unescape(string s)
        {
            if (string.IsNullOrEmpty(s)) return "";
            return Regex.Unescape(s);
        }
    }
}
