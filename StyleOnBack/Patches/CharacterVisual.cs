using HarmonyLib;
using Reptile;
using System;
using Unity;
using UnityEngine;
using UnityEngine.Rendering;

namespace StyleOnBack.Patches
{
    internal static class CharacterVisualPatch
    {
        public static GameObject inlineParent;
        public static GameObject skateboardParent;
        public static GameObject bmxParent;
        public static bool inlineDoOnce = false;
        public static bool skateboardDoOnce = false;
        public static bool bmxDoOnce = false;


        [HarmonyPatch(typeof(CharacterVisual), nameof(CharacterVisual.SetInlineSkatesPropsMode))]
        [HarmonyPrefix]
        private static bool CharacterVisual_SetInlineSkatesPropsMode_Prefix(CharacterVisual.MoveStylePropMode mode, CharacterVisual __instance)
        {
            if (__instance.transform.root.GetComponent<Player>() != null)
            {
                if (__instance.transform.root.GetComponent<Player>().isAI) { return true; }
            }

            __instance.moveStyleProps.skateL.SetActive(mode == CharacterVisual.MoveStylePropMode.ACTIVE);
            __instance.moveStyleProps.skateR.SetActive(mode == CharacterVisual.MoveStylePropMode.ACTIVE);

            if (mode == CharacterVisual.MoveStylePropMode.ACTIVE)
            {
                __instance.moveStyleProps.skateL.transform.parent = __instance.footL;
                __instance.moveStyleProps.skateR.transform.parent = __instance.footR;
                __instance.moveStyleProps.skateL.transform.SetToIdentity();
                __instance.moveStyleProps.skateR.transform.SetToIdentity();
                __instance.moveStyleProps.skateL.transform.localScale = Vector3.one * 1f;
                __instance.moveStyleProps.skateR.transform.localScale = Vector3.one * 1f;
                inlineDoOnce = true;
                return false;
            }
            if (mode == CharacterVisual.MoveStylePropMode.ON_BACK)
            {

                if (inlineParent == null)
                {
                    inlineParent = new GameObject("inlineParent");
                }
                if (inlineDoOnce)
                {
                    StyleOnBack.DestroyTheChild(inlineParent.transform);
                    inlineDoOnce = false;
                }

                __instance.moveStyleProps.skateL.SetActive(true);
                __instance.moveStyleProps.skateR.SetActive(true);

                //Inline Left
                __instance.moveStyleProps.skateL.transform.parent = inlineParent.transform;
                __instance.moveStyleProps.skateL.transform.SetToIdentity();
                __instance.moveStyleProps.skateL.transform.localPosition = StyleOnBack.skateLPos.Value;
                __instance.moveStyleProps.skateL.transform.localRotation = Quaternion.Euler(StyleOnBack.skateLRot.Value);
                __instance.moveStyleProps.skateL.transform.localScale = Vector3.one * StyleOnBack.skateLScale.Value;
                //

                //Inline Right
                __instance.moveStyleProps.skateR.transform.parent = inlineParent.transform;
                __instance.moveStyleProps.skateR.transform.SetToIdentity();
                __instance.moveStyleProps.skateR.transform.localPosition = StyleOnBack.skateRPos.Value;
                __instance.moveStyleProps.skateR.transform.localRotation = Quaternion.Euler(StyleOnBack.skateRRot.Value);
                __instance.moveStyleProps.skateR.transform.localScale = Vector3.one * StyleOnBack.skateRScale.Value;
                //

                inlineParent.transform.parent = __instance.root.FindRecursive(StyleOnBack.skateBoneName.Value);
                inlineParent.transform.localPosition = StyleOnBack.skateGlobalPos.Value;
                inlineParent.transform.localRotation = Quaternion.Euler(StyleOnBack.skateGlobalRot.Value);
                inlineParent.transform.localScale = Vector3.one * StyleOnBack.skateGlobalScale.Value;
            }
            return false;
        }

