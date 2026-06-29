using System;
using System.Collections.Generic;
using System.IO;

namespace TRtoINA
{
    public static class TranslationDatabase
    {
        private static readonly string Folder =
            Path.Combine(
                BepInEx.Paths.PluginPath,
                "TRtoINA");

        private static readonly string TranslationFile =
            Path.Combine(Folder, "translation.json");

        private static readonly string MissingFile =
            Path.Combine(Folder, "missing.json");

        public static Dictionary<string, string> Translation =
            new Dictionary<string, string>();

        public static Dictionary<string, string> Missing =
            new Dictionary<string, string>();

        public static HashSet<string> TranslatedValues = new HashSet<string>();

        public static void Load()
        {
            Directory.CreateDirectory(Folder);

            if (!File.Exists(TranslationFile))
            {
                File.WriteAllText(
                    TranslationFile,
                    "{}");
            }

            if (!File.Exists(MissingFile))
            {
                File.WriteAllText(
                    MissingFile,
                    "{}");
            }

            Translation =
                SimpleJsonDictionary.Deserialize(
                    File.ReadAllText(TranslationFile));

            if (Translation == null) Translation = new Dictionary<string, string>();

            Missing =
                SimpleJsonDictionary.Deserialize(
                    File.ReadAllText(MissingFile));
            
            if (Missing == null) Missing = new Dictionary<string, string>();

            TranslatedValues.Clear();
            foreach (var value in Translation.Values)
            {
                TranslatedValues.Add(value);
            }
        }

        public static void SaveMissing()
        {
            File.WriteAllText(
                MissingFile,
                SimpleJsonDictionary.Serialize(Missing));
        }
    }
}