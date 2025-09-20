using Assets.Scripts.Serialization;
using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;

namespace Stationeers_Fixes_Package
{
    internal class Stationeers_Fixes_Package_Language_CopyAndBackup
    {
        internal static string SourceLanguageFilePath = Path.Combine(Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.FullName, "workshop/content/544550/3560271413/GameData/");
        internal static string DestLanguageFilePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "rocketstation_Data/StreamingAssets/");
        public static string[] FileNameList = { "simplified_chinese", "simplified_chinese_help", "simplified_chinese_keys", "simplified_chinese_tips", "simplified_chinese_tooltips" };
        internal static void CopyLanguage()
        {
            bool IsSourceFileExists, IsDestFileExists, IsBackupFileExists;
            bool IsExistsError = false;
            for (int i = 0; i < FileNameList.Length; i++)
            {
                IsSourceFileExists = File.Exists($"{SourceLanguageFilePath}Language/{FileNameList[i]}.xml");
                IsDestFileExists = File.Exists($"{SourceLanguageFilePath}Language/{FileNameList[i]}.xml");
                IsBackupFileExists = File.Exists($"{DestLanguageFilePath}Language/{FileNameList[i]}.Backup.xml");
                if (!IsSourceFileExists || !IsDestFileExists)
                {
                    IsExistsError = true;
                    Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(BepInEx.Logging.LogLevel.Warning, $"{Plugin_Config.Name}.字符串修复.错误:(Copy:文件不存在:{FileNameList[i]}，本次运行插件将不会备份和加载,请重新安装本插件)");
                }
                else if (IsBackupFileExists)
                {
                    IsExistsError = true;
                    Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(BepInEx.Logging.LogLevel.Warning, $"{Plugin_Config.Name}.字符串修复.错误:(Copy:备份文件异常:{FileNameList[i]}.Backup,本次运行插件将不会备份和加载,请手动覆盖或删除)");
                }
            }
            if (IsExistsError) { return; }
            try
            {
                for (int i = 0; i<FileNameList.Length; i++)
                {
                    File.Copy($"{DestLanguageFilePath}Language/{FileNameList[i]}.xml", $"{DestLanguageFilePath}Language/{FileNameList[i]}.Backup.xml", overwrite: true);
                }
Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(BepInEx.Logging.LogLevel.Warning, $"{Plugin_Config.Name}.字符串修复.字符表备份成功!");
for (int i = 0; i < FileNameList.Length; i++)
{
    File.Copy($"{SourceLanguageFilePath}Language/{FileNameList[i]}.xml", $"{DestLanguageFilePath}Language/{FileNameList[i]}.xml", overwrite: true);
}
Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(BepInEx.Logging.LogLevel.Warning, $"{Plugin_Config.Name}.字符串修复.字符表修改成功!");
            }
            catch (IOException ex)
            {
                if (ex != null) { Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(BepInEx.Logging.LogLevel.Error, $"{Plugin_Config.Name}.字符串修复.错误:(Copy:IOException:{ex.Message})"); }
            }
            catch (Exception ex)
            {
                if (ex != null) { Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(BepInEx.Logging.LogLevel.Error, $"{Plugin_Config.Name}.字符串修复.错误:(Copy:Exception:{ex.Message})"); }
            }
        }
    }
    [HarmonyPatch(typeof(Assets.Scripts.GameManager), nameof(Assets.Scripts.GameManager.QuitGame))]
public class Stationeers_Fixes_Package_Language_Exit_Refuse
{
    [HarmonyPrefix]
    public static void ExitGamePreDo()
    {
        string SourceLanguageFilePath = Stationeers_Fixes_Package_Language_CopyAndBackup.SourceLanguageFilePath;
        string DestLanguageFilePath = Stationeers_Fixes_Package_Language_CopyAndBackup.DestLanguageFilePath;
        string[] FileNameList = Stationeers_Fixes_Package_Language_CopyAndBackup.FileNameList;
        bool IsExit_Refuse_Exe_Exists = File.Exists($"{SourceLanguageFilePath}Language_Delay_Refuse/Language_Delay_Refuse.exe");
        if (!IsExit_Refuse_Exe_Exists)
        {
            Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(BepInEx.Logging.LogLevel.Warning, $"{Plugin_Config.Name}.字符串修复.错误:(Delay_Refuse_Process:文件不存在)");
            return;
        }
        ExitGameDo(SourceLanguageFilePath, DestLanguageFilePath, FileNameList);

    }
    public static void ExitGameDo(string SourceLanguageFilePath, string DestLanguageFilePath, string[] FileNameList)
    {
        try
        {
            string FileName0 = FileNameList[0];
            string FileName1 = FileNameList[1];
            string FileName2 = FileNameList[2];
            string FileName3 = FileNameList[3];
            string FileName4 = FileNameList[4];
            using (Process Delay_Refuse_Process = new Process())
            {
                Delay_Refuse_Process.StartInfo = new ProcessStartInfo
                {
                    FileName = $"{SourceLanguageFilePath}Language_Delay_Refuse/Language_Delay_Refuse.exe",
                    Arguments = $"\"{DestLanguageFilePath}\" \"{FileName0}\" \"{FileName1}\" \"{FileName2}\" \"{FileName3}\" \"{FileName4}\"", // 传递dest参数（带引号处理空格）
                    UseShellExecute = false,
                    CreateNoWindow = false, // 显示控制台窗口（调试时设为true，发布可设为false）
                    RedirectStandardOutput = true, // 可选：捕获输出
                    RedirectStandardError = true   // 可选：捕获错误输出
                };
                Delay_Refuse_Process.Start();
            }
        }
        catch (Exception ex)
        {
            Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(BepInEx.Logging.LogLevel.Error, $"{Plugin_Config.Name}.字符串修复.错误:(Delay_Refuse_Process:{ex.Message})");
        }
    }
}
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