        [HarmonyPatch(typeof(CharacterVisual), nameof(CharacterVisual.SetSkateboardPropsMode))]
        [HarmonyPrefix]
        private static bool CharacterVisual_SetSkateboardPropsMode_Prefix(CharacterVisual.MoveStylePropMode mode, CharacterVisual __instance)
        {
            if (__instance.transform.root.GetComponent<Player>() != null)
            {
                if (__instance.transform.root.GetComponent<Player>().isAI) { return true; }
            }

            __instance.moveStyleProps.skateboard.SetActive(mode == CharacterVisual.MoveStylePropMode.ACTIVE);

            if (mode == CharacterVisual.MoveStylePropMode.ACTIVE)
            {

                __instance.moveStyleProps.skateboard.transform.parent = __instance.skateboardBone;
                __instance.moveStyleProps.skateboard.transform.SetToIdentity();
                __instance.moveStyleProps.skateboard.transform.localScale = Vector3.one * 1f;
                skateboardDoOnce = true;
                return false;
            }
            if (mode == CharacterVisual.MoveStylePropMode.ON_BACK)
            {

                if (skateboardParent == null)
                {
                    skateboardParent = new GameObject("skateboardParent");
                }
                if (skateboardDoOnce)
                {
                    StyleOnBack.DestroyTheChild(skateboardParent.transform);
                    skateboardDoOnce = false;
                }

                //Skateboard
                __instance.moveStyleProps.skateboard.SetActive(true);
                __instance.moveStyleProps.skateboard.transform.parent = skateboardParent.transform;
                __instance.moveStyleProps.skateboard.transform.localPosition = StyleOnBack.skateboardPos.Value;
                __instance.moveStyleProps.skateboard.transform.localRotation = Quaternion.Euler(StyleOnBack.skateboardRot.Value);
                __instance.moveStyleProps.skateboard.transform.localScale = Vector3.one * StyleOnBack.skateboardScale.Value;
                //

                skateboardParent.transform.parent = __instance.root.FindRecursive(StyleOnBack.skateboardBoneName.Value);
                skateboardParent.transform.localPosition = StyleOnBack.skateboardGlobalPos.Value;
                skateboardParent.transform.localRotation = Quaternion.Euler(StyleOnBack.skateboardGlobalRot.Value);
                skateboardParent.transform.localScale = Vector3.one * StyleOnBack.skateboardGlobalScale.Value;
            }
            return false;
        }

