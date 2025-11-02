using MelonLoader;
using HarmonyLib;
using Il2Cpp;
using UnityEngine;
using Il2CppBehaviorDesigner.Runtime;
using Il2CppCoffee.UIParticleExtensions;

[assembly: MelonInfo(typeof(SwornMod.Core), "SwornMod", "1.0.0", "Vercility", null)]
[assembly: MelonGame("Windwalk Games", "SWORN")]

namespace SwornMod
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("Initialized.");
        }
    }
}

[HarmonyPatch(typeof(ArcaneBladeProjectileManager), "RunProjectile")]
class Patch
{
    static void Prefix(ArcaneBladeProjectileManager.Settings settings)
    {
        settings.baseDamage = 50f;
        Vector3 vec = ApplyZCompensation(settings.direction);
        settings.direction = vec;
        settings.offset = new Vector3(0f,0.5f,0f);
        settings.duration *= 1.2f;
    }

    public static Vector3 ApplyZCompensation(Vector3 dir, float maxOffset = 0.2f)
    {
        if (dir == Vector3.zero)
            return dir;

        Vector3 normDir = dir.normalized;

        // Measure how aligned the direction is with the Z axis
        float zDot = Mathf.Abs(Vector3.Dot(normDir, Vector3.forward)); // 1 = straight Z, 0 = sideways (X)
        float horizontalFactor = 1f - zDot; // 0 when up/down (Z), 1 when sideways (X)

        // Apply downward correction in -Z
        Vector3 adjusted = normDir - Vector3.back * horizontalFactor * maxOffset;

        return adjusted.normalized;
    }

}