using HarmonyLib;
using RimWorld;
using Verse;

namespace Ideology40k
{
    [HarmonyPatch(typeof(Pawn), "PreApplyDamage")]
    public class ChampionChallengePatch
    {
        public static void Prefix(ref DamageInfo dinfo, Pawn __instance)
        {
            if (!(dinfo.Instigator is Pawn))
            {
                return;
            }

            Pawn target = __instance;
            Pawn instigator = dinfo.Instigator as Pawn;

            int targetIndex = target.health.hediffSet.hediffs.FindIndex(x => x.def.HasModExtension<DefModExtension_ChampionChallenge>());
            int instigatorIndex = instigator.health.hediffSet.hediffs.FindIndex(x => x.def.HasModExtension<DefModExtension_ChampionChallenge>());

            if (targetIndex >= 0 && instigatorIndex >= 0)
            {
                DefModExtension_ChampionChallenge defender = target.health.hediffSet.hediffs[targetIndex].def.GetModExtension<DefModExtension_ChampionChallenge>();
                DefModExtension_ChampionChallenge attacker = instigator.health.hediffSet.hediffs[instigatorIndex].def.GetModExtension<DefModExtension_ChampionChallenge>();

                if (attacker.IsChallenger ^ defender.IsChallenger)
                {
                    Log.Message("Damage before: " + dinfo.Amount);
                    dinfo.SetAmount(dinfo.Amount * defender.damageMultiplier);
                    Log.Message("Damage after: " + dinfo.Amount);
                }
            }
            else if (targetIndex >= 0)
            {
                DefModExtension_ChampionChallenge defender = target.health.hediffSet.hediffs[targetIndex].def.GetModExtension<DefModExtension_ChampionChallenge>();
                if (defender.IsChallenger)
                {
                    Log.Message("Damage before: " + dinfo.Amount);
                    dinfo.SetAmount(dinfo.Amount * defender.damageMultiplierOther);
                    Log.Message("Damage after: " + dinfo.Amount);
                }
            }
        }
    }
}