using HarmonyLib;
using Il2Cpp;
using UnityEngine;
using WickerREST;

namespace RevealMapREST
{
    internal static class Processing
    {
        public static void RevealMap()
        {
            if (GameManager.Instance == null || !GameManager.gameFullyInitialized)
            {

                WickerNetwork.Instance.LogResponse("Must be in-game to reveal map!");
                return;
            }

            if (GameManager.Instance != null && GameManager.gameFullyInitialized)
            {
                WickerNetwork.Instance.LogResponse("Revealing map...");
                GameManager.Instance.cameraManager.fogOfWarEffect.mFog.enabled = false;
                ActiveConfig.isRevealed = true;

                var relicResources = UnityEngine.Object.FindObjectsOfType<RelicExtractionResource>();
                foreach (var relic in relicResources)
                {
                    relic.availableForExtraction = true;
                }
            }
        }

        [HarmonyPatch(typeof(FOWSystem), "IsExplored")]
        class Patch_FOWSystem_IsExplored
        {
            static bool Prefix(Vector3 pos, ref bool __result)
            {
                if (ActiveConfig.isRevealed)
                {
                    __result = true; // Set the result to true
                    return false; // Skip the original method
                }
                return true; // Continue with the original method
            }
        }
    }
}
