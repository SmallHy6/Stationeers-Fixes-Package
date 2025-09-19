using Assets.Scripts.Serialization;
using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Stationeers_Fixes_Package
{
    internal class Stationeers_Fixes_Package_Language_CopyAndBackup
    {
        internal static string SourceLanguageFilePath = Path.Combine(Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.FullName, "workshop/content/544550/3560271413/GameData/Language/");
        internal static string DestLanguageFilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "rocketstation_Data/StreamingAssets/Language/");
        internal static void CopyLanguage()
        {
            bool IsSourceFileExists = File.Exists($"{SourceLanguageFilePath}simplified_chinese.xml");
            bool IsDestFileExists = File.Exists($"{SourceLanguageFilePath}simplified_chinese.xml");
            if (!IsSourceFileExists || !IsDestFileExists)
            {
                Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(BepInEx.Logging.LogLevel.Warning, $"{Plugin_Config.Name}.字符串修复.错误:(Copy:文件不存在)");
                return;
            }
            try
            {
                File.Copy($"{DestLanguageFilePath}simplified_chinese.xml", $"{DestLanguageFilePath}simplified_chinese.Backup.xml");
                Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(BepInEx.Logging.LogLevel.Warning, $"{Plugin_Config.Name}.字符串修复.字符表备份成功!");
                File.Copy($"{SourceLanguageFilePath}simplified_chinese.xml", $"{DestLanguageFilePath}simplified_chinese.xml", overwrite: true);
                Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(BepInEx.Logging.LogLevel.Warning, $"{Plugin_Config.Name}.字符串修复.字符表修改成功!");
            }
            catch (IOException ex)
            {
                if (ex != null) { Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(BepInEx.Logging.LogLevel.Error, $"{Plugin_Config.Name}.字符串修复.错误:(Copy:IOException)"); }
            }
            catch (Exception ex)
            {
                if (ex != null) { Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(BepInEx.Logging.LogLevel.Error, $"{Plugin_Config.Name}.字符串修复.错误:(Copy:Exception)"); }
            }
        }
    }
    // [HarmonyPatch (typeof(Assets.Scripts.GameManager), nameof(Assets.Scripts.GameManager.QuitPrompt))]
    // internal class Stationeers_Fixes_Package_Exit_Refuse
    // {
    //     [HarmonyPrefix]
    //     internal static void ExitGameDo()
    //     {
    //         string DestLanguageFilePath = Stationeers_Fixes_Package_Language_CopyAndBackup.DestLanguageFilePath;
    //         try
    //         {
    //             File.Move($"{DestLanguageFilePath}simplified_chinese.Backup.xml", $"{DestLanguageFilePath}simplified_chinese.xml");
    //             Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(BepInEx.Logging.LogLevel.Warning, $"{Plugin_Config.Name}.字符串修复.复原字符表成功!");
    //         }
    //         catch (IOException ex)
    //         {
    //             if (ex != null) { Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(BepInEx.Logging.LogLevel.Error, $"{Plugin_Config.Name}.字符串修复.错误:(RollingCopy:IOException)"); }
    //         }
    //         catch (Exception ex)
    //         {
    //             if (ex != null) { Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(BepInEx.Logging.LogLevel.Error, $"{Plugin_Config.Name}.字符串修复.错误:(RollingCopy:Exception)"); }
    //         }
    //     }
    // }
    [HarmonyPatch(typeof(Assets.Scripts.Localization2.GameStrings), MethodType.StaticConstructor)]
    internal class Stationeers_Fixes_Package_Game_Strings_Patch
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var ILCode = new List<HarmonyLib.CodeInstruction>(instructions);
            // 指令结构请参考逻辑分拣机的指令结构,基本原理相同
            for (var i = 0; i < ILCode.Count; i++)
            {
                if (ILCode[i].opcode == OpCodes.Ldstr)
                {
                    if (ILCode[i].operand is string 内容)
                    { UnityEngine.Debug.Log(内容); }
                }
            }

            return ILCode;
        }

    }
}
