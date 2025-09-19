using UnityEngine;
using BepInEx;
using HarmonyLib;
using System;
namespace Stationeers_Fixes_Package
{
  //图像预设
  [HarmonyPatch(typeof(QualitySettings), nameof(QualitySettings.names), MethodType.Getter)]
  internal class Setting_QuantityLevel
  {
    static bool IsDo;
    [HarmonyPostfix]
    public static void QuantityLevel(ref string[] __result)
    {
      // 验证数组有效性（避免空引用或长度不足）
      if (__result == null || __result.Length < 6 || __result[0] != "Fastest") return;
      __result[0] = "最快";
      __result[1] = "快速";
      __result[2] = "简单";
      __result[3] = "良好";
      __result[4] = "精美";
      __result[5] = "极致";
      if (!IsDo) Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(BepInEx.Logging.LogLevel.Warning, $"{Plugin_Config.Name}.设置.图像预设词条修改完成!");
      IsDo = true;
    }
  }
}