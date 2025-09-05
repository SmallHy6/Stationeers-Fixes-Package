using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Stationeers_Fixes_Package
{
    [HarmonyPatch(typeof(Assets.Scripts.UI.Stationpedia), "ForceSearch")]
    internal class Stationeers_Fixes_Package_Chinese_Fixes
    {
        private static bool DoOne;
        [HarmonyPrefix]
        public static void UI_Stationpedia_Search_Patch(string searchText)
        {
            if (!DoOne)
            {
                DoOne = true;
                Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"{Plugin_Config.Name}.F1搜索中文.补丁成功!");
                // 1. 获取Stationpedia类的Type
                Type stationpediaType = typeof(Assets.Scripts.UI.Stationpedia);
                if (stationpediaType == null)
                {
                    Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Error, "未找到Stationpedia类，请检查类名和程序集名");
                }

                // 2. 获取_searchRegex字段
                FieldInfo searchRegexField = stationpediaType.GetField(
                    "_searchRegex",
                    BindingFlags.NonPublic | BindingFlags.Instance
                );
                if (searchRegexField == null)
                {
                    Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Error, "未找到_searchRegex字段");
                }

                // 3. 获取Stationpedia的实例
                object stationpediaInstance = UnityEngine.Object.FindObjectOfType(stationpediaType);
                if (stationpediaInstance == null)
                {
                    Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Error, "未找到Stationpedia的实例");
                }

                // 4. 解除readonly限制
                // 通过反射修改字段的IsInitOnly属性（需要FieldInfo的内部字段）
                FieldInfo isInitOnlyField = typeof(FieldInfo).GetField("m_isInitOnly", BindingFlags.NonPublic | BindingFlags.Instance);
                if (isInitOnlyField != null)
                {
                    isInitOnlyField.SetValue(searchRegexField, false); // 取消只读
                }

                // 5. 创建新的Regex对象
                // 正则：保留字母、数字、连字符、中文（[\u4e00-\u9fa5]）
                Regex newRegex = new Regex(
                    "[^a-zA-Z0-9-\u4e00-\u9fa5]+",
                    RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace
                );

                // 6. 赋值Regex对象到字段
                searchRegexField.SetValue(stationpediaInstance, newRegex);
                // 7.卸载补丁,对应字段 => 原方法
                MethodInfo OriginalMethod = typeof(Assets.Scripts.UI.Stationpedia).GetMethod("ForceSearch", BindingFlags.Instance | BindingFlags.NonPublic);
                Harmony HarmonyUnPatch = new Harmony(Plugin_Config.ID);
                Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"{Plugin_Config.Name}.F1搜索中文.修复成功!");
                HarmonyUnPatch.Unpatch(OriginalMethod, HarmonyPatchType.Prefix, Plugin_Config.ID);
            }
        }
    }
}
