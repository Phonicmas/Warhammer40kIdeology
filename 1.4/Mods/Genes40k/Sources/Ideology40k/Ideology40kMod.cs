using HarmonyLib;
using Verse;


namespace Ideology40k
{
    public class Ideology40kMod : Mod
    {
        public static Harmony harmony;
        public Ideology40kMod(ModContentPack content) : base(content)
        {
            harmony = new Harmony("Ideology40k.Mod");
            harmony.PatchAll();
        }
    }
}