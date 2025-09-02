using Assets.Scripts.Objects;
using Assets.Scripts.Objects.Motherboards;
using Assets.Scripts.UI;
using BepInEx.Logging;
using HarmonyLib;
using Stationeers_Fixes_Package;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace meanran_xuexi_mods_xiaoyouhua
{
    [HarmonyPatch(typeof(Prefab), nameof(Prefab.LoadAll))]
    public class Prefab_LoadAll_Patch
    {
        public static void Postfix()
        {
            if (AssetsLoad.单例.内置TMP字体)
            {
                var 所有资源 = AssetsLoad.单例.所有资源;
                foreach (var Object in 所有资源)
                {
                    var type = Object.GetType();

                    if (type == typeof(GameObject))
                    {
                        var obj = Object as GameObject;
                        switch (obj.name)
                        {
                            case "PrefabReference":
                                {
                                    var 生产菜单项目 = obj.transform.GetChild(0).GetComponent<TMP_Text>();
                                    生产菜单项目.font = AssetsLoad.单例.内置TMP字体;
                                    生产菜单项目.修改大小与遮罩(28);

                                    链接选择面板.选项按钮预制体 = UnityEngine.Object.Instantiate(obj);
                                    链接选择面板.选项按钮预制体.SetActive(false);
                                    var ILogicableReference = 链接选择面板.选项按钮预制体.AddComponent<ILogicableReference>();
                                    链接选择面板.选项按钮预制体.name = "数据网节点UI单元";
                                    var _ = 链接选择面板.选项按钮预制体.GetComponent<PrefabReference>();
                                    ILogicableReference.缩略图 = _.Thumbnail;
                                    ILogicableReference.描述 = _.Text;
                                    ILogicableReference.UiComponentRenderer = _.UiComponentRenderer;
                                    ILogicableReference.GameObject = _.GameObject;
                                    ILogicableReference.Transform = _.Transform;
                                    UnityEngine.Object.Destroy(_);
                                    Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"{Plugin_Config.Name}.成功增加数据网节点UI单元=>ILogicableReference");
                                    break;
                                }
                            case "PanelInputPrefabs":
                                {
                                    var __ = UnityEngine.Object.Instantiate(obj);
                                    __.gameObject.name = "链接选择面板";
                                    var _ = __.GetComponent<InputPrefabs>();
                                    链接选择面板.单例 = __.gameObject.AddComponent<链接选择面板>();
                                    链接选择面板.单例.面板标题 = _.TitleText;
                                    链接选择面板.单例.可链接物渲染分支 = _.GroupParents;
                                    链接选择面板.单例.面板搜索栏 = _.SearchBar;
                                    链接选择面板.单例.UiComponentRenderer = _.UiComponentRenderer;
                                    链接选择面板.单例.GameObject = _.GameObject;
                                    链接选择面板.单例.Transform = _.Transform;

                                    Utils.销毁子级节点(__.transform.GetChild(0).GetChild(7).GetChild(1).GetChild(0));
                                    UnityEngine.Object.Destroy(_);
                                    链接选择面板.单例.Initialize();
                                    // Prefab.OnPrefabsLoaded += 单例.初始化;
                                    // 注:独立面板挂在任意一个有画布组件的容器中都可
                                    链接选择面板.父级画布 = obj.transform.parent.gameObject;
                                    链接选择面板.单例.transform.SetParent(链接选择面板.父级画布.transform, false); ;

                                    Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"{Plugin_Config.Name}.成功增加数据网节点UI面板=>链接选择面板");
                                    break;
                                }
                        }
                    }

                }
            }
        }
    }
}