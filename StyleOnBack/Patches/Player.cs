using HarmonyLib;
using Reptile;
using UnityEngine;

namespace StyleOnBack.Patches
{
    internal static class PlayerPatch
    {
        [HarmonyPatch(typeof(Player), nameof(Player.Init))]
        [HarmonyPostfix]
        private static void Player_Init_Postfix(Player __instance)
        {
            if (!__instance.isAI)
            {
                StyleOnBack.player = __instance;
                switch (__instance.moveStyleEquipped)
                {
                    case MoveStyle.BMX:
                        __instance.characterVisual.SetBMXPropsMode(CharacterVisual.MoveStylePropMode.ON_BACK);
                        break;
                    case MoveStyle.SKATEBOARD:
                        __instance.characterVisual.SetSkateboardPropsMode(CharacterVisual.MoveStylePropMode.ON_BACK);
                        break;
                    case MoveStyle.INLINE:
                        __instance.characterVisual.SetInlineSkatesPropsMode(CharacterVisual.MoveStylePropMode.ON_BACK);
                        break;
                    default:
                        break;
                }
                
            }
        }
    }
}