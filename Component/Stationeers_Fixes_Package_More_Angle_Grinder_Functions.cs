using Assets.Scripts.Localization2;
using Assets.Scripts.Objects;
using Assets.Scripts.Objects.Items;
using Assets.Scripts.Objects.Pipes;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stationeers_Fixes_Package
{
    [HarmonyPatch(typeof(Assets.Scripts.Objects.Structure), nameof(Structure.AttackWith))]
    internal class Stationeers_Fixes_Package_More_Angle_Grinder_Functions
    {
        [HarmonyPrefix]
        public static bool 操作事件处理(Structure __instance, ref Thing.DelayedActionInstance __result, Attack attack, bool doAction = true)
        {
            // 发起交互方的活动手上的工具是角磨机,并且管道不是炸开状态
            if (attack.SourceItem is AngleGrinder 角磨机 && __instance is Pipe 管道 && 管道.IsBurst == Assets.Scripts.Networks.PipeBurst.False)
            {
                Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"{Plugin_Config.Name}.更多角磨机功能.补丁成功!");
                var 动作消息 = new Thing.DelayedActionInstance
                { Duration = 0, ActionMessage = "" };
                __result = 角磨机爆破管道(管道, 动作消息, 角磨机, doAction);
                Stationeers_Fixes_Package_Initialization.BepinExTool().BepinExMessage(LogLevel.Warning, $"{Plugin_Config.Name}.更多角磨机功能.修复成功!");
                return false;
            }

            // 其他情况执行游戏自带的交互逻辑
            return true;
        }

        public static Thing.DelayedActionInstance 角磨机爆破管道(Pipe 管道, Thing.DelayedActionInstance 默认动作消息, AngleGrinder 角磨机, bool 玩家有动作么 = true)
        {
            // 重要!重要!玩家有动作么只有在协程内部才会写入true,在正常时永远是false
            // 当调用默认动作状态消息.Succeed()给IsDisabled写入false时,表示允许开启协程,当单击左键时,创建动作协程
            // 当调用默认动作状态消息.Fail()给IsDisabled写入true,表示禁止开启协程,当单击左键时,直接忽略
            // 在协程函数内部,判断若鼠标左键弹起或者视线乱唤导致光线命中的焦点物体改变了,直接结束协程,不产生任何AttackWith消息
            // 在协程函数内部,若长按时长>=默认动作状态消息.Duration,产生一个玩家有动作么=true的AttackWith消息

            Thing.DelayedActionInstance 动作状态消息 = null;
            // 仅用于协程函数的时长定义,正常不使用Duration
            默认动作消息.Duration = 2;
            // 仅用于正常函数的视线焦点物体工具提示,左上角
            默认动作消息.ActionMessage = "切开";

            // 角磨机电池未安装或者没有电量,仅显示工具提示面板:未通电,无法交互
            if (!角磨机.IsOperable)
            {
                // ActionMessage:禁用时切开是红色字,不允许创建动作协程
                动作状态消息 = 默认动作消息.Fail(GameStrings.DeviceNoPower);
            }

            // 角磨机有电量
            if (动作状态消息 == null)
            {
                // 仅用于正常函数的视线焦点物体工具提示,主面板
                默认动作消息.AppendStateMessage("使用角磨机切开管道,使流体排出");
                // ActionMessage:启用时切开是绿色字,允许创建动作协程
                动作状态消息 = 默认动作消息.Succeed();


                // 协程函数完美执行结束后,发送一条玩家有动作么=true的AttackWith消息,播放角磨机音效,并调用管道高压炸开协程函数
                if (玩家有动作么)
                {
                    // 播放音效
                    角磨机.PlaySound(AngleGrinder.UnEquipGrinderHash, 1f, 1f);
                    管道.BurstPipe(Assets.Scripts.Networks.PipeBurst.Pressure).Forget();
                }
            }

            return 动作状态消息;
        }

    }
}
