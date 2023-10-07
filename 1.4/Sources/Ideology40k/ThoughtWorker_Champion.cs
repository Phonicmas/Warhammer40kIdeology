using RimWorld;
using Verse;

namespace Ideology40k
{
    public class ThoughtWorker_Champion : ThoughtWorker
    {
        protected override ThoughtState CurrentSocialStateInternal(Pawn pawn, Pawn other)
        {
            if (!other.RaceProps.Humanlike || !RelationsUtility.PawnsKnowEachOther(pawn, other))
            {
                return false;
            }
            if (pawn.ideo == null || other.ideo == null)
            {
                return false;
            }
            if (other.Ideo != pawn.Ideo)
            {
                return false;
            }
            if (other.Ideo.GetRole(other) == null)
            {
                return false;
            }
            if (other.Ideo.GetRole(other).def == Ideology40kDefOf.BEWH_Champion)
            {
                pawn.needs.mood.thoughts.memories.TryGainMemory(Ideology40kDefOf.BEWH_InteractedWithChampionMood);
                return true;
            }     

            return false;
        }
    }
}