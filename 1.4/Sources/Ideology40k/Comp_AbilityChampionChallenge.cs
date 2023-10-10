using RimWorld;
using Verse;

namespace Ideology40k
{
    public class Comp_AbilityChampionChallenge : CompAbilityEffect
    {
        private Pawn target = null;
        public new CompProperties_AbilityChampionChallenge Props => (CompProperties_AbilityChampionChallenge)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            target = target.Pawn;
            target.Pawn.health.AddHediff(Ideology40kDefOf.BEWH_ChallengeReciever);

            parent.pawn.health.AddHediff(Ideology40kDefOf.BEWH_ChallengeInstigator);

            base.Apply(target, dest);
        }
    }
}