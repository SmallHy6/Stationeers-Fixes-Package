// // UIManager.cs
// using UnityEngine;
// using UnityEngine.UI;
// using System.Collections.Generic;
// using BepInEx.Logging;

// namespace Stationeers_Fixes_Package
// {
//   // UI 管理器：仅负责创建和管理 UI，不涉及任何 Harmony 补丁
//   public class UI_Config
//   {
//     private Canvas UiCanvas;
//     private GameObject UiCanvasObj = new GameObject("ConfigCanvas");
//     private Dictionary<string, Toggle> generalToggles = new Dictionary<string, Toggle>();

//     // 初始化 UI（供外部调用）
//     public static void Initialize()
//     {
//       Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"{Plugin_Config.Name}.UI_Config.初始化成功!");
//       Create_Dictionary.Write_Dictionary();
//       Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"{Plugin_Config.Name}.UI_Config.加载字典成功!");
//       UI_Config PrivateInitialize = new UI_Config();
//       PrivateInitialize.CreateUiCanvas();
//       PrivateInitialize.CreateBackground();
//       Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"{Plugin_Config.Name}.UI_Config.创建UI成功!");
//     }
//     // 创建画布（纯 UI 逻辑）
//     private void CreateUiCanvas()
//     {
//       UiCanvas = UiCanvasObj.AddComponent<Canvas>();
//       UiCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
//       UiCanvas.sortingOrder = 100;
//       UiCanvasObj.AddComponent<CanvasScaler>();
//       UiCanvasObj.AddComponent<GraphicRaycaster>();
//       Object.DontDestroyOnLoad(UiCanvasObj);
//     }

//     // 创建顶部功能栏（纯 UI 逻辑）
//     private void CreateBackground()
//     {
//       // 顶部容器
//       GameObject ObjName = new GameObject("CanvasBackground");
//       ObjName.transform.SetParent(UiCanvas.transform);
//       // ... 省略布局和背景设置（同之前的 UI 代码）
//       // 关键：设置 PropertiesTransform 布局（锚定到顶部，宽度适配屏幕，高度固定）
//       RectTransform Properties = ObjName.AddComponent<RectTransform>();
//       Properties.anchorMin = new Vector2(0.3f, 0.3f);
//       Properties.anchorMax = new Vector2(0.7f, 0.7f);
//       Properties.pivot = new Vector2(0.5f, 0.5f);     //  pivot 点在顶部中心
//       Properties.offsetMin = new Vector2(0, 0);  // 左、下偏移（高度 60）
//       Properties.offsetMax = new Vector2(0, 0);    // 右、上偏移（宽度充满屏幕）
//       Properties.anchoredPosition = new Vector2(0f, 0f); // x=0, y=0 即正中心

//       // 可选：添加背景以便观察
//       Image background = ObjName.AddComponent<Image>();
//       background.color = new Color(0.1f, 0.1f, 0.1f, 1); // 深色半透明背景
//       // 添加布局组件：自动排列子控件（水平排列）
//       HorizontalLayoutGroup layout = ObjName.AddComponent<HorizontalLayoutGroup>();
//       layout.padding = new RectOffset(20, 20, 10, 10); // 内边距
//       layout.spacing = 20; // 子控件间距
//       layout.childAlignment = TextAnchor.MiddleCenter; // 子控件对齐方式
//       // 创建 General 栏
//       CreateTopBar(
//           Parent: ObjName.transform,
//           Title: "General",
//           Options: new List<string> { "启用自动修复", "显示提示" },
//           TogglesDict: generalToggles
//       );
//     }
//     private void CreateTopBar(Transform Parent, string Title, List<string> Options, Dictionary<string, Toggle> TogglesDict)
//     {
//       GameObject ObjName = new GameObject("CanvasTopBarGeneralMenu");
//       ObjName.transform.SetParent(UiCanvas.transform);
//       // ... 省略布局和背景设置（同之前的 UI 代码）
//       // 关键：设置 PropertiesTransform 布局（锚定到顶部，宽度适配屏幕，高度固定）
//       Button Properties = ObjName.AddComponent<Button>();
//       Image PropertiesImage = ObjName.AddComponent<Image>();
//       PropertiesImage.color = new Color(0.1f, 0.1f, 0.1f, 1f);

//       GameObject PropertiesTextObj = new GameObject("CanvasPropertiesText");
//       PropertiesTextObj.transform.SetParent(ObjName.transform);
//       Text PropertiesText = PropertiesTextObj.AddComponent<Text>();
//       PropertiesText.text = UI_Config_Css.UI_Config_Css_Dictionary["TopBarText1"];
//       PropertiesText.font = (LocationConfig.FontLocation1);
//       RectTransform PropertiesTextRect = ObjName.GetComponent<RectTransform>();
//       PropertiesTextRect.anchorMin = new Vector2(1f, 0.5f);
//       PropertiesTextRect.anchorMax = new Vector2(1f, 0.5f);
//     }
//   }
// }