        [HarmonyPatch(typeof(CharacterVisual), nameof(CharacterVisual.SetBMXPropsMode))]
        [HarmonyPrefix]
        private static bool CharacterVisual_SetBMXPropsMode_Prefix(CharacterVisual.MoveStylePropMode mode, CharacterVisual __instance)
        {
            if (__instance.transform.root.GetComponent<Player>() != null)
            {
                if (__instance.transform.root.GetComponent<Player>().isAI) { return true; }
            }

            __instance.moveStyleProps.bmxFrame.SetActive(mode == CharacterVisual.MoveStylePropMode.ACTIVE);
            __instance.moveStyleProps.bmxHandlebars.SetActive(mode == CharacterVisual.MoveStylePropMode.ACTIVE);
            __instance.moveStyleProps.bmxWheelR.SetActive(mode == CharacterVisual.MoveStylePropMode.ACTIVE);
            __instance.moveStyleProps.bmxWheelF.SetActive(mode == CharacterVisual.MoveStylePropMode.ACTIVE);
            __instance.moveStyleProps.bmxGear.SetActive(mode == CharacterVisual.MoveStylePropMode.ACTIVE);
            __instance.moveStyleProps.bmxPedalL.SetActive(mode == CharacterVisual.MoveStylePropMode.ACTIVE);
            __instance.moveStyleProps.bmxPedalR.SetActive(mode == CharacterVisual.MoveStylePropMode.ACTIVE);

            if (mode == CharacterVisual.MoveStylePropMode.ACTIVE)
            {

                __instance.moveStyleProps.bmxFrame.transform.parent = __instance.bmxFrameBone;
                __instance.moveStyleProps.bmxFrame.transform.SetToIdentity();

                __instance.moveStyleProps.bmxHandlebars.transform.parent = __instance.bmxHandlebarsBone;
                __instance.moveStyleProps.bmxHandlebars.transform.SetToIdentity();

                __instance.moveStyleProps.bmxWheelR.transform.parent = __instance.bmxWheelRBone;
                __instance.moveStyleProps.bmxWheelR.transform.SetToIdentity();

                __instance.moveStyleProps.bmxWheelF.transform.parent = __instance.bmxWheelFBone;
                __instance.moveStyleProps.bmxWheelF.transform.SetToIdentity();

                __instance.moveStyleProps.bmxGear.transform.parent = __instance.bmxGearBone;
                __instance.moveStyleProps.bmxGear.transform.SetToIdentity();

                __instance.moveStyleProps.bmxPedalL.transform.parent = __instance.bmxPedalLBone;
                __instance.moveStyleProps.bmxPedalL.transform.SetToIdentity();

                __instance.moveStyleProps.bmxPedalR.transform.parent = __instance.bmxPedalRBone;
                __instance.moveStyleProps.bmxPedalR.transform.SetToIdentity();
                bmxDoOnce = true;
                return false;
            }
            if (mode == CharacterVisual.MoveStylePropMode.ON_BACK)
            {

                if (bmxParent == null)
                {
                    bmxParent = new GameObject("bmxParent");
                }
                if (bmxDoOnce)
                {
                    StyleOnBack.DestroyTheChild(bmxParent.transform);
                    bmxDoOnce = false;
                }

                __instance.moveStyleProps.bmxFrame.SetActive(true);
                __instance.moveStyleProps.bmxHandlebars.SetActive(true);
                __instance.moveStyleProps.bmxWheelR.SetActive(true);
                __instance.moveStyleProps.bmxWheelF.SetActive(true);
                __instance.moveStyleProps.bmxGear.SetActive(true);
                __instance.moveStyleProps.bmxPedalL.SetActive(true);
                __instance.moveStyleProps.bmxPedalR.SetActive(true);

                //BMX Frame
                __instance.moveStyleProps.bmxFrame.transform.parent = bmxParent.transform;
                __instance.moveStyleProps.bmxFrame.transform.SetToIdentity();
                __instance.moveStyleProps.bmxFrame.transform.localPosition = StyleOnBack.bmxFramePos.Value;
                __instance.moveStyleProps.bmxFrame.transform.localRotation = Quaternion.Euler(StyleOnBack.bmxFrameRot.Value);
                __instance.moveStyleProps.bmxFrame.transform.localScale = Vector3.one * StyleOnBack.bmxFrameScale.Value;
                //

                //BMX Handlebars
                __instance.moveStyleProps.bmxHandlebars.transform.parent = bmxParent.transform;
                __instance.moveStyleProps.bmxHandlebars.transform.SetToIdentity();
                __instance.moveStyleProps.bmxHandlebars.transform.localPosition = StyleOnBack.bmxHandPos.Value;
                __instance.moveStyleProps.bmxHandlebars.transform.localRotation = Quaternion.Euler(StyleOnBack.bmxHandRot.Value);
                __instance.moveStyleProps.bmxHandlebars.transform.localScale = Vector3.one * StyleOnBack.bmxHandScale.Value;
                //

                //BMX Wheel Rear
                __instance.moveStyleProps.bmxWheelR.transform.parent = bmxParent.transform;
                __instance.moveStyleProps.bmxWheelR.transform.SetToIdentity();
                __instance.moveStyleProps.bmxWheelR.transform.localPosition =  StyleOnBack.bmxWheelRPos.Value;
                __instance.moveStyleProps.bmxWheelR.transform.localRotation = Quaternion.Euler(StyleOnBack.bmxWheelRRot.Value);
                __instance.moveStyleProps.bmxWheelR.transform.localScale = Vector3.one * StyleOnBack.bmxWheelRScale.Value;
                //

                //BMX Wheel Front
                __instance.moveStyleProps.bmxWheelF.transform.parent = bmxParent.transform;
                __instance.moveStyleProps.bmxWheelF.transform.SetToIdentity();
                __instance.moveStyleProps.bmxWheelF.transform.localPosition = StyleOnBack.bmxWheelFPos.Value;
                __instance.moveStyleProps.bmxWheelF.transform.localRotation = Quaternion.Euler(StyleOnBack.bmxWheelFRot.Value);
                __instance.moveStyleProps.bmxWheelF.transform.localScale = Vector3.one * StyleOnBack.bmxWheelFScale.Value;
                //

                //BMX Gear
                __instance.moveStyleProps.bmxGear.transform.parent = bmxParent.transform;
                __instance.moveStyleProps.bmxGear.transform.SetToIdentity();
                __instance.moveStyleProps.bmxGear.transform.localPosition = StyleOnBack.bmxGearPos.Value;
                __instance.moveStyleProps.bmxGear.transform.localRotation = Quaternion.Euler(StyleOnBack.bmxGearRot.Value);
                __instance.moveStyleProps.bmxGear.transform.localScale = Vector3.one * StyleOnBack.bmxGearScale.Value;
                //

                //BMX Pedal Left
                __instance.moveStyleProps.bmxPedalL.transform.parent = bmxParent.transform;
                __instance.moveStyleProps.bmxPedalL.transform.SetToIdentity();
                __instance.moveStyleProps.bmxPedalL.transform.localPosition = StyleOnBack.bmxPedLPos.Value;
                __instance.moveStyleProps.bmxPedalL.transform.localRotation = Quaternion.Euler(StyleOnBack.bmxPedLRot.Value);
                __instance.moveStyleProps.bmxPedalL.transform.localScale = Vector3.one * StyleOnBack.bmxPedLScale.Value;
                //

                //BMX Pedal Right
                __instance.moveStyleProps.bmxPedalR.transform.parent = bmxParent.transform;
                __instance.moveStyleProps.bmxPedalR.transform.SetToIdentity();
                __instance.moveStyleProps.bmxPedalR.transform.localPosition = StyleOnBack.bmxPedRPos.Value;
                __instance.moveStyleProps.bmxPedalR.transform.localRotation = Quaternion.Euler(StyleOnBack.bmxPedRRot.Value);
                __instance.moveStyleProps.bmxPedalR.transform.localScale = Vector3.one * StyleOnBack.bmxPedRScale.Value;
                //

                bmxParent.transform.parent = __instance.root.FindRecursive(StyleOnBack.bmxBoneName.Value);
                bmxParent.transform.localPosition = StyleOnBack.bmxGlobalPos.Value;
                bmxParent.transform.localRotation = Quaternion.Euler(StyleOnBack.bmxGlobalRot.Value);
                bmxParent.transform.localScale = Vector3.one * StyleOnBack.bmxGlobalScale.Value;
            }
            return false;
        }
    }
}
