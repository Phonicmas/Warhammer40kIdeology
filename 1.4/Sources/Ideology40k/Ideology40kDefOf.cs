using RimWorld;
using Verse;


namespace Ideology40k
{
    [DefOf]
    public static class Ideology40kDefOf
    {
        public static PreceptDef BEWH_Champion;

        public static ThoughtDef BEWH_InteractedWithChampionMood;

        static Ideology40kDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(Ideology40kDefOf));
        }
    }
}