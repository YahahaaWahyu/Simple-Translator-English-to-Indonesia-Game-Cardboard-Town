using System.Reflection;
using HarmonyLib;
using CardSystem;
using Classes;

namespace TRtoINA
{
    [HarmonyPatch(typeof(DeckManager), "Start")]
    public class DeckManagerPatch
    {
        static void Postfix(DeckManager __instance)
        {
            FieldInfo englishField = typeof(LocalizedTitle).GetField(
                "english",
                BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var card in __instance.AllCards)
            {
                string english =
                    englishField.GetValue(card.cardName)?.ToString();

                string indonesia = Translator.Translate(english);

                if (english != indonesia)
                {
                    englishField.SetValue(card.cardName, indonesia);

                    IndonesiaMod.Log.LogInfo(
                        $"{english} -> {indonesia}");
                }
            }

            IndonesiaMod.Log.LogInfo("=== Translasi selesai ===");
        }
    }
}