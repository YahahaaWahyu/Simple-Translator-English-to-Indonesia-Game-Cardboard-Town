using System.Collections.Generic;
using System.Linq;

namespace TRtoINA
{
    public static class Translator
    {
        public static string Translate(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            // 0. Jangan proses jika teks hanya berupa angka/simbol (tidak ada huruf)
            if (!text.Any(char.IsLetter))
                return text;

            // 0. Jangan proses jika teks sudah merupakan hasil terjemahan
            if (TranslationDatabase.TranslatedValues.Contains(text))
                return text;

            // 1. Cari kalimat penuh dari file JSON (TranslationDatabase)
            if (TranslationDatabase.Translation.TryGetValue(text, out string full))
                return full;

            // 2. Jika tidak ditemukan, catat di missing.json
            if (!TranslationDatabase.Missing.ContainsKey(text))
            {
                TranslationDatabase.Missing[text] = text;
                TranslationDatabase.SaveMissing();
            }

            // 3. Cari dan ganti kata per kata dari kamus JSON
            string replacedText = text;
            foreach (var pair in TranslationDatabase.Translation)
            {
                replacedText = replacedText.Replace(pair.Key, pair.Value);
            }

            return replacedText;
        }
    }
}