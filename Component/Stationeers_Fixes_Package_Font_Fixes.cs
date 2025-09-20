// using System;
// using System.IO;
// using UnityEngine; // 必须包含的核心命名空间
// using UnityEngine.UI; // UGUI Text组件需要
// using TMPro; // TextMeshPro组件需要

// // 确保类在正确的命名空间下（可选，若使用命名空间需保持一致）
// namespace FontLoaderNamespace
// {
//     public class Unity2022FontLoader : MonoBehaviour
//     {
//         // 本地字体路径（可在Inspector设置或通过配置类获取）
//         public string localFontPath;

//         // 字体缓存
//         private Font _uguiFont;
//         private TMP_FontAsset _tmpFontAsset;
//         private Font _imguiFont;

//         private void Start()
//         {
//             // 从配置类获取路径（示例）
//             if (string.IsNullOrEmpty(localFontPath))
//             {
//                 localFontPath = LocationConfig.FontLocation1;
//             }

//             // 检查必要条件
//             if (CheckPrerequisites())
//             {
//                 LoadAndApplyFonts();
//             }
//         }

//         /// <summary>
//         /// 检查加载字体的必要条件
//         /// </summary>
//         private bool CheckPrerequisites()
//         {
//             // 检查命名空间引用（编译时自动检查，此处提示可能的缺失）
//             // 确保已勾选 TextMeshPro 包（Window > Package Manager）

//             // 检查文件是否存在
//             if (!File.Exists(localFontPath))
//             {
//                 Debug.LogError($"必要条件缺失：字体文件不存在 → {localFontPath}");
//                 return false;
//             }

//             // 检查字体格式（Unity 2022支持.ttf/.otf）
//             string extension = Path.GetExtension(localFontPath).ToLower();
//             if (extension != ".ttf" && extension != ".otf")
//             {
//                 Debug.LogError($"必要条件缺失：不支持的字体格式 → {extension}，请使用.ttf或.otf");
//                 return false;
//             }

//             return true;
//         }

//         /// <summary>
//         /// 加载并应用字体（使用Unity 2022支持的API）
//         /// </summary>
//         private void LoadAndApplyFonts()
//         {
//             try
//             {
//                 byte[] fontBytes = File.ReadAllBytes(localFontPath);

//                 _uguiFont = Font.cre(fontBytes, fontBytes.Length);
//                 _imguiFont = _uguiFont; // IMGUI与UGUI共用字体

//                 // 2. 转换为TextMeshPro字体资产
//                 _tmpFontAsset = TMP_FontAsset.CreateFontAsset(_uguiFont);

//                 // 3. 应用到所有文本组件
//                 ApplyToUGUI();
//                 ApplyToTMP();
//                 ApplyToIMGUI();

//                 Debug.Log("字体加载成功（Unity 2022兼容模式）");
//             }
//             catch (Exception e)
//             {
//                 Debug.LogError($"加载失败：{e.Message}\n可能原因：文件损坏、权限不足或字体格式错误");
//             }
//         }

//         // 应用到UGUI Text
//         private void ApplyToUGUI()
//         {
//             foreach (var text in FindObjectsOfType<Text>())
//             {
//                 text.font = _uguiFont;
//                 text.SetAllDirty();
//             }
//         }

//         // 应用到TextMeshPro
//         private void ApplyToTMP()
//         {
//             foreach (var tmpText in FindObjectsOfType<TMP_Text>())
//             {
//                 tmpText.font = _tmpFontAsset;
//                 tmpText.fontSharedMaterial = _tmpFontAsset.material;
//                 tmpText.SetAllDirty();
//             }
//         }

//         // 应用到IMGUI
//         private void ApplyToIMGUI()
//         {
//             if (GUI.skin != null)
//             {
//                 GUI.skin.font = _imguiFont;
//             }
//         }
//     }
// }
    