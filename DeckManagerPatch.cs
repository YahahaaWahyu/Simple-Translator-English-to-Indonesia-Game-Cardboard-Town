using HarmonyLib;
using CardSystem;

namespace TRtoINA
{
    [HarmonyPatch(typeof(DeckManager), "Start")]
    public class DeckManagerPatch
    {
        static void Postfix(DeckManager __instance)
        {
            int translatedNames = 0;
            int translatedDescriptions = 0;

            foreach (var card in __instance.AllCards)
            {
                // ==========================
                // Terjemahkan Nama
                // ==========================
                string oldTitle = ReflectionHelper.GetTitleEnglish(card.cardName);
                string newTitle = Translator.Translate(oldTitle);

                if (oldTitle != newTitle)
                {
                    ReflectionHelper.SetTitleEnglish(card.cardName, newTitle);
                    translatedNames++;
                }

                // ==========================
                // Terjemahkan Deskripsi
                // ==========================
                string oldDesc = ReflectionHelper.GetTextEnglish(card.description);
                string newDesc = Translator.Translate(oldDesc);

                if (oldDesc != newDesc)
                {
                    ReflectionHelper.SetTextEnglish(card.description, newDesc);
                    translatedDescriptions++;
                }
            }

            IndonesiaMod.Log.LogInfo("==================================");
            IndonesiaMod.Log.LogInfo("TR to Indonesia");
            IndonesiaMod.Log.LogInfo($"Nama diterjemahkan      : {translatedNames}");
            IndonesiaMod.Log.LogInfo($"Deskripsi diterjemahkan : {translatedDescriptions}");
            IndonesiaMod.Log.LogInfo("==================================");
        }
    }
}