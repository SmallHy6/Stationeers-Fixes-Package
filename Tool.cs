using Assets.Scripts.Inventory;
using Assets.Scripts.UI;
using BepInEx.Logging;
using ImGuiNET.Unity;
using Stationeers_Fixes_Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Stationeers_Fixes_Package
{
    public class SPDAListItem_延时修改 : 延时修改工具
    {
        protected override void 仅执行一次()
        {
            var 百科基因 = this.GetComponent<SPDAListItem>().InsertTitle;
            百科基因.text = 百科基因.text.词条匹配();
            // using (StreamWriter 写 = new StreamWriter($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/文本.txt", append: true))
            //     写.WriteLine($"case \"{百科基因.text}\": {{百科基因.text= \"\";break;}}");
        }
    }
    public class PanelHands_延时修改 : 延时修改工具
    {
        protected override void 仅执行一次()
        {
            var 左手 = this.transform.Find("LeftHand");
            var 左手文本 = 左手.Find("Text").GetComponent<TMP_Text>();
            左手文本.修改大小与遮罩(24);
            左手.Find("HandLeftSlot").GetComponent<SlotDisplayButton>().gameObject.AddComponent<SlotDisplay_延时修改>();

            var 右手 = this.transform.Find("RightHand");
            var 右手文本 = 右手.Find("Text").GetComponent<TMP_Text>();
            右手文本.修改大小与遮罩(24);
            右手.Find("HandRightSlot").GetComponent<SlotDisplayButton>().gameObject.AddComponent<SlotDisplay_延时修改>();
        }
    }

    public class SlotDisplay_延时修改 : 延时修改工具
    {
        private static bool 要改么 = true;
        protected override void 仅执行一次()
        {
            var 物品栏 = this.GetComponent<SlotDisplayButton>();
            var 捕获表 = 物品栏.遍历修改大小(文本字段偏移表工具<SlotDisplayButton>.文本字段偏移表, 23);
            foreach (var 文本 in 捕获表)
            {
                // 显示物品栏内物品数量的这个文本组件因为是数字,所以字可以调大些,并且设置下换行行为
                if (文本.name == "Quantity")
                {
                    文本.outlineWidth = 0.1f;                           // 字符的描边
                    文本.outlineColor = Color.grey;                     // 设置外轮廓颜色
                    文本.fontStyle = FontStyles.Bold;                   // 粗体字
                    文本.rectTransform.pivot = Vector2.one;             // TMP组件的文本变化时,区域也会相应缩放,锚定右上角不动,让布局区域向左下扩展
                    文本.alignment = TextAlignmentOptions.TopRight;     // 对齐方式设置为和父级区域右上对齐
                    文本.修改大小与遮罩(26);
                }
            }

            if (物品栏.gameObject.name.Contains("Hand"))
                return;

            var A = 物品栏.transform.parent;
            if (A)
            {
                var 包裹 = A.parent;
                if (包裹 && 包裹.childCount > 0)
                {
                    var B = 包裹.GetChild(0);
                    if (B && B.childCount > 0)
                    {
                        var C = B.GetChild(0);
                        if (C)
                        {
                            // 多个物品栏由一个包裹父级管理,通过层级找到物品栏标题文本组件
                            var 背包名称 = C.GetComponent<TMP_Text>();
                            if (背包名称)
                                背包名称.修改大小与遮罩(25);
                        }
                    }

                    var 适配 = 包裹.GetComponent<ContentSizeFitter>();

                    // 物品栏调整了字体尺寸后,占据的长度变长了,让背景也拉长
                    if (适配)
                        适配.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;

                    var 包裹Rect = 包裹.GetComponent<RectTransform>();
                    if (包裹Rect)
                        LayoutRebuilder.ForceRebuildLayoutImmediate(包裹Rect);
                }
            }

            if (要改么)
            {
                // 数量文本工具在循环中会改变字体大小,因此锁定此值
                const BindingFlags 标志 = BindingFlags.Static | BindingFlags.NonPublic;
                typeof(SlotDisplayButton).GetField("QuantityFontMinSize", 标志).SetValue(null, 26);
                typeof(SlotDisplayButton).GetField("QuantityFontMaxSize", 标志).SetValue(null, 26);
                要改么 = false;
                Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"{Plugin_Config.Name}.SlotDisplay_延时修改,物品栏数量文本锁定为28大小");
            }
        }
    }

    public class UniversalPage_延时修改 : 延时修改工具
    {
        protected override void 仅执行一次()
        {
            // F1百科中的逻辑条目中 名称 和  值
            var 实例 = this.GetComponent<UniversalPage>();
            var 捕获表 = 实例.遍历修改大小(文本字段偏移表工具<UniversalPage>.文本字段偏移表, 20);
            foreach (var 文本2 in 捕获表)
            {
                if (文本2.gameObject.name == "InfoValue")
                {
                    var InfoTitle = 文本2.transform.parent.Find("InfoTitle");
                    if (InfoTitle)
                    {
                        var 文本1 = InfoTitle.GetComponent<TMP_Text>();
                        文本1.修改大小与遮罩(20);
                    }
                }
            }
        }
    }
    public class SPDAVersion_延时修改 : 延时修改工具
    {
        protected override void 仅执行一次()
        {
            // 修改F1百科的生产设备等级栏的背景框高度,不然只修改字体大小,会导致字体超出了背景框
            var Layout = this.transform.parent.GetComponent<GridLayoutGroup>();
            Layout.cellSize = new Vector2(Layout.cellSize.x, 166);
        }
    }
    public abstract class 延时修改工具 : MonoBehaviour
    {
        // private float 计时器;
        // private void OnDestroy() => 入口类.Log.LogInfo($"成功销毁{this.GetType().Name}");
        private void Update()
        {
            if (WorldManager.IsGamePaused) { return; }
            if (!扩展方法.UI已生成么()) { return; }
            // 计时器 += Time.deltaTime;
            // if (计时器 < 0.5f) { return; }
            // 计时器 = 0;
            仅执行一次();
            Destroy(this);
        }
        protected abstract void 仅执行一次();
    }
    public static partial class 扩展方法
    {
        public static IEnumerable<FieldInfo> 获取字段偏移表(this Type 源, Type 目标)
        {
            const BindingFlags 标志 = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            return 源.GetFields(标志).Where(t => 目标.IsAssignableFrom(t.FieldType));
        }
        public static IEnumerable<TMP_Text> 遍历修改大小<T>(this T 实例, IEnumerable<FieldInfo> 字段偏移表, int 大小)
        {
            List<TMP_Text> 捕获表 = new List<TMP_Text>();
            foreach (var 偏移 in 字段偏移表)
            {
                // 直接按照地址偏移量访问内存,即在实例首地址+N处获取I个字节,不想查找有哪些变量是TMP组件了
                var 文本工具 = 偏移.GetValue(实例) as TMP_Text;
                if (文本工具)
                {
                    文本工具.修改大小与遮罩(大小);
                    捕获表.Add(文本工具);
                }
            }
            return 捕获表;
        }
        public static void 修改大小与遮罩(this TMP_Text 文本工具, int 大小)
        {
            if (文本工具.fontSize < 大小)
            {
                文本工具.fontSize = 大小;

                if (文本工具.fontSizeMax < 大小)
                {
                    文本工具.fontSizeMax = 大小;
                }

                文本工具.fontSizeMin = 大小;
            }
            文本工具.关闭遮罩();
        }
        public static void 关闭遮罩(this TMP_Text 文本工具)
        {
            文本工具.overflowMode = TextOverflowModes.Overflow;     // 超出RectTransform区域不截断,搭配自动换行使用
        }
        public static void 修改大小与遮罩(this Text 文本工具, int 大小)
        {
            if (文本工具.fontSize < 大小)
            {
                文本工具.fontSize = 大小;

                if (文本工具.resizeTextMaxSize < 大小)
                {
                    文本工具.resizeTextMaxSize = 大小;
                }

                文本工具.resizeTextMinSize = 大小;
            }
            文本工具.关闭遮罩();
        }
        public static void 关闭遮罩(this Text 文本工具)
        {
            文本工具.verticalOverflow = VerticalWrapMode.Overflow;
            文本工具.horizontalOverflow = HorizontalWrapMode.Overflow;
        }
        public static void 创建ImGui字体定义(out FontDefinition 字体定义, string ImGui字体路径)
        {
            字体定义 = new FontDefinition();
            字体定义.FontPath = ImGui字体路径;
            字体定义.Config.FontIndexInFile = 0;   // 如果一个字体文件包含多个字体，可以指定你想要加载的字体的索引
            字体定义.Config.SizeInPixels = 24;     // 设置字体的大小（以像素为单位）
            字体定义.Config.Oversample = Vector2Int.one;   // 字体的采样倍数
            字体定义.Config.PixelSnapH = true;             // 是否对齐到像素
            字体定义.Config.GlyphExtraSpacing = Vector2.zero;  // 字符额外水平间距
            字体定义.Config.GlyphOffset = Vector2.zero;        // 字符的偏移量
            字体定义.Config.GlyphRanges = FontConfig.ScriptGlyphRanges.ChineseFull;     // 字符集范围
            字体定义.Config.GlyphMinAdvanceX = 0;  // 设置字符的最小和最大水平间距（AdvanceX）。用于调整字符对齐和宽度。
            字体定义.Config.GlyphMaxAdvanceX = 20;
            字体定义.Config.MergeIntoPrevious = false; // 字体合并到前一个字体配置中,这对于将多个字体合并为一个字体集时很有用
            字体定义.Config.RasterizerFlags = 0;       // 用于自定义字体栅格化器的标志
            字体定义.Config.RasterizerMultiply = 1;    // 字体亮度系数
            字体定义.Config.EllipsisChar = '…';        // 用于指定省略号（...）的字符
            // 字体配置.CustomGlyphRanges = new FontConfig.Range[] { new FontConfig.Range { Start = 1, End = 65535 } };  // 用户自定义的Unicode字符范围
            
        }
        public static bool UI已生成么() => InventoryManager.Instance && PlayerStateWindow.Instance;
        public static string 去除富文本标记(string 源) => Regex.Replace(WebUtility.HtmlDecode(源), @"<[^>]+>", string.Empty);
        public static IEnumerable<HarmonyLib.CodeInstruction> 修改IL代码中的字符串(this IEnumerable<HarmonyLib.CodeInstruction> IL)
        {
            var IL代码 = new List<HarmonyLib.CodeInstruction>(IL);
            // 指令结构请参考逻辑分拣机的指令结构,基本原理相同
            for (var i = 0; i < IL代码.Count; i++)
            {
                if (IL代码[i].opcode == OpCodes.Ldstr)
                {
                    if (IL代码[i].operand is string 内容)
                    { IL代码[i].operand = 内容.词条匹配(); }
                }
            }

            return IL代码;
        }
    }
    public static class 文本字段偏移表工具<T> where T : class
    {
        // 单例:每一个类型共用一份偏移表
        private static IEnumerable<FieldInfo> 偏移表 = null;
        public static IEnumerable<FieldInfo> 文本字段偏移表
        {
            get
            {
                if (偏移表 == null)
                    偏移表 = typeof(T).获取字段偏移表(typeof(TMP_Text));
                return 偏移表;
            }
        }
    }
    public class Utils
    {
        public static T 构造节点<T>(string 名称 = null) where T : Component => 构造节点<T>((Transform)null, 名称);
        public static T 构造节点<T>(GameObject parent, string 名称 = null) where T : Component => 构造节点<T>(parent ? parent.transform : null, 名称);
        public static T 构造节点<T>(Component parent, string 名称 = null) where T : Component => 构造节点<T>(parent ? parent.transform : null, 名称);
        public static T 构造节点<T>(Transform parent, string 名称 = null) where T : Component
        {
            // Component类默认在构造中将unity引擎设为父级,纳入unity引擎的主循环
            var 节点 = new GameObject().AddComponent<T>();
            节点.name = $"({typeof(T).Name}){(名称 != null ? $" {名称}" : null)}";
            节点.gameObject.SetActive(false);
            if (parent != null)
            {
                节点.transform.SetParent(parent, false);
                节点.transform.localPosition = Vector3.zero;
                节点.transform.localRotation = Quaternion.identity;
                节点.transform.localScale = Vector3.one;
            }
            return 节点;
        }
        public static GameObject 构造节点(GameObject parent)
        {
            var 节点 = new GameObject();
            节点.SetActive(false);
            if (parent != null)
            {
                节点.transform.SetParent(parent.transform, false);
                节点.transform.localPosition = Vector3.zero;
                节点.transform.localRotation = Quaternion.identity;
                节点.transform.localScale = Vector3.one;
            }
            return 节点;
        }
        public static void 销毁节点(Component obj)
        {
            if (obj != null) { 销毁节点(obj.gameObject); }
        }
        public static void 销毁节点(GameObject obj)
        {
            if (obj != null) { UnityEngine.Object.Destroy(obj); }
        }
#pragma warning disable CS0618
        public static void 唤醒节点(Component obj) => 唤醒节点(obj ? obj.gameObject : null);
        public static void 唤醒节点(GameObject obj)
        {
            if (obj != null) { obj.SetActiveRecursively(true); }
        }
        public static void 休眠节点(Component obj) => 休眠节点(obj ? obj.gameObject : null);
        public static void 休眠节点(GameObject obj)
        {
            if (obj != null) { obj.SetActiveRecursively(false); }
        }
        public static void 销毁子级节点(Transform obj)
        {
            if (obj == null) { return; }
            foreach (Transform child in obj) { 销毁节点(child.gameObject); }
        }
        public static void 休眠子级节点(Transform obj)
        {
            if (obj == null) { return; }
            foreach (Transform child in obj) { child.gameObject.SetActive(false); }
        }
        public static VerticalLayoutGroup 构造VL_(Component parent, string 名称 = null) => 构造VL_(parent?.gameObject, 名称);   // 布局的父级可以传空
        private static VerticalLayoutGroup 构造VL_(GameObject parent, string 名称 = null) => (VerticalLayoutGroup)VlHl_Init(构造节点<VerticalLayoutGroup>(parent, 名称));
        private static HorizontalLayoutGroup 构造HL_(Component parent, string 名称 = null) => 构造HL_(parent?.gameObject, 名称); // 布局的父级可以传空
        private static HorizontalLayoutGroup 构造HL_(GameObject parent, string 名称 = null) => (HorizontalLayoutGroup)VlHl_Init(构造节点<HorizontalLayoutGroup>(parent, 名称));
        private static TextMeshProUGUI 构造TMP(Component parent, string 名称 = null) => 构造TMP(parent.gameObject, 名称);
        private static TextMeshProUGUI 构造TMP(GameObject parent, string 名称 = null) => TMPInit(构造节点<TextMeshProUGUI>(parent, 名称));
        private static HorizontalOrVerticalLayoutGroup VlHl_Init(HorizontalOrVerticalLayoutGroup layout)
        {
            // 每次布局相当于一次深度搜索,上级需要根据自身的区域和起始坐标信息配置子级的区域和子级的起始坐标信息
            layout.childAlignment = TextAnchor.UpperLeft;   // 用过排版软件的对齐功能就明白了
            layout.spacing = 0;
            layout.padding = new RectOffset(0, 0, 0, 0);
            layout.childControlWidth = false;               // 例:有两个TMP子级,A字数=2,B字数=3,而上级宽为15,以下是简易比例计算,实际还包括字间距,字体不同字宽不同等等
            layout.childControlHeight = false;              //    则15*[A字数*字宽/(A字数*字宽+B字数*字宽)]+15*[B字数*字宽/(A字数*字宽+B字数*字宽)]=15
            layout.childForceExpandWidth = false;           // 例:有两个子级,区域宽分别为2和3,而上级宽为15
            layout.childForceExpandHeight = false;          //    则15-2-3=10, 2+10*[2/(2+3)]+3+10*[3/(2+3)]=15
            layout.childScaleWidth = false;
            layout.childScaleHeight = false;
            return layout;
        }
        private static TextMeshProUGUI TMPInit(TextMeshProUGUI tmp)
        {
            tmp.alignment = TextAlignmentOptions.TopLeft;   // tmp.rectTransform.anchorMin和anchorMax设置,区域与父级区域左上对齐
            tmp.rectTransform.pivot = Vector2.up;           // TMP组件的文本变化时,区域也会相应缩放,锚定左上角不动,让布局区域向右向下扩展
            tmp.lineSpacing = 0;                            // 字符之间的行间距  
            tmp.characterSpacing = 0;                       // 字符之间的列间距  
            tmp.margin = Vector4.zero;                      // 区域内间距预留多少后是实际文本绘制区域,分别是距左,距上,距右,距下
            tmp.text = "0000";
            tmp.font = AssetsLoad.单例.内置TMP字体;
            tmp.fontSize = 24;                               // 字体尺寸请尽量设置成TMP字体原始大小的整数倍,确保缩放采样时最外围能对齐,而不是因为四舍五入导致采样像素错位导致锯齿,可通过打印字体信息获取原始大小
            tmp.color = Color.white;                        // 单字的透明度指的是对RGB分量的修饰
            tmp.alpha = 1;                                  // 文本的透明度指的是文本所在图层与其它图层混叠时的透明系数
            tmp.richText = true;                            // 是否启用富文本语言解析器
            tmp.maskable = true;                            // 是否可被遮罩
            tmp.overflowMode = TextOverflowModes.Truncate;  // 如果文本绘制和区域冲突了,以区域为准,超出部分截断 注:区域仅仅是提供绘制的起始坐标 例:A的超始坐标是(2,3),A区域宽高是(3,3),垂直分布,则B起始坐标是(2,6)
            tmp.enableWordWrapping = true;                  // 是否可自动换行
            tmp.fontStyle = FontStyles.Normal;              // 字符的描边,unity引擎对字符描边的几种模板化的配置
            tmp.outlineWidth = 0;                           // 字符的描边,自定义描边配置
            return tmp;
        }
        public static void Add_ContentSizeFitter(Component obj)
        {
            var fitter = obj.GetOrAddComponent<ContentSizeFitter>();
            fitter.horizontalFit = ContentSizeFitter.FitMode.Unconstrained;
            fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
        }
        public static readonly Vector4 TMP内缩_屏幕 = new Vector4(3, 3, 3, 3);  // TextMeshProUGUI实际文本像素区域相对于背景区域的内缩距离
        public static readonly Vector4 TMP内缩_世界 = new Vector4(0.006f, 0.006f, 0.006f, 0.006f);  // 同上,但是世界坐标是仿真的,比如人物也只有1.5左右高,由unity引擎转换成屏幕坐标
        public static TextMeshProUGUI 构造TMP(RectTransform parentRect, string 绘制文本, bool 世界坐标系么, string 名称 = null)
        {
            var tmp = Utils.构造TMP(parentRect, 名称);
            Add_ContentSizeFitter(tmp);
            tmp.rectTransform.sizeDelta = new Vector2(parentRect.rect.width, 0);
            tmp.margin = 世界坐标系么 ? TMP内缩_世界 : TMP内缩_屏幕;
            tmp.text = 绘制文本;
            return tmp;
        }
        public Button 构造可点击渲染组件(RectTransform parentRect)
        {
            var 区域尺寸 = new Vector2(640, 50);

            var hl = 构造HL_(parentRect);
            hl.childAlignment = TextAnchor.MiddleLeft;
            hl.childControlHeight = true;

            var hlRect = hl.GetComponent<RectTransform>();
            hlRect.pivot = Vector2.up;
            hlRect.anchorMax = Vector2.up;
            hlRect.anchorMin = Vector2.up;
            hlRect.sizeDelta = 区域尺寸;

            Button 点击按钮 = hlRect.gameObject.AddComponent<Button>();
            var 点击区域 = 点击按钮.gameObject.AddComponent<RawImage>();
            点击按钮.targetGraphic = 点击区域;
            var __ = 点击区域.rectTransform;
            __.anchorMax = Vector2.one;
            __.anchorMin = Vector2.zero;

            var 类型描述 = 构造TMP(点击按钮, "类型描述");
            类型描述.修改大小与遮罩(28);
            类型描述.alignment = TextAlignmentOptions.Left;
            类型描述.font = AssetsLoad.单例.内置TMP字体;
            类型描述.rectTransform.anchorMax = Vector2.one;
            类型描述.rectTransform.anchorMin = Vector2.zero;

            // 设置按钮的颜色变化
            Color 正常颜色 = new Color(0, 0, 0, 0.8f);
            Color 悬停颜色 = new Color(0, 0.3f, 0, 0.8f);
            Color 点击颜色 = new Color(0, 0, 0.3f, 0.8f);

            var 按钮颜色 = 点击按钮.colors;

            按钮颜色.normalColor = 正常颜色;    // 默认颜色
            按钮颜色.highlightedColor = 悬停颜色; // 悬停高亮颜色
            按钮颜色.pressedColor = 点击颜色;    // 点击颜色
            按钮颜色.disabledColor = 点击颜色;  // 禁用颜色
            按钮颜色.selectedColor = 悬停颜色;  // 活动项颜色

            点击按钮.colors = 按钮颜色;
            点击按钮.transition = Selectable.Transition.ColorTint;

            // 关掉按钮焦点,启用此选项时,按钮状态会保持在最后单击的那个按钮上,导致颜色不好看
            var 按钮焦点 = 点击按钮.navigation;
            按钮焦点.mode = Navigation.Mode.None;
            点击按钮.navigation = 按钮焦点;

            return 点击按钮;
        }
    }
}
