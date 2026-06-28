using System.Collections.Generic;

namespace TRtoINA
{
    public static class Translator
    {
        private static readonly Dictionary<string, string> Dictionary =
            new Dictionary<string, string>()
        {
            // ===== Building =====
            { "House", "Rumah" },
            { "Road", "Jalan" },
            { "Trailer Park", "Permukiman Trailer" },
            { "Condo", "Kondominium" },
            { "Residence", "Hunian" },
            { "Skyscraper", "Pencakar Langit" },
            { "Store", "Toko" },
            { "Park", "Taman" },
            { "Small Forest", "Hutan Kecil" },
            { "Fountain", "Air Mancur" },

            // Tambahkan terus di sini nanti...
        };

        public static string Translate(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            if (Dictionary.TryGetValue(text, out string result))
                return result;

            return text;
        }
    }
}