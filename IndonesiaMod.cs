using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace TRtoINA
{
    [BepInPlugin("wahyu.trtoina", "TR to Indonesia", "1.0.0")]
    public class IndonesiaMod : BaseUnityPlugin
    {
        public static ManualLogSource Log;

        private void Awake()
        {
            Log = Logger;

            Logger.LogInfo("==================================");
            Logger.LogInfo("TR to Indonesia Loaded!");
            Logger.LogInfo("Plugin berhasil dijalankan!");
            Logger.LogInfo("Harmony sedang dipasang...");
            Logger.LogInfo("==================================");

            Harmony harmony = new Harmony("wahyu.trtoina");
            harmony.PatchAll();

            Logger.LogInfo("Harmony berhasil dipasang!");
        }
    }
}