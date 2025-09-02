using Assets.Scripts.UI;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Stationeers_Fixes_Package
{
    [HarmonyPatch(typeof(Assets.Scripts.UI.SettingItem), nameof(SettingItem.Setup))]
    internal class Stationeers_Fixes_Package_Reset_HUD_Scale
    {
        [HarmonyPrefix]
        public static void Setup(Assets.Scripts.UI.SettingItem __instance)
        {
            Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"{Plugin_Config.Name}.HUD下限.补丁成功!");
            var Scale_Value = __instance.Selectable as Slider;
            if (Scale_Value != null)
            {
                if (Scale_Value.minValue == 25)
                {
                    Scale_Value.minValue = 1;
                    Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"{Plugin_Config.Name}.HUD下限.修改成功!");
                }
            }
        }
    }
}
