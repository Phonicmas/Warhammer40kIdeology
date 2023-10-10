using RimWorld;
using Verse;


namespace Ideology40k
{
    [DefOf]
    public static class Ideology40kDefOf
    {
        public static PreceptDef BEWH_Champion;

        public static ThoughtDef BEWH_InteractedWithChampionMood;

        public static HediffDef BEWH_ChallengeInstigator;
        public static HediffDef BEWH_ChallengeReciever;

        static Ideology40kDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(Ideology40kDefOf));
        }
    }
}