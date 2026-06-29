using HarmonyLib;

namespace TRtoINA
{
    // Patch untuk mencegat (intercept) setiap perubahan teks pada komponen TextMeshPro
    [HarmonyPatch(typeof(TMPro.TMP_Text), "text", MethodType.Setter)]
    public class TMP_Text_text_Patch
    {
        static void Prefix(ref string value)
        {
            if (value != null)
            {
                value = Translator.Translate(value);
            }
        }
    }

    // Patch untuk menerjemahkan teks bawaan TextMeshPro saat pertama kali dimuat di layar
    [HarmonyPatch(typeof(TMPro.TMP_Text), "Awake")]
    public class TMP_Text_Awake_Patch
    {
        static void Postfix(TMPro.TMP_Text __instance)
        {
            if (__instance.text != null)
            {
                string translated = Translator.Translate(__instance.text);
                if (__instance.text != translated)
                {
                    __instance.text = translated;
                }
            }
        }
    }

    // Patch opsional untuk UI Text standar bawaan Unity lama (berjaga-jaga)
    [HarmonyPatch(typeof(UnityEngine.UI.Text), "text", MethodType.Setter)]
    public class UI_Text_text_Patch
    {
        static void Prefix(ref string value)
        {
            if (value != null)
            {
                value = Translator.Translate(value);
            }
        }
    }
}
