using HarmonyLib;
using CardSystem.Cards;

namespace TRtoINA
{
    [HarmonyPatch(typeof(Card), nameof(Card.GetDescription))]
    public class DescriptionPatch
    {
        static void Postfix(ref string __result)
        {
            __result = Translator.Translate(__result);
        }
    }
}