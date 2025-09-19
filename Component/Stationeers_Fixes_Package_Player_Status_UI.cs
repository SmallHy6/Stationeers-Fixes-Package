// using Assets.Scripts.Inventory;
// using Assets.Scripts.UI;
// using BepInEx.Logging;
// using HarmonyLib;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;

// namespace Stationeers_Fixes_Package
// {
//     internal static class Stationeers_Fixes_Package_Player_Status_UI
//     {
//         public static bool UI已生成么() => InventoryManager.Instance && PlayerStateWindow.Instance;
//         public abstract class 延时修改工具 : MonoBehaviour
//         {
//             // private float 计时器;
//             // private void OnDestroy() => 入口类.Log.LogInfo($"成功销毁{this.GetType().Name}");
//             private void Update()
//             {
//                 if (WorldManager.IsGamePaused) { return; }
//                 if (!UI已生成么()) { return; }
//                 // 计时器 += Time.deltaTime;
//                 // if (计时器 < 0.5f) { return; }
//                 // 计时器 = 0;
//                 仅执行一次();
//                 Destroy(this);
//             }
//             protected abstract void 仅执行一次();
//         }
//         public static void 关闭遮罩(this TMP_Text 文本工具)
//         {
//             文本工具.overflowMode = TextOverflowModes.Overflow;     // 超出RectTransform区域不截断,搭配自动换行使用
//         }
//         public static void 修改大小与遮罩(this TMP_Text 文本工具, int 大小)
//         {
//             if (文本工具.fontSize < 大小)
//             {
//                 文本工具.fontSize = 大小;

//                 if (文本工具.fontSizeMax < 大小)
//                 {
//                     文本工具.fontSizeMax = 大小;
//                 }

