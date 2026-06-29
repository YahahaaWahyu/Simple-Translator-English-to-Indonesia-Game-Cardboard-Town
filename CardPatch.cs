using HarmonyLib;
using CardSystem.Cards;

namespace TRtoINA
{
    [HarmonyPatch(typeof(Card), nameof(Card.UpdateCardUI))]
    public class UpdateCardUIPatch
    {
        static void Prefix(Card __instance)
        {
            // Tidak perlu log lagi.
        }
    }
}