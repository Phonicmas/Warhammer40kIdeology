using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;


namespace Faction40k
{
    [HarmonyPatch(typeof(RitualOutcomeEffectWorker_Bestowing), "Apply")]
    public class BestowerGivesGenes
    {
        public static void Postfix(LordJob_Ritual jobRitual)
        {
            LordJob_BestowingCeremony lordJob_BestowingCeremony = (LordJob_BestowingCeremony)jobRitual;
            Pawn target = lordJob_BestowingCeremony.target;
            Pawn bestower = lordJob_BestowingCeremony.bestower;
            RoyalTitleDef targetTitle = target.royalty.GetCurrentTitle(bestower.Faction);

            if (!targetTitle.HasModExtension<DefModExtension_RoyalTitleReward>())
            {
                return;
            }

            DefModExtension_RoyalTitleReward defModExtension = targetTitle.GetModExtension<DefModExtension_RoyalTitleReward>();
            List<GeneDef> genesToAdd = defModExtension.awardedGenes;
            for (int i = 0; i < genesToAdd.Count(); i++)
            {
                if (!target.genes.HasGene(genesToAdd[i]))
                {
                    target.genes.AddGene(genesToAdd[i], true);
                }
            }

            target.genes.xenotypeName = defModExtension.newXenotypeName;

            target.genes.iconDef = defModExtension.newXenotypeIconDef;

        }
    }
}