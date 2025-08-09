using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Stationeers_Fixes_Packages
{
    [BepInPlugin("SmallHy.Plugin.Fixes.Packages", "Stationeers_Fixes_Packages", "1.0.0")]
    public class Stationeers_Fixes_Packages : BaseUnityPlugin
    {
        void Start()
        {
            Harmony.CreateAndPatchAll(typeof(Stationeers_Fixes_Packages));
            Logger.LogInfo("Stationeers_Fixes_Packages Init Succeed!");
        }
        [HarmonyPrefix, HarmonyPatch(typeof(Assets.Scripts.UI.Stationpedia), "ForceSearch")]
        public static bool UI_Stationpedia_Search_Patch(string searchText)
        {
            // 1. 获取Stationpedia类的Type
            Type stationpediaType = Type.GetType("Assets.Scripts.UI.Stationpedia, Assembly-CSharp"); // 替换为实际程序集名
            if (stationpediaType == null)
            {
                UnityEngine.Debug.LogWarning("未找到Stationpedia类，请检查类名和程序集名");
            }

            // 2. 获取_searchRegex字段
            FieldInfo searchRegexField = stationpediaType.GetField(
                "_searchRegex",
                BindingFlags.NonPublic | BindingFlags.Instance
            );
            if (searchRegexField == null)
            {
                UnityEngine.Debug.LogWarning("未找到_searchRegex字段");
            }

            // 3. 获取Stationpedia的实例
            object stationpediaInstance = UnityEngine.Object.FindObjectOfType(stationpediaType);
            if (stationpediaInstance == null)
            {
                UnityEngine.Debug.LogWarning("未找到Stationpedia的实例");
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
            return true;
        }
    }
}