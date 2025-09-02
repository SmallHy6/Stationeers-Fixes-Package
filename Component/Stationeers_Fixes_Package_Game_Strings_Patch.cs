using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Stationeers_Fixes_Package
{
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
