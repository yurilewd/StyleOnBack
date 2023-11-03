using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using MovementPlus.Patches;
using Reptile;
using StyleOnBack.Patches;
using System;
using System.Configuration;
using System.Linq;
using UnityEngine;

namespace StyleOnBack
{
    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class StyleOnBack : BaseUnityPlugin
    {
        private const string MyGUID = "com.yuril.StyleOnBack";
        private const string PluginName = "StyleOnBack";
        private const string VersionString = "1.0.0";

        private Harmony harmony;
        public static Player player;


        public static ConfigEntry<bool> placementMode;




        //Inline Config
        public static ConfigEntry<string> skateBoneName;

        public static ConfigEntry<Vector3> skateGlobalPos;
        public static ConfigEntry<Vector3> skateGlobalRot;
        public static ConfigEntry<float> skateGlobalScale;

        public static ConfigEntry<Vector3> skateLPos;
        public static ConfigEntry<Vector3> skateLRot;
        public static ConfigEntry<float> skateLScale;

        public static ConfigEntry<Vector3> skateRPos;
        public static ConfigEntry<Vector3> skateRRot;
        public static ConfigEntry<float> skateRScale;
        //


        //Skateboard Config
        public static ConfigEntry<string> skateboardBoneName;

        public static ConfigEntry<Vector3> skateboardGlobalPos;
        public static ConfigEntry<Vector3> skateboardGlobalRot;
        public static ConfigEntry<float> skateboardGlobalScale;

        public static ConfigEntry<Vector3> skateboardPos;
        public static ConfigEntry<Vector3> skateboardRot;
        public static ConfigEntry<float> skateboardScale;
        //


        //BMX Config
        public static ConfigEntry<string> bmxBoneName;

        public static ConfigEntry<Vector3> bmxGlobalPos;
        public static ConfigEntry<Vector3> bmxGlobalRot;
        public static ConfigEntry<float> bmxGlobalScale;

        public static ConfigEntry<Vector3> bmxFramePos;
        public static ConfigEntry<Vector3> bmxFrameRot;
        public static ConfigEntry<float> bmxFrameScale;

        public static ConfigEntry<Vector3> bmxHandPos;
        public static ConfigEntry<Vector3> bmxHandRot;
        public static ConfigEntry<float> bmxHandScale;

        public static ConfigEntry<Vector3> bmxWheelRPos;
        public static ConfigEntry<Vector3> bmxWheelRRot;
        public static ConfigEntry<float> bmxWheelRScale;

        public static ConfigEntry<Vector3> bmxWheelFPos;
        public static ConfigEntry<Vector3> bmxWheelFRot;
        public static ConfigEntry<float> bmxWheelFScale;

        public static ConfigEntry<Vector3> bmxGearPos;
        public static ConfigEntry<Vector3> bmxGearRot;
        public static ConfigEntry<float> bmxGearScale;

        public static ConfigEntry<Vector3> bmxPedLPos;
        public static ConfigEntry<Vector3> bmxPedLRot;
        public static ConfigEntry<float> bmxPedLScale;

        public static ConfigEntry<Vector3> bmxPedRPos;
        public static ConfigEntry<Vector3> bmxPedRRot;
        public static ConfigEntry<float> bmxPedRScale;
        //




        private void Awake()
        {
            harmony = new Harmony(MyGUID);
            harmony.PatchAll(typeof(PlayerPatch));
            harmony.PatchAll(typeof(CharacterVisualPatch));
            harmony.PatchAll(typeof(BoostAbilityPatch));

            


            placementMode = Config.Bind("000", "Enable Placement Mode", false, new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = false }));


