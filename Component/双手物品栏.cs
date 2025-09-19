using HarmonyLib;

namespace Stationeers_Fixes_Package
{
    [HarmonyPatch(typeof(PanelHands), nameof(PanelHands.Awake))]
    public class PanelHands_Awake_Patch
    {
        public static void Postfix(ref PanelHands __instance)
        {
            __instance.gameObject.AddComponent<PanelHands_延时修改>();
        }
    }
}