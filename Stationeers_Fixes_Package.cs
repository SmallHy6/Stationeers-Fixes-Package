using Assets.Scripts.Inventory;
using Assets.Scripts.Localization2;
using Assets.Scripts.Networking;
using Assets.Scripts.Objects;
using Assets.Scripts.Objects.Electrical;
using Assets.Scripts.Objects.Entities;
using Assets.Scripts.Objects.Items;
using Assets.Scripts.Objects.Pipes;
using Assets.Scripts.Serialization;
using Assets.Scripts.UI;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using ImGuiNET;
using ImGuiNET.Unity;
using Stationeers_Fixes_Package;
using SimpleSpritePacker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using BepInEx.Configuration;

namespace Stationeers_Fixes_Package
{
    [BepInPlugin(Plugin_Config.ID, Plugin_Config.Name, Plugin_Config.Version)]
    public class Stationeers_Fixes_Package_Initialization : BaseUnityPlugin
    {
        private ConfigEntry<bool> Plugin_Activate;
        private ConfigEntry<bool> Chinese_Fixes_On;
        private ConfigEntry<bool> Game_Strings_Fixes_On;
        private ConfigEntry<bool> More_Angle_Grinder_Function_On;
        private ConfigEntry<bool> More_Labeling_Machine_Function_On;
        private ConfigEntry<bool> Player_Status_UI_On;
        private ConfigEntry<bool> Reset_HUD_Scale_On;
        private ConfigEntry<bool> Text_Fixes_On;
        public static Harmony InitHarmony;
        private void Awake()
        {

            CreatePluginConfig();
            Logger.LogWarning($"{Plugin_Config.Name}.配置文件创建&读取成功!");
            if (!Plugin_Activate.Value)
            {
                Logger.LogWarning($"{Plugin_Config.Name}.插件未启用!");
                return;
            }
            Stationeers_Fixes_Package_Language_CopyAndBackup.CopyLanguage();
            var a = AssetsLoad.单例;
            Harmony InitHarmony = new Harmony(Plugin_Config.ID);
            InitHarmony.PatchAll();
            Logger.LogWarning($"{Plugin_Config.Name}.初始化成功!");
        }
        private static Stationeers_Fixes_Package_Initialization _instance;
        private Stationeers_Fixes_Package_Initialization() { }
        public static Stationeers_Fixes_Package_Initialization BepinExTool()
        {
            if (_instance == null) { _instance = new Stationeers_Fixes_Package_Initialization(); }
            return _instance;
        }
        public void BepinExMessage(LogLevel Level, string Message)
        {
            Logger.Log(Level, Message);
        }
        private void CreatePluginConfig()
        {
            Plugin_Activate = Config.Bind<bool>(
                section: "AAA.General",
                key: "On",
                defaultValue: true,
                description: "[插件开关]&[ActivatePlugin]"
            );
            Chinese_Fixes_On = Config.Bind<bool>(
                section: "Function",
                key: "Chinese_Fixes.On",
                defaultValue: true,
                description: "[F1修复插件]&[Chinese_Fixes]"
            );
            Game_Strings_Fixes_On = Config.Bind<bool>(
                section: "Function",
                key: "Game_Strings_Fixes.On",
                defaultValue: true,
                description: "[游戏字符串修复]&[Game_Strings_Fixes]"
            );
            More_Angle_Grinder_Function_On = Config.Bind<bool>(
                section: "Function",
                key: "More_Angle_Grinder_Function.On",
                defaultValue: true,
                description: "[更多角磨机功能]&[More_Angle_Grinder_Function]"
            );
            More_Labeling_Machine_Function_On = Config.Bind<bool>(
                section: "Function",
                key: "More_Labeling_Machine_Function.On",
                defaultValue: true,
                description: "[更多贴标机功能]&[More_Labeling_Machine_Function]"
            );
            Player_Status_UI_On = Config.Bind<bool>(
                section: "Function",
                key: "Player_Status_UI.On",
                defaultValue: true,
                description: "[玩家状态UI]&[Player_Status_UI]"
            );
            Reset_HUD_Scale_On = Config.Bind<bool>(
                section: "Function",
                key: "Reset_HUD_Scale.On",
                defaultValue: true,
                description: "[更多HUD大小修改]&[Reset_HUD_Scale]"
            );
            Text_Fixes_On = Config.Bind<bool>(
                section: "Function",
                key: "Text_Fixes.On",
                defaultValue: true,
                description: "[字体修复]&[Text_Fixes]"
            );
        }
    }
}