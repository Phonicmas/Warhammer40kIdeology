using RimWorld;
using Verse;


namespace Ideology40k
{
    [DefOf]
    public static class Ideology40kDefOf
    {

        public static HediffDef BEWH_SecondGeneseedHarvest;
        static Ideology40kDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(Ideology40kDefOf));
        }
    }
}