//                 文本工具.fontSizeMin = 大小;
//             }
//             文本工具.关闭遮罩();
//         }
//         [HarmonyPatch(typeof(PlayerStateWindow), nameof(PlayerStateWindow.Awake))]
//         public class PlayerStateWindow_Awake_Patch
//         {
//             public static void Postfix(ref PlayerStateWindow __instance)
//             {
//                 Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"{Plugin_Config.Name}.玩家状态UI.补丁成功");
//                 __instance.gameObject.AddComponent<PlayerStateWindow__延时修改>();
//             }
//             public class PlayerStateWindow__延时修改 : 延时修改工具
//             {
//                 protected override void 仅执行一次()
//                 {
//                     var 节点 = this.transform;
//                     try
//                     {
//                         // 入口点类.Log.LogMessage(层级.打印层级信息(节点.gameObject));
//                         修改布局宽度(节点.Find("PanelPortrait"));
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"面板肖像");*/
//                         //var 面板健康 = 节点.Find("PanelHealth"); 有两个相同名字的对象
//                         var 面板健康 = 节点.GetChild(2);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"面板健康");*/
//                         var 面板卫生 = 面板健康.Find("PanelHygiene");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"面板卫生");*/
//                         修改文本(面板卫生, "ValueHygiene", 28);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板卫生数值");*/
//                         修改文本(面板卫生, "ValueHygiene/TextUnitHunger", 25, 文本偏移: 10, TextAlignmentOptions.Right);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板卫生单位");*/
//                         var 面板情绪 = 面板健康.Find("PanelMood");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"面板情绪");*/
//                         修改文本(面板情绪, "ValueMood", 28);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板情绪数值");*/
//                         修改文本(面板情绪, "ValueMood/TextUnitHunger", 25, 文本偏移: 10, TextAlignmentOptions.Right);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板情绪单位");*/
//                         var 面板食品质量 = 面板健康.Find("PanelFoodQuality");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"面板食品质量");*/
//                         修改文本(面板食品质量, "ValueFoodQuality", 28);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板食品质量数值");*/
//                         修改文本(面板食品质量, "ValueFoodQuality/TextUnitHunger", 25, 文本偏移: 10, TextAlignmentOptions.Right);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板食品质量单位");*/
//                         修改文本(面板健康, "Header/InfoTextExtended");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板健康抬头");*/
//                         var 面板饱食 = 面板健康.Find("PanelHunger");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"面板饱食");*/
//                         修改文本(面板饱食, "ValueHunger", 28);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板饱食数值");*/
//                         修改文本(面板饱食, "ValueHunger/TextUnitHunger", 25, 文本偏移: 10, TextAlignmentOptions.Right);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板饱食单位");*/
//                         var 面板饮水 = 面板健康.Find("PanelHydration");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"面板饮水");*/
//                         修改文本(面板饮水, "ValueHydration", 28);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板饮水数值");*/
//                         修改文本(面板饮水, "ValueHydration/TextUnitHydration", 25, 文本偏移: 5, TextAlignmentOptions.Right);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板饮水单位");*/
//                         var 面板导航 = 节点.Find("PanelExternalNavigation");
//                         修改布局宽度(面板导航);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"面板导航");*/
//                         var 面板外部 = 面板导航.Find("PanelExternal");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"面板外部");*/
//                         修改文本(面板外部, "Header/InfoTextExtended");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板外部抬头");*/
//                         var 面板外部压力 = 面板外部.Find("PanelPressure");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板外部压力");*/
//                         var GaugeBG = 面板外部压力.Find("PressureGaugeBG");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板外部压力进度条");*/
//                         修改压力表宽度(GaugeBG.gameObject);
//                         修改文本(面板外部压力, "ValuePressure", 28, 文本偏移: -83);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板外部压力数值");*/
//                         修改文本(面板外部压力, "TextUnitPressure", 25, 文本偏移: -12, TextAlignmentOptions.Right);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板外部压力单位");*/
//                         var 面板外部温度 = 面板外部.Find("PanelTemp");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板外部温度");*/
//                         修改文本(面板外部温度, "ValueTemp", 28, 文本偏移: -82);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板外部温度数值");*/
//                         修改文本(面板外部温度, "ValueTemp/TextUnitTemp", 25, 文本偏移: 50, TextAlignmentOptions.Right);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板外部温度单位");*/
//                         var 面板外部导航 = 面板导航.Find("PanelNavigation");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板外部导航");*/
//                         var 面板指南针 = 面板外部导航.Find("PanelCompass");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板指南针");*/
//                         修改文本(面板指南针, "ValueCompass", 28, 文本偏移: -82);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板指南针数值");*/
//                         修改文本(面板指南针, "ValueCompass/TextUnitCompass", 25, 文本偏移: 43, TextAlignmentOptions.Right);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板指南针单位");*/
//                         var 面板速度 = 面板外部导航.Find("PanelVelocity");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板速度");*/
//                         修改文本(面板速度, "ValueVelocity", 28, 文本偏移: -80);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板速度数值");*/
//                         修改文本(面板速度, "ValueVelocity/TextUnitVelocity", 25, 文本偏移: 32, TextAlignmentOptions.Right);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板速度单位");*/
//                         var 面板内部 = 节点.Find("PanelVerticalGroup/Internals/PanelInternal");
//                         修改布局宽度(面板内部);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"面板内部");*/
//                         修改文本(面板内部, "Header/InfoTextExtended");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板内部抬头");*/
//                         var 面板内部压力 = 面板内部.Find("PanelPressure");
//                         var 内部GaugeBG = 面板内部压力.Find("PressureGaugeBG");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板内部压力进度条");*/
//                         修改压力表宽度(内部GaugeBG.gameObject);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板内部压力");*/
//                         修改文本(面板内部压力, "TitlePressureSetting");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板内部预设压力名称");*/
//                         修改文本(面板内部压力, "ValuePressureSetting", 28);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板内部预设压力数值");*/
//                         修改文本(面板内部压力, "ValuePressure", 28, 文本偏移: -70);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板内部压力数值");*/
//                         修改文本(面板内部压力, "TextUnitPressure", 25, 文本偏移: 0, TextAlignmentOptions.Right);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板内部压力单位");*/
//                         var 面板内部温度 = 面板内部.Find("PanelTemp");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板内部温度");*/
//                         修改文本(面板内部温度, "TitleTempSetting");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板内部预设温度名称");*/
//                         修改文本(面板内部温度, "ValueTempSetting", 28);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板内部预设温度数值");*/
//                         修改文本(面板内部温度, "ValueTemp", 28, 文本偏移: -67);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板内部温度数值");*/
//                         修改文本(面板内部温度, "ValueTemp/TextUnitTemp", 25, 文本偏移: 38, TextAlignmentOptions.Right);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板内部温度单位");*/
//                         var 面板背包 = 节点.Find("PanelVerticalGroup/PanelJetpack");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"面板背包");*/
//                         修改布局宽度(面板背包.Find("Header"));
//                         修改布局宽度(面板背包.Find("PanelThrust"));
//                         修改布局宽度(面板背包.Find("PanelPressureDelta"));
//                         修改文本(面板背包, "Header/InfoTextExtended");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板背包抬头");*/
//                         var 面板推力 = 面板背包.Find("PanelThrust");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板设置");*/
//                         修改文本(面板推力, "TitleThurstSetting");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板设置预设推力名称");*/
//                         修改文本(面板推力, "ValueThrustSetting", 28);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板设置预设推力数值");*/
//                         var 面板喷气压力 = 面板背包.Find("PanelPressureDelta");
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板喷气压力");*/
//                         修改文本(面板喷气压力, "ValuePressure", 28, 文本偏移: -66);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板喷气压力数值");*/
//                         修改文本(面板喷气压力, "TextUnitPressure", 25, 文本偏移: 0, TextAlignmentOptions.Right);
//                         /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到面板喷气压力单位");*/

