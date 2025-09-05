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
using meanran_xuexi_mods_xiaoyouhua;
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

namespace Stationeers_Fixes_Package
{
    [BepInPlugin(Plugin_Config.ID, Plugin_Config.Name, Plugin_Config.Version)]
    public class Stationeers_Fixes_Package_Initialization : BaseUnityPlugin
    {
        public static Harmony InitHarmony;
        private void Awake()
        {
            Config.Bind<string>(
                section: "General",
                key: "None",
                defaultValue: "None",
                description: "nop"
            );
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
    }
}