using System.Reflection;
using Classes;

namespace TRtoINA
{
    public static class ReflectionHelper
    {
        private static readonly FieldInfo TitleEnglish =
            typeof(LocalizedTitle).GetField(
                "english",
                BindingFlags.Instance | BindingFlags.NonPublic);

        private static readonly FieldInfo TextEnglish =
            typeof(LocalizedText).GetField(
                "english",
                BindingFlags.Instance | BindingFlags.NonPublic);

        public static string GetTitleEnglish(LocalizedTitle title)
        {
            return (string)TitleEnglish.GetValue(title);
        }

        public static void SetTitleEnglish(LocalizedTitle title, string value)
        {
            TitleEnglish.SetValue(title, value);
        }

        public static string GetTextEnglish(LocalizedText text)
        {
            return (string)TextEnglish.GetValue(text);
        }

        public static void SetTextEnglish(LocalizedText text, string value)
        {
            TextEnglish.SetValue(text, value);
        }
    }
}