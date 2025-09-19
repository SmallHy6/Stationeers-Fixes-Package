using Assets.Scripts.UI;
using BepInEx.Logging;
using HarmonyLib;
using ImGuiNET;
using ImGuiNET.Unity;
using Stationeers_Fixes_Package;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Stationeers_Fixes_Package
{
    internal class Stationeers_Fixes_Package_Text_Fixes
    {
        [HarmonyPatch(typeof(ImGuiManager), "Awake")]
        public class ImGuiManager_Awake_Patch
        {
            private static string ImGui字体路径_主要 = Path.Combine(Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.FullName, "workshop/content/544550/3560271413/GameData/Font/Microsoft_YaHei.ttc");
            private static string ImGui字体路径_次要 = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "BepInEx/plugins/Stationeers-Fixes-Package/Font/Microsoft_YaHei.ttc");
            private static FieldInfo 字体引用偏移 = typeof(ImGuiManager).GetField("_fontAtlasConfiguration", BindingFlags.Instance | BindingFlags.NonPublic);
            public static void Postfix(ref ImGuiManager __instance)
            {
                // var 游戏程序目录 = System.AppDomain.CurrentDomain.BaseDirectory;     

                // 创建一个字体定义添加到配置文件中
                Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"{Plugin_Config.Name}.ImGui字体路径_主要: {ImGui字体路径_主要}");
                Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"{Plugin_Config.Name}.ImGui字体路径_次要: {ImGui字体路径_次要}");

                var _fontAtlasConfiguration = 字体引用偏移.GetValue(__instance) as FontAtlasConfigAsset;
                var Fonts = _fontAtlasConfiguration.Fonts;
                var _ = new FontDefinition[Fonts.Length + 1];

                ImGuiNET.Unity.FontDefinition 字体定义;
                if (File.Exists(ImGui字体路径_主要))
                {
                    扩展方法.创建ImGui字体定义(out 字体定义, ImGui字体路径_主要);
                }
                else
                {
                    扩展方法.创建ImGui字体定义(out 字体定义, ImGui字体路径_次要);
                }

                _[0] = Fonts[0];
                _[1] = Fonts[1];
                _[2] = 字体定义;
                for (var i = 3; i < _.Length; i++)
                    _[i] = Fonts[i - 1];
                _fontAtlasConfiguration.Fonts = _;
                // TODO: 是否需要销毁Fonts数组,防止内存泄露
            }
        }

        [HarmonyPatch(typeof(TextureManager), nameof(TextureManager.BuildFontAtlas))]
        public class TextureManager_BuildFontAtlas_Patch
        {
            private static MethodInfo AllocateGlyphRangeArray = typeof(TextureManager).GetMethod("AllocateGlyphRangeArray", BindingFlags.Instance | BindingFlags.NonPublic);
            public static bool Prefix(ref TextureManager __instance, ImGuiIOPtr io, in FontAtlasConfigAsset settings)
            {
                if (io.Fonts.IsBuilt())
                {
                    __instance.DestroyFontAtlas(io);
                }

                if (!io.MouseDrawCursor)
                {
                    io.Fonts.Flags |= ImFontAtlasFlags.NoMouseCursors;
                }

                if (settings == null)
                {
                    io.Fonts.AddFontDefault();
                    io.Fonts.Build();
                    return false;
                }

                FontDefinition[] fonts = settings.Fonts;

                for (int i = 0; i < 2; i++)
                {
                    FontDefinition fontDefinition = fonts[i];
                    string text = Path.Combine(Application.streamingAssetsPath, fontDefinition.FontPath);
                    if (!File.Exists(text))
                    {
                        Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"{Plugin_Config.Name}.字体路径不存在,生成图集失败: " + text);
                        continue;
                    }

                    ImFontConfig fontConfig = default(ImFontConfig);
                    ImFontConfigPtr imFontConfigPtr = new ImFontConfigPtr(ref fontConfig);
                    FontConfig config = fontDefinition.Config;
                    config.ApplyTo(imFontConfigPtr);
                    imFontConfigPtr.GlyphRanges = (IntPtr)AllocateGlyphRangeArray.Invoke(__instance, new object[] { fontDefinition.Config });
                    io.Fonts.AddFontFromFileTTF(text, fontDefinition.Config.SizeInPixels, imFontConfigPtr);
                }

                for (int i = 2; i < 3; i++)
                {
                    FontDefinition fontDefinition = fonts[i];
                    string text = fontDefinition.FontPath;
                    if (!File.Exists(text))
                    {
                        Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"{Plugin_Config.Name}.字体路径不存在,生成图集失败: " + text);
                        continue;
                    }

                    ImFontConfig fontConfig = default(ImFontConfig);
                    ImFontConfigPtr imFontConfigPtr = new ImFontConfigPtr(ref fontConfig);
                    FontConfig config = fontDefinition.Config;
                    config.ApplyTo(imFontConfigPtr);
                    imFontConfigPtr.GlyphRanges = (IntPtr)AllocateGlyphRangeArray.Invoke(__instance, new object[] { fontDefinition.Config });
                    io.Fonts.AddFontFromFileTTF(text, fontDefinition.Config.SizeInPixels, imFontConfigPtr);
                }

                for (int i = 3; i < fonts.Length; i++)
                {
                    FontDefinition fontDefinition = fonts[i];
                    string text = Path.Combine(Application.streamingAssetsPath, fontDefinition.FontPath);
                    if (!File.Exists(text))
                    {
                        Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"{Plugin_Config.Name}.字体路径不存在,生成图集失败: " + text);
                        continue;
                    }

                    ImFontConfig fontConfig = default(ImFontConfig);
                    ImFontConfigPtr imFontConfigPtr = new ImFontConfigPtr(ref fontConfig);
                    FontConfig config = fontDefinition.Config;
                    config.ApplyTo(imFontConfigPtr);
                    imFontConfigPtr.GlyphRanges = (IntPtr)AllocateGlyphRangeArray.Invoke(__instance, new object[] { fontDefinition.Config });
                    io.Fonts.AddFontFromFileTTF(text, fontDefinition.Config.SizeInPixels, imFontConfigPtr);
                }

                if (io.Fonts.Fonts.Size == 0)
                {
                    io.Fonts.AddFontDefault();
                }

                if (settings.Rasterizer == FontRasterizerType.StbTrueType)
                {
                    io.Fonts.Build();
                    return false;
                }

                Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Error, $"{Plugin_Config.Name}.{settings.Rasterizer:G} rasterizer not available, using {FontRasterizerType.StbTrueType:G}. Check if feature is enabled (PluginFeatures.cs).");
                io.Fonts.Build();

                return false;
            }
        }
        [HarmonyPatch(typeof(TMP_Settings), "defaultFontAsset", MethodType.Getter)]
        public class TMP_Settings_defaultFontAsset_Patch
        {
            // TMP组件若在构造时没有指定使用的字符图集,则默认使用defaultFontAsset这个字符图集
            // 注:LocalizedFont组件会在每帧渲染时替换回官方内置中文字体,因此此补丁的作用很小,仅仅用于小部分默认使用了英文字体的文本组件
            //    恰恰也正是这部分文本组件,会显示口口
            public static bool Prefix(ref TMP_FontAsset __result)
            {
                if (AssetsLoad.单例.内置TMP字体)
                {
                    __result = AssetsLoad.单例.内置TMP字体;
                    // 入口点类.Log.LogInfo("成功拦截TMP_Settings_defaultFontAsset_Patch");
                    return false;
                }
                else
                {
                    Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Error, $"{Plugin_Config.Name}.拦截失败TMP_Settings_defaultFontAsset_Patch");
                    return true;
                }
            }
        }

        [HarmonyPatch(typeof(TextMeshProUGUI), "Awake")]
        public class TextMeshProUGUI_Awake_Patch
        {
            public static void Postfix(ref TextMeshProUGUI __instance)
            {
                if (AssetsLoad.单例.内置TMP字体)
                    __instance.font = AssetsLoad.单例.内置TMP字体;
                //else
                //Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Error, $"{Plugin_Config.Name}.拦截失败TextMeshProUGUI_Awake_Patch");
            }
        }
    }
}