            //Inline Config
            skateBoneName = Config.Bind("Inline", "Inline Bone Name", "s2", new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));

            skateGlobalPos = Config.Bind("Inline", "Inline Global Position", new Vector3(0f, 0f, 0f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = false}));
            skateGlobalRot = Config.Bind("Inline", "Inline Global Rotation", new Vector3(0f, 0f, 0f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = false }));
            skateGlobalScale = Config.Bind("Inline", "Inline Global Scale", 1f, new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = false }));

            skateLPos = Config.Bind("Inline", "Inline Left Position", new Vector3(0f, 0.05f, -0.17f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            skateLRot = Config.Bind("Inline", "Inline Left Rotation", new Vector3(295.05f, 318.04f, 61.09f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            skateLScale = Config.Bind("Inline", "Inline Left Scale", 0.75f, new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));

            skateRPos = Config.Bind("Inline", "Inline Right Position", new Vector3(-0.02f, -0.05f, -0.17f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            skateRRot = Config.Bind("Inline", "Inline Right Rotation", new Vector3(64.91f, 290f, 270f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            skateRScale = Config.Bind("Inline", "Inline Right Scale", 0.75f, new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            //

            //Skateboard Config
            skateboardBoneName = Config.Bind("Skateboard", "Skateboard Bone Name", "s2", new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));

            skateboardGlobalPos = Config.Bind("Skateboard", "Skateboard Global Position", new Vector3(0f, 0f, 0f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = false }));
            skateboardGlobalRot = Config.Bind("Skateboard", "Skateboard Global Rotation", new Vector3(0f, 0f, 0f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = false }));
            skateboardGlobalScale = Config.Bind("Skateboard", "Skateboard Global Scale", 1f, new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = false }));

            skateboardPos = Config.Bind("Skateboard", "Skateboard Position", new Vector3(-0.07f, 0f, -0.2f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            skateboardRot = Config.Bind("Skateboard", "Skateboard Rotation", new Vector3(63.15f, 286.55f, 260f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            skateboardScale = Config.Bind("Skateboard", "Skateboard Scale", 0.75f, new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            //

            //BMX Config
            bmxBoneName = Config.Bind("BMX", "BMX Bone Name", "s2", new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));

            bmxGlobalPos = Config.Bind("BMX", "BMX Global Position", new Vector3(0f, 0f, 0f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = false }));
            bmxGlobalRot = Config.Bind("BMX", "BMX Global Rotation", new Vector3(0f, 0f, 0f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = false }));
            bmxGlobalScale = Config.Bind("BMX", "BMX Global Scale", 1f, new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = false }));

            bmxFramePos = Config.Bind("BMX", "BMX Frame Position", new Vector3(-0.07f, 0f, -0.3f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            bmxFrameRot = Config.Bind("BMX", "BMX Frame Rotation", new Vector3(180f, -50f, 90f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            bmxFrameScale = Config.Bind("BMX", "BMX Frame Scale", 0.75f, new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));

            bmxHandPos = Config.Bind("BMX", "BMX Handlebars Position", new Vector3(0.12f, 0.11f, -0.45f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            bmxHandRot = Config.Bind("BMX", "BMX Handlebars Rotation", new Vector3(0f, 233f, 255f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            bmxHandScale = Config.Bind("BMX", "BMX Handlebars Scale", 0.75f, new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));

            bmxWheelRPos = Config.Bind("BMX", "BMX Wheel Rear Position", new Vector3(-0.35f, -0.12f, -0.06f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            bmxWheelRRot = Config.Bind("BMX", "BMX Wheel Rear Rotation", new Vector3(0f, -50f, 0f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            bmxWheelRScale = Config.Bind("BMX", "BMX Wheel Rear Scale", 0.75f, new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));

            bmxWheelFPos = Config.Bind("BMX", "BMX Wheel Front Position", new Vector3(0.17f, -0.14f, -0.50f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            bmxWheelFRot = Config.Bind("BMX", "BMX Wheel Front Rotation", new Vector3(0f, 319.40f, 0.35f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            bmxWheelFScale = Config.Bind("BMX", "BMX Wheel Front Scale", 0.75f, new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));

            bmxGearPos = Config.Bind("BMX", "BMX Gear Position", new Vector3(-0.13f, -0.1f, -0.26f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            bmxGearRot = Config.Bind("BMX", "BMX Gear Rotation", new Vector3(0f, -50f, 0f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            bmxGearScale = Config.Bind("BMX", "BMX Gear Scale", 0.75f, new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));

            bmxPedLPos = Config.Bind("BMX", "BMX Pedal Left Position", new Vector3(-.12f, -0.23f, -0.24f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            bmxPedLRot = Config.Bind("BMX", "BMX Pedal Left Rotation", new Vector3(5.56f, 313.56f, 357.42f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            bmxPedLScale = Config.Bind("BMX", "BMX Pedal Left Scale", 0.75f, new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));

            bmxPedRPos = Config.Bind("BMX", "BMX Pedal Right Position", new Vector3(-0.14f, 0.02f, -0.3f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            bmxPedRRot = Config.Bind("BMX", "BMX Pedal Right Rotation", new Vector3(359.23f, 307.6f, 353.96f), new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            bmxPedRScale = Config.Bind("BMX", "BMX Pedal Right Scale", 0.75f, new ConfigDescription("", null, new ConfigurationManagerAttributes { IsAdvanced = true }));
            //
        }


        public static void DestroyTheChild(Transform parent)
        {
            for (int i = parent.childCount - 1; i >= 0; i--)
            {
                Transform child = parent.GetChild(i);
                DestroyImmediate(child.gameObject);
            }
        }


        private void FixedUpdate()
        {
            if (player == null)
            {
                return;
            }
            if (placementMode.Value)
            {
                switch(player.moveStyleEquipped)
                {
                    case MoveStyle.BMX:
                        player.characterVisual.SetBMXPropsMode(CharacterVisual.MoveStylePropMode.ON_BACK);
                        break;
                    case MoveStyle.SKATEBOARD:
                        player.characterVisual.SetSkateboardPropsMode(CharacterVisual.MoveStylePropMode.ON_BACK);
                        break;
                    case MoveStyle.INLINE:
                        player.characterVisual.SetInlineSkatesPropsMode(CharacterVisual.MoveStylePropMode.ON_BACK);
                        break;
                    default:
                        break;
                }
                
            }
        }
    }
}
