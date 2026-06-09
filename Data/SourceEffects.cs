using WFHub.Models;
using static WFHub.Data.DamageTypes;
using static WFHub.Data.Status.StatusEffects;

namespace WFHub.Data
{
    public class SourceEffects
    {
        public static readonly List<DamageEffect> All =
        [
            new(Impact, Stagger),
            new(Impact, MercyThreshold),

            new(Puncture, DamageReduction),
            new(Puncture, CriticalChanceIncrease),

            new(Slash, Bleed),
            new(Slash, ArmorIgnore),

            new(Cold, Slow),
            new(Cold, CriticalDamageIncrease),

            new(Heat, Burn),
            new(Heat, Panic),
            new(Heat, ArmorReduction),

            new(Electricity, TeslaChain),
            new(Electricity, Stun),

            new(Toxin, Poison),
            new(Toxin, ShieldIgnore),

            new(Blast, Explosions),

            new(Gas, GasCloud),

            new(Magnetic, ShieldAmplification),
            new(Magnetic, ShieldRegenNegation),
            new(Magnetic, OverguardAmplification),

            new(Radiation, FriendlyFire),

            new(Viral, HealthAmplification),

            new(VoidType, BulletAttraction),

            new(Tau, StatusVulnerability)
        ];
    }
}