//                         if (面板健康 && 面板健康.name == "PanelHealth")
//                         {
//                             /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"找到卫生面板");*/
//                             var 健康VL = 面板健康.GetComponent<HorizontalOrVerticalLayoutGroup>();
//                             if (健康VL)
//                             {
//                                 健康VL.childForceExpandWidth = false;
//                                 健康VL.childForceExpandHeight = true;           // 高度拉伸同步
//                                 /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"成功找到面板健康布局");*/
//                             }
//                             else
//                             { /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"未找到面板健康布局");*/}
//                             foreach (Transform c in 面板健康.transform)
//                             {
//                                 /*Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"面板健康扫描到: {c.name}");*/
//                                 if (c.name == "PanelFoodQuality" || c.name == "PanelHygiene" || c.name == "PanelMood")
//                                 { c.gameObject.SetActive(true); }
//                             }
//                             var 面板外部VL = 面板外部.GetComponent<VerticalLayoutGroup>();
//                             面板外部VL.childForceExpandWidth = false;
//                             面板外部VL.childForceExpandHeight = true;       // 高度拉伸同步
//                             var 面板外部导航VL = 面板外部导航.GetComponent<VerticalLayoutGroup>();
//                             面板外部导航VL.childForceExpandWidth = false;
//                             面板外部导航VL.childForceExpandHeight = true;   // 高度拉伸同步
//                         }
//                     }
//                     catch (System.Exception e)
//                     {
//                         Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Error, $"{Plugin_Config.Name}.错误对象:{e.Source}");
//                         Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Error, $"{Plugin_Config.Name}.错误类型:{e.Message}");
//                         Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Error, $"{Plugin_Config.Name}.错误信息:{e.StackTrace}\n");
//                     }

//                     var 适配 = 节点.GetComponent<ContentSizeFitter>();
//                     适配.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
//                     var Hl = 节点.GetComponent<HorizontalLayoutGroup>();
//                     Hl.childForceExpandWidth = false;
//                     Hl.childForceExpandHeight = true;       // 高度拉伸同步
//                     var HlRect = Hl.GetComponent<RectTransform>();
//                     LayoutRebuilder.ForceRebuildLayoutImmediate(HlRect);
//                     Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"{Plugin_Config.Name}.玩家状态UI.修改成功!");
//                 }
//                 private void 修改布局宽度(Transform obj)
//                 {
//                     if (obj)
//                     {
//                         foreach (var layout in obj.GetComponentsInChildren<LayoutElement>())
//                         {
//                             layout.minWidth = 220;
//                             layout.preferredWidth = 220;
//                         }
//                     }
//                 }
//                 private void 修改压力表宽度(GameObject obj, int 宽度 = 190)
//                 {
//                     if (obj)
//                     {
//                         var BGRect = obj.GetComponent<RectTransform>();
//                         BGRect.sizeDelta = new Vector2(宽度, BGRect.rect.height);
//                     }
//                 }
//                 private TMP_Text 修改文本(Transform obj, string 路径, int 字体大小 = 25, int 文本偏移 = 0, TextAlignmentOptions 对齐 = default)
//                 {
//                     return 文本调整(string.IsNullOrEmpty(路径) ? obj : obj?.Find(路径), 字体大小, 文本偏移, 对齐);
//                 }
//                 private TMP_Text 文本调整(Transform obj, int 字体大小 = 25, int 文本偏移 = 0, TextAlignmentOptions 对齐 = default)
//                 {
//                     if (obj == null)
//                     {
//                         Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Error, $"{Plugin_Config.Name}.\n这是一个空引用,没有找到到目标\n");
//                         return null;
//                     }
//                     var 文本工具 = obj.GetComponent<TMP_Text>();
//                     文本工具.修改大小与遮罩(字体大小);
//                     if (对齐 != default)
//                         文本工具.alignment = 对齐;
//                     if (文本偏移 != 0)
//                         文本工具.rectTransform.anchoredPosition = new Vector2(文本偏移, 文本工具.rectTransform.anchoredPosition.y);
//                     return 文本工具;
//                 }
//             }
//         }
//     }
// }
