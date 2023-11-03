using HarmonyLib;
using Reptile;
using System;
using Unity;
using UnityEngine;

namespace MovementPlus.Patches
{
    internal static class BoostAbilityPatch
    {
        [HarmonyPatch(typeof(BoostAbility), nameof(BoostAbility.OnStartAbility))]
        [HarmonyPrefix]
        private static bool BoostAbility_OnStartAbility_Prefix(BoostAbility __instance)
        {
            __instance.haveAirStartBoost = false;
            __instance.equippedMovestyleWasUsed = __instance.p.usingEquippedMovestyle;
            /*if (__instance.p.moveStyleEquipped != MoveStyle.INLINE)
            {
                __instance.p.SwitchToEquippedMovestyle(false, false, true, false);
            }*/
            __instance.SetState(BoostAbility.State.START_BOOST);
            return false;
        }
    }
}